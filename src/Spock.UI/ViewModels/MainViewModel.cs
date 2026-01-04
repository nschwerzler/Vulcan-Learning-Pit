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
    private Dictionary<string, int> _problemAttempts = new(); // Track attempts per problem
    
    private string _currentQuestion = "";
    private string _userAnswer = "";
    private string _spockMessage = "Ready to begin.";
    private int _correctStreak = 0;
    private int _totalAttempts = 0;
    private int _correctAnswers = 0;
    private int _gameTokenSeconds = 0;  // Start at 0 seconds
    private int _lastTokensEarned = 0;  // Last reward earned (for display)
    private bool _isAnswerSubmitted = false;
    private string _feedbackMessage = "";
    private bool _isCorrectAnswer = false;
    private string _submitButtonText = "Submit Answer";
    private bool _isMultipleChoice = false;
    private ObservableCollection<string> _multipleChoiceOptions = new();
    private Domain _currentDomain = Domain.Math;
    private string _multipleChoiceInstruction = "";
    private string _selectedGradeLevel = "All";
    private string _selectedSubject = "All";
    private List<Problem> _filteredProblems = new();

    public MainViewModel(DebugServer? debugServer = null)
    {
        _debugServer = debugServer;
        _approvalEngine = new ApprovalEngine();
        _dialogueEngine = new SpockDialogueEngine();
        _weaknessTracker = new WeaknessTracker();
        
        // Load comprehensive problem bank from ProblemBank class
        _problemBank = ProblemBank.GetAllProblems();
        
        // Commands
        SubmitCommand = new RelayCommand(
            async () => await SubmitAnswerAsync(), 
            () => IsAnswerSubmitted || !string.IsNullOrWhiteSpace(UserAnswer));
        NextProblemCommand = new RelayCommand(LoadNextProblem, () => _isAnswerSubmitted);
        SelectOptionCommand = new RelayCommand<string>(SelectOption, option => !IsAnswerSubmitted);
        
        // Initial filter and load first problem
        FilterAndShuffleProblems();
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

    public bool IsCorrectAnswer
    {
        get => _isCorrectAnswer;
        set { _isCorrectAnswer = value; OnPropertyChanged(); }
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

    public int GameTokenSeconds
    {
        get => _gameTokenSeconds;
        set { _gameTokenSeconds = value; OnPropertyChanged(); }
    }

    public int LastTokensEarned
    {
        get => _lastTokensEarned;
        set { _lastTokensEarned = value; OnPropertyChanged(); }
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

    public string MultipleChoiceInstruction
    {
        get => _multipleChoiceInstruction;
        set { _multipleChoiceInstruction = value; OnPropertyChanged(); }
    }
    
    public Domain CurrentDomain
    {
        get => _currentDomain;
        set { _currentDomain = value; OnPropertyChanged(); }
    }

    public string SelectedGradeLevel
    {
        get => _selectedGradeLevel;
        set
        {
            _selectedGradeLevel = value;
            OnPropertyChanged();
            FilterAndShuffleProblems();
        }
    }

    public string SelectedSubject
    {
        get => _selectedSubject;
        set
        {
            _selectedSubject = value;
            OnPropertyChanged();
            FilterAndShuffleProblems();
        }
    }

    public ObservableCollection<string> GradeLevels { get; } = new ObservableCollection<string>
    {
        "All",
        "Grade 1",
        "Grade 2",
        "Grade 3",
        "Grade 4",
        "Grade 5",
        "Grade 6",
        "Grade 7",
        "Grade 8",
        "Grade 9",
        "Grade 10",
        "Grade 11",
        "Grade 12",
        "College"
    };

    public ObservableCollection<string> Subjects { get; } = new ObservableCollection<string>
    {
        "All",
        "Math",
        "Logic",
        "Reading",
        "Science",
        "Executive Skills",
        "Washington History",
        "Bitcoin",
        "Minecraft",
        "Health"
    };

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
        
        // Track attempt count for this specific problem
        if (!_problemAttempts.ContainsKey(_currentProblem.Id))
        {
            _problemAttempts[_currentProblem.Id] = 0;
        }
        _problemAttempts[_currentProblem.Id]++;
        var attemptNumber = _problemAttempts[_currentProblem.Id];
        
        if (isCorrect)
        {
            CorrectAnswers++;
            CorrectStreak++;
            IsCorrectAnswer = true;
            FeedbackMessage = "CORRECT";
            
            // Award game time: 1 second × difficulty level (except Minecraft = flat 1 second)
            int secondsEarned = _currentProblem.Domain == Domain.Minecraft ? 1 : _currentProblem.Difficulty;
            GameTokenSeconds += secondsEarned;
            LastTokensEarned = secondsEarned;  // Track for reward display
            
            // Reset attempt counter for this problem on success
            _problemAttempts.Remove(_currentProblem.Id);
        }
        else
        {
            CorrectStreak = 0;
            IsCorrectAnswer = false;
            FeedbackMessage = $"INCORRECT. The answer was: {_currentProblem.Content.CorrectAnswers.First()}";
            LastTokensEarned = -1;  // Show penalty
            
            // Deduct 1 second on incorrect, but maintain minimum of 1 second
            GameTokenSeconds = Math.Max(0, GameTokenSeconds - 1);
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
            // Show complete solution and move on - no retry needed
            var response = await _dialogueEngine.GetCorrectiveFeedbackWithGuidanceAsync(
                _currentProblem,
                attemptNumber,
                CancellationToken.None);
            
            // Build comprehensive feedback showing what they did wrong and the full solution
            var feedbackParts = new List<string>();
            feedbackParts.Add($"Incorrect. Your answer: {UserAnswer}");
            
            // Add the dialogue engine response (includes pedagogical guidance)
            feedbackParts.Add(response.Message);
            
            // Add the complete worked solution if available
            if (_currentProblem.Content.Guidance != null)
            {
                if (!string.IsNullOrEmpty(_currentProblem.Content.Guidance.WorkedExample))
                {
                    feedbackParts.Add($"\nComplete solution:\n{_currentProblem.Content.Guidance.WorkedExample}");
                }
                else if (_currentProblem.Content.Guidance.StepsDetailed?.Any() == true)
                {
                    feedbackParts.Add($"\nStep-by-step solution:");
                    for (int i = 0; i < _currentProblem.Content.Guidance.StepsDetailed.Count; i++)
                    {
                        feedbackParts.Add($"{i + 1}. {_currentProblem.Content.Guidance.StepsDetailed[i]}");
                    }
                }
                
                if (!string.IsNullOrEmpty(_currentProblem.Content.Guidance.KeyPrinciple))
                {
                    feedbackParts.Add($"\nKey principle: {_currentProblem.Content.Guidance.KeyPrinciple}");
                }
            }
            
            // Show correct answer
            var correctAnswerText = string.Join(", ", _currentProblem.Content.CorrectAnswers);
            feedbackParts.Add($"\nCorrect answer: {correctAnswerText}");
            
            SpockMessage = string.Join("\n", feedbackParts);
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
        
        // Cycle through filtered problems
        if (_filteredProblems.Count == 0)
        {
            CurrentQuestion = "No problems match the selected filters.";
            SpockMessage = "Adjust filters to see problems.";
            return;
        }
        
        _currentProblemIndex = (_currentProblemIndex + 1) % _filteredProblems.Count;
        _currentProblem = _filteredProblems[_currentProblemIndex];
        
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
            // Set instruction based on whether multiple answers are allowed
            MultipleChoiceInstruction = _currentProblem.Content.AllowMultipleAnswers 
                ? "Pick 1 or more" 
                : "Pick 1";
        }
        
        // Always set CurrentQuestion to ensure it displays (not conditional on format)
        CurrentQuestion = _currentProblem.Content.Question;
        
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

    private void FilterAndShuffleProblems()
    {
        // Start with all problems
        var filtered = _problemBank.AsEnumerable();
        
        // Filter by grade level
        if (SelectedGradeLevel != "All")
        {
            filtered = SelectedGradeLevel switch
            {
                "Grade 1" => filtered.Where(p => p.Difficulty == 1),
                "Grade 2" => filtered.Where(p => p.Difficulty == 2),
                "Grade 3" => filtered.Where(p => p.Difficulty == 3),
                "Grade 4" => filtered.Where(p => p.Difficulty == 4),
                "Grade 5" => filtered.Where(p => p.Difficulty == 5),
                "Grade 6" => filtered.Where(p => p.Difficulty == 6),
                "Grade 7" => filtered.Where(p => p.Difficulty == 7),
                "Grade 8" => filtered.Where(p => p.Difficulty == 8),
                "Grade 9" => filtered.Where(p => p.Difficulty == 9),
                "Grade 10" => filtered.Where(p => p.Difficulty == 10),
                "Grade 11" => filtered.Where(p => p.Difficulty == 11),
                "Grade 12" => filtered.Where(p => p.Difficulty == 12),
                "College" => filtered.Where(p => p.Difficulty >= 9 && p.Difficulty <= 10),
                _ => filtered
            };
        }
        
        // Filter by subject
        if (SelectedSubject != "All")
        {
            var domain = SelectedSubject switch
            {
                "Math" => Domain.Math,
                "Logic" => Domain.Logic,
                "Reading" => Domain.Reading,
                "Science" => Domain.Science,
                "Executive Skills" => Domain.Executive,
                "Washington History" => Domain.WashingtonHistory,
                "Bitcoin" => Domain.Bitcoin,
                "Minecraft" => Domain.Minecraft,
                "Health" => Domain.Health,
                _ => (Domain?)null
            };
            
            if (domain.HasValue)
            {
                filtered = filtered.Where(p => p.Domain == domain.Value);
            }
        }
        
        // Convert to list and shuffle
        _filteredProblems = filtered.ToList();
        
        // Shuffle using Fisher-Yates algorithm
        for (int i = _filteredProblems.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            var temp = _filteredProblems[i];
            _filteredProblems[i] = _filteredProblems[j];
            _filteredProblems[j] = temp;
        }
        
        // Reset current problem index and state when filters change
        _currentProblemIndex = -1;
        _isAnswerSubmitted = false;
        _userAnswer = "";
        _feedbackMessage = "";
        IsCorrectAnswer = false;
        SubmitButtonText = "Submit Answer";
        
        // If we have problems after filtering, load the first one
        if (_filteredProblems.Count > 0)
        {
            LoadNextProblem();
        }
        else
        {
            // No problems match current filters
            CurrentQuestion = "No problems available for selected grade/subject combination.";
            SpockMessage = "Adjust filters to continue.";
        }
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
            // For free response, try exact match first
            var normalizedAnswer = answer.ToLowerInvariant();
            foreach (var correctAnswer in problem.Content.CorrectAnswers)
            {
                if (normalizedAnswer == correctAnswer.ToLowerInvariant())
                    return true;
            }
            
            // Smart parsing for natural language math answers
            // Extract all numbers from both user answer and correct answers
            var userNumbers = ExtractNumbers(normalizedAnswer);
            if (userNumbers.Count > 0)
            {
                foreach (var correctAnswer in problem.Content.CorrectAnswers)
                {
                    var correctNumbers = ExtractNumbers(correctAnswer.ToLowerInvariant());
                    
                    // If numbers match in same order, accept it
                    if (userNumbers.SequenceEqual(correctNumbers))
                        return true;
                    
                    // Special case: division with remainder
                    // Accept variations like "7 cells with 5 left", "7 per station and 5 leftover"
                    if (userNumbers.Count == 2 && correctNumbers.Count == 2)
                    {
                        if (userNumbers[0] == correctNumbers[0] && userNumbers[1] == correctNumbers[1])
                            return true;
                    }
                }
            }
        }
        
        return false;
    }
    
    private List<string> ExtractNumbers(string text)
    {
        // Extract all numbers including decimals and fractions
        var numbers = new List<string>();
        var matches = System.Text.RegularExpressions.Regex.Matches(text, @"\d+\.?\d*|\d+/\d+");
        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            numbers.Add(match.Value);
        }
        return numbers;
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
