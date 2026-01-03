using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Spock.Core.Models;
using Spock.Data;
using Spock.Engine;

namespace Spock.UI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ApprovalEngine _approvalEngine;
    private readonly SpockDialogueEngine _dialogueEngine;
    private readonly WeaknessTracker _weaknessTracker;
    private readonly Random _random = new();
    private readonly DebugServer? _debugServer;
    
    // Comprehensive problem bank - 150+ problems across all domains
    private readonly List<Problem> _problemBank;
    private int _currentProblemIndex = -1; // Start at -1 so first LoadNextProblem goes to 0
    private Problem? _currentProblem;
    
    private string _currentQuestion = "";
    private string _userAnswer = "";
    private string _spockMessage = "Ready to begin.";
    private int _correctStreak = 0;
    private int _totalAttempts = 0;
    private int _correctAnswers = 0;
    private bool _isAnswerSubmitted = false;
    private string _feedbackMessage = "";
    private string _submitButtonText = "Submit Answer";
    private bool _isMultipleChoice = false;
    private ObservableCollection<string> _multipleChoiceOptions = new();
    private Domain _currentDomain = Domain.Math;

    public MainViewModel(DebugServer? debugServer = null)
    {
        _debugServer = debugServer;
        _approvalEngine = new ApprovalEngine();
        _dialogueEngine = new SpockDialogueEngine();
        _weaknessTracker = new WeaknessTracker();
        
        // Load comprehensive problem bank from ProblemBank class
        _problemBank = ProblemBank.GetAllProblems();
        
        // Shuffle for variety - ADD-friendly randomization
        _problemBank = _problemBank.OrderBy(_ => _random.Next()).ToList();
        
        // Commands
        SubmitCommand = new RelayCommand(
            async () => await SubmitAnswerAsync(), 
            () => IsAnswerSubmitted || !string.IsNullOrWhiteSpace(UserAnswer));
        NextProblemCommand = new RelayCommand(LoadNextProblem, () => _isAnswerSubmitted);
        SelectOptionCommand = new RelayCommand<string>(SelectOption, option => !IsAnswerSubmitted);
        
        // Load first problem
        LoadNextProblem();
        
        // Update debug state
        UpdateDebugState();
    }

    public string CurrentQuestion
    {
        get => _currentQuestion;
        set { _currentQuestion = value; OnPropertyChanged(); }
    }

    public string UserAnswer
    {
        get => _userAnswer;
        set 
        { 
            _userAnswer = value; 
            OnPropertyChanged();
            ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
        }
    }

    public string SpockMessage
    {
        get => _spockMessage;
        set { _spockMessage = value; OnPropertyChanged(); }
    }

    public string FeedbackMessage
    {
        get => _feedbackMessage;
        set { _feedbackMessage = value; OnPropertyChanged(); }
    }

    public int CorrectStreak
    {
        get => _correctStreak;
        set { _correctStreak = value; OnPropertyChanged(); }
    }

    public int TotalAttempts
    {
        get => _totalAttempts;
        set { _totalAttempts = value; OnPropertyChanged(); }
    }

    public int CorrectAnswers
    {
        get => _correctAnswers;
        set { _correctAnswers = value; OnPropertyChanged(); }
    }

    public string SubmitButtonText
    {
        get => _submitButtonText;
        set { _submitButtonText = value; OnPropertyChanged(); }
    }

    public bool IsAnswerSubmitted
    {
        get => _isAnswerSubmitted;
        set 
        { 
            _isAnswerSubmitted = value; 
            OnPropertyChanged();
            ((RelayCommand)NextProblemCommand).RaiseCanExecuteChanged();
        }
    }

    public bool IsMultipleChoice
    {
        get => _isMultipleChoice;
        set { _isMultipleChoice = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string> MultipleChoiceOptions
    {
        get => _multipleChoiceOptions;
        set { _multipleChoiceOptions = value; OnPropertyChanged(); }
    }
    
    public Domain CurrentDomain
    {
        get => _currentDomain;
        set { _currentDomain = value; OnPropertyChanged(); }
    }

    public double AccuracyPercentage => TotalAttempts > 0 ? (CorrectAnswers * 100.0 / TotalAttempts) : 0;

    public ICommand SubmitCommand { get; }
    public ICommand NextProblemCommand { get; }
    public ICommand SelectOptionCommand { get; }

    private async Task SubmitAnswerAsync()
    {
        // If answer already submitted, this is actually a "Next Problem" action
        if (IsAnswerSubmitted)
        {
            LoadNextProblem();
            return;
        }

        if (_currentProblem == null) return;
        
        var isCorrect = CheckAnswer(_currentProblem, UserAnswer);
        
        TotalAttempts++;
        
        if (isCorrect)
        {
            CorrectAnswers++;
            CorrectStreak++;
            FeedbackMessage = "✓ Correct";
        }
        else
        {
            CorrectStreak = 0;
            FeedbackMessage = $"✗ Incorrect. The answer was: {_currentProblem.Content.CorrectAnswers.First()}";
        }
        
        OnPropertyChanged(nameof(AccuracyPercentage));

        // Process through approval engine
        var problemAttempt = new ProblemAttempt
        {
            ProblemId = _currentProblem.Id,
            IsCorrect = isCorrect,
            TimeSpentSeconds = 10, // Would be real timing in production
            AttemptTime = DateTime.UtcNow
        };

        var approvalResult = await _approvalEngine.ProcessProblemAsync(problemAttempt, CancellationToken.None);

        // Get Spock's response
        if (approvalResult.Any())
        {
            var latestApproval = approvalResult.Last();
            
            if (latestApproval.Type == ApprovalType.Mastery)
            {
                var response = await _dialogueEngine.GetStrongApprovalAsync(
                    "skill-mastered",
                    1, // sessions ago
                    CancellationToken.None);
                SpockMessage = response.Message;
            }
            else
            {
                var response = await _dialogueEngine.GetSubtleApprovalAsync(
                    CorrectStreak,
                    _currentProblem.MicroTopic,
                    CancellationToken.None);
                SpockMessage = response.Message;
            }
            
            // Occasionally add narrative echo
            if (_random.NextDouble() < 0.2 && !string.IsNullOrEmpty(latestApproval.Context))
            {
                var echo = await _dialogueEngine.GetNarrativeEchoAsync(
                    latestApproval,
                    CancellationToken.None);
                if (echo != null && !string.IsNullOrEmpty(echo.Message))
                {
                    SpockMessage += "\n\n" + echo.Message;
                }
            }
        }
        else if (!isCorrect)
        {
            var response = await _dialogueEngine.GetCorrectiveFeedbackAsync(
                _currentProblem.MicroTopic,
                "Review the fundamentals",
                CancellationToken.None);
            SpockMessage = response.Message;
        }
        else
        {
            var response = await _dialogueEngine.GetNeutralDialogueAsync(CancellationToken.None);
            SpockMessage = response.Message;
        }

        IsAnswerSubmitted = true;
        SubmitButtonText = "Next Problem";
        
        // Update debug state after submission
        UpdateDebugState();
    }

    private void LoadNextProblem()
    {
        IsAnswerSubmitted = false;
        SubmitButtonText = "Submit Answer";
        UserAnswer = "";
        FeedbackMessage = "";
        
        // Cycle through problems
        _currentProblemIndex = (_currentProblemIndex + 1) % _problemBank.Count;
        _currentProblem = _problemBank[_currentProblemIndex];
        
        // Update current domain for color/emoji display
        CurrentDomain = _currentProblem.Domain;
        
        // Check if multiple choice and setup options
        IsMultipleChoice = _currentProblem.Content.Format == ProblemFormat.MultipleChoice && 
                          _currentProblem.Content.Options?.Any() == true;
        
        if (IsMultipleChoice)
        {
            MultipleChoiceOptions.Clear();
            foreach (var option in _currentProblem.Content.Options!)
            {
                MultipleChoiceOptions.Add(option);
            }
            // Domain will be shown in visual indicator, not text
            CurrentQuestion = _currentProblem.Content.Question;
        }
        else
        {
            CurrentQuestion = FormatProblem(_currentProblem);
        }
        
        if (!IsAnswerSubmitted)
        {
            var response = _dialogueEngine.GetNeutralDialogueAsync(CancellationToken.None).Result;
            SpockMessage = response.Message;
        }
        
        ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
        ((RelayCommand<string>)SelectOptionCommand).RaiseCanExecuteChanged();
        
        // Update debug state
        UpdateDebugState();
    }

    private void UpdateDebugState()
    {
        // Debug server functionality removed - will be re-implemented if needed
        // Left as placeholder for future debugging features
    }

    private void SelectOption(string option)
    {
        if (IsAnswerSubmitted || !IsMultipleChoice) return;
        
        // For multiple choice, auto-submit when option is clicked
        UserAnswer = option;
        _ = SubmitAnswerAsync();
    }

    private string FormatProblem(Problem problem)
    {
        var formatted = $"[{problem.Domain}] {problem.Content.Question}";
        
        if (problem.Content.Format == ProblemFormat.MultipleChoice && problem.Content.Options?.Any() == true)
        {
            formatted += "\n\nOptions:";
            for (int i = 0; i < problem.Content.Options.Count; i++)
            {
                formatted += $"\n{(char)('A' + i)}. {problem.Content.Options[i]}";
            }
        }
        
        return formatted;
    }

    private bool CheckAnswer(Problem problem, string answer)
    {
        if (string.IsNullOrWhiteSpace(answer)) return false;
        
        answer = answer.Trim();
        
        // For multiple choice, do exact match (case-insensitive)
        if (problem.Content.Format == ProblemFormat.MultipleChoice)
        {
            foreach (var correctAnswer in problem.Content.CorrectAnswers)
            {
                if (answer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
        }
        else
        {
            // For free response, normalize and compare
            var normalizedAnswer = answer.ToLowerInvariant();
            foreach (var correctAnswer in problem.Content.CorrectAnswers)
            {
                if (normalizedAnswer == correctAnswer.ToLowerInvariant())
                    return true;
            }
        }
        
        return false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// Simple RelayCommand implementation
public class RelayCommand : ICommand
{
    private readonly Func<Task> _executeAsync;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Func<Task> executeAsync, Func<bool>? canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
        : this(() => { execute(); return Task.CompletedTask; }, canExecute)
    {
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public async void Execute(object? parameter) => await _executeAsync();

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

// Generic RelayCommand with parameter
public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;

    public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => 
        _canExecute?.Invoke((T)parameter!) ?? true;

    public void Execute(object? parameter) => _execute((T)parameter!);

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
