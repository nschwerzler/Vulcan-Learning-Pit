using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.UI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ApprovalEngine _approvalEngine;
    private readonly SpockDialogueEngine _dialogueEngine;
    private readonly WeaknessTracker _weaknessTracker;
    private readonly Random _random = new();
    
    // Sample problems for demo
    private readonly List<Problem> _problemBank;
    private int _currentProblemIndex = 0;
    
    private string _currentQuestion = "";
    private string _userAnswer = "";
    private string _spockMessage = "Ready to begin.";
    private int _correctStreak = 0;
    private int _totalAttempts = 0;
    private int _correctAnswers = 0;
    private bool _isAnswerSubmitted = false;
    private string _feedbackMessage = "";
    private string _submitButtonText = "Submit Answer";

    public MainViewModel()
    {
        _approvalEngine = new ApprovalEngine();
        _dialogueEngine = new SpockDialogueEngine();
        _weaknessTracker = new WeaknessTracker();
        
        // Initialize sample problems
        _problemBank = CreateSampleProblems();
        
        // Commands
        SubmitCommand = new RelayCommand(async () => await SubmitAnswerAsync(), () => !string.IsNullOrWhiteSpace(UserAnswer));
        NextProblemCommand = new RelayCommand(LoadNextProblem, () => _isAnswerSubmitted);
        
        // Load first problem
        LoadNextProblem();
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

    public double AccuracyPercentage => TotalAttempts > 0 ? (CorrectAnswers * 100.0 / TotalAttempts) : 0;

    public ICommand SubmitCommand { get; }
    public ICommand NextProblemCommand { get; }

    private async Task SubmitAnswerAsync()
    {
        if (IsAnswerSubmitted) return;

        var currentProblem = _problemBank[_currentProblemIndex];
        var isCorrect = CheckAnswer(currentProblem, UserAnswer);
        
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
            FeedbackMessage = $"✗ Incorrect. The answer was: {currentProblem.Content.CorrectAnswers.First()}";
        }
        
        OnPropertyChanged(nameof(AccuracyPercentage));

        // Process through approval engine
        var problemAttempt = new ProblemAttempt
        {
            ProblemId = currentProblem.Id,
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
                    currentProblem.MicroTopic,
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
                currentProblem.MicroTopic,
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
    }

    private void LoadNextProblem()
    {
        IsAnswerSubmitted = false;
        SubmitButtonText = "Submit Answer";
        UserAnswer = "";
        FeedbackMessage = "";
        
        // Cycle through problems
        _currentProblemIndex = (_currentProblemIndex + 1) % _problemBank.Count;
        var problem = _problemBank[_currentProblemIndex];
        
        CurrentQuestion = FormatProblem(problem);
        
        if (!IsAnswerSubmitted)
        {
            var response = _dialogueEngine.GetNeutralDialogueAsync(CancellationToken.None).Result;
            SpockMessage = response.Message;
        }
        
        ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
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
        
        answer = answer.Trim().ToLowerInvariant();
        
        foreach (var correctAnswer in problem.Content.CorrectAnswers)
        {
            if (answer == correctAnswer.ToLowerInvariant())
                return true;
        }
        
        return false;
    }

    private List<Problem> CreateSampleProblems()
    {
        return new List<Problem>
        {
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Math,
                MicroTopic = "fractions-addition",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What is 1/4 + 1/4?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1/2", "0.5", "2/4" }
                }
            },
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Logic,
                MicroTopic = "deductive-reasoning",
                Difficulty = 4,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "If all Vulcans are logical, and Spock is a Vulcan, what can we conclude?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string>
                    {
                        "Spock is logical",
                        "Spock is not logical",
                        "We cannot conclude anything",
                        "All logical beings are Vulcans"
                    },
                    CorrectAnswers = new List<string> { "A", "Spock is logical" }
                }
            },
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Math,
                MicroTopic = "multiplication",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What is 7 × 8?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "56" }
                }
            },
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Logic,
                MicroTopic = "pattern-recognition",
                Difficulty = 3,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Complete the sequence: 2, 4, 8, 16, ?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "32" }
                }
            },
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Math,
                MicroTopic = "percentages",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What is 25% of 80?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20" }
                }
            },
            new Problem
            {
                Id = Guid.NewGuid().ToString(),
                Domain = Domain.Science,
                MicroTopic = "scientific-method",
                Difficulty = 5,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "A scientist observes that plants grow faster in sunlight. To test if sunlight causes growth, what should they control?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string>
                    {
                        "Water, soil, temperature",
                        "Only the amount of sunlight",
                        "Nothing - just observe",
                        "The color of the plants"
                    },
                    CorrectAnswers = new List<string> { "A", "Water, soil, temperature" }
                }
            }
        };
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
