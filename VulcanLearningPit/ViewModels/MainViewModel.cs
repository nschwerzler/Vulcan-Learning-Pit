using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using VulcanLearningPit.Models;
using VulcanLearningPit.Services;

namespace VulcanLearningPit.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly SessionService _sessionService;
    private readonly DispatcherTimer _timer;
    private StudentProfile _currentStudent;
    private Problem? _currentProblem;
    private string _selectedAnswer = string.Empty;
    private int _timeRemaining;
    private bool _isSessionActive;
    private string _feedback = string.Empty;
    private string _mentorMessage = "Welcome, young scholar. Select a grade level to begin your training.";

    public MainViewModel()
    {
        var problemGenerator = new ProblemGeneratorService();
        var adaptiveService = new AdaptiveDifficultyService();
        _sessionService = new SessionService(problemGenerator, adaptiveService);

        _currentStudent = new StudentProfile { Name = "Student", Grade = GradeLevel.Grade5 };

        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;

        StartSessionCommand = new RelayCommand(_ => StartSession());
        SubmitAnswerCommand = new RelayCommand(_ => SubmitAnswer(), _ => CanSubmitAnswer());
        NextProblemCommand = new RelayCommand(_ => LoadNextProblem());
        SwitchSubjectCommand = new RelayCommand(param => SwitchSubject(param as SubjectType?));
        EndSessionCommand = new RelayCommand(_ => EndSession());

        AvailableGrades = new ObservableCollection<GradeLevel>
        {
            GradeLevel.Grade4, GradeLevel.Grade5, GradeLevel.Grade6,
            GradeLevel.Grade7, GradeLevel.Grade8
        };

        AvailableSubjects = new ObservableCollection<SubjectType>
        {
            SubjectType.Math, SubjectType.Logic, SubjectType.Reading, SubjectType.Science
        };
    }

    public ICommand StartSessionCommand { get; }
    public ICommand SubmitAnswerCommand { get; }
    public ICommand NextProblemCommand { get; }
    public ICommand SwitchSubjectCommand { get; }
    public ICommand EndSessionCommand { get; }

    public ObservableCollection<GradeLevel> AvailableGrades { get; }
    public ObservableCollection<SubjectType> AvailableSubjects { get; }

    public string StudentName
    {
        get => _currentStudent.Name;
        set
        {
            if (_currentStudent.Name != value)
            {
                _currentStudent.Name = value;
                OnPropertyChanged();
            }
        }
    }

    public GradeLevel SelectedGrade
    {
        get => _currentStudent.Grade;
        set
        {
            if (_currentStudent.Grade != value)
            {
                _currentStudent.Grade = value;
                OnPropertyChanged();
            }
        }
    }

    public int TotalTokens => _currentStudent.TotalTokens;
    public int TotalScore => _currentStudent.TotalScore;

    public string CurrentSubject => _sessionService.GetCurrentSubject().ToString();

    public string QuestionText => _currentProblem?.Question ?? "No question available";

    public string PassageText => (_currentProblem as ReadingProblem)?.Passage ?? string.Empty;

    public bool ShowPassage => _currentProblem is ReadingProblem;

    public ObservableCollection<string> AnswerOptions { get; } = new();

    public string SelectedAnswer
    {
        get => _selectedAnswer;
        set => SetProperty(ref _selectedAnswer, value);
    }

    public int TimeRemaining
    {
        get => _timeRemaining;
        set => SetProperty(ref _timeRemaining, value);
    }

    public bool IsSessionActive
    {
        get => _isSessionActive;
        set => SetProperty(ref _isSessionActive, value);
    }

    public string Feedback
    {
        get => _feedback;
        set => SetProperty(ref _feedback, value);
    }

    public string MentorMessage
    {
        get => _mentorMessage;
        set => SetProperty(ref _mentorMessage, value);
    }

    public string DifficultyDisplay
    {
        get
        {
            if (_currentProblem == null) return string.Empty;
            return $"Difficulty: {_currentProblem.Difficulty}";
        }
    }

    private void StartSession()
    {
        if (string.IsNullOrWhiteSpace(_currentStudent.Name))
        {
            MentorMessage = "You must enter your name before beginning, young one.";
            return;
        }

        _sessionService.StartSession(_currentStudent);
        IsSessionActive = true;
        MentorMessage = $"Excellent, {_currentStudent.Name}. Let us begin. Focus your mind and trust your knowledge.";
        LoadNextProblem();
    }

    private void LoadNextProblem()
    {
        Feedback = string.Empty;
        SelectedAnswer = string.Empty;

        _currentProblem = _sessionService.GetNextProblem();
        TimeRemaining = _currentProblem.TimeLimit;

        AnswerOptions.Clear();
        foreach (var option in _currentProblem.Options)
        {
            AnswerOptions.Add(option);
        }

        OnPropertyChanged(nameof(QuestionText));
        OnPropertyChanged(nameof(PassageText));
        OnPropertyChanged(nameof(ShowPassage));
        OnPropertyChanged(nameof(CurrentSubject));
        OnPropertyChanged(nameof(DifficultyDisplay));

        _timer.Start();
        MentorMessage = GetEncouragementMessage();
    }

    private void SubmitAnswer()
    {
        if (_currentProblem == null || string.IsNullOrWhiteSpace(SelectedAnswer))
            return;

        _timer.Stop();

        var attempt = _sessionService.SubmitAnswer(SelectedAnswer);

        if (attempt.IsCorrect)
        {
            Feedback = $"✓ Correct! +{attempt.PointsEarned} points, +{attempt.TokensEarned} tokens";
            MentorMessage = GetPraiseMessage(attempt.PointsEarned);
        }
        else
        {
            Feedback = $"✗ Incorrect. The correct answer was: {_currentProblem.CorrectAnswer}\n{_currentProblem.Explanation}";
            MentorMessage = GetEncouragementAfterMistake();
        }

        OnPropertyChanged(nameof(TotalTokens));
        OnPropertyChanged(nameof(TotalScore));
    }

    private void SwitchSubject(SubjectType? newSubject)
    {
        _sessionService.SwitchSubject(newSubject);
        MentorMessage = $"Switching to {_sessionService.GetCurrentSubject()}. Variety sharpens the mind.";
        LoadNextProblem();
    }

    private void EndSession()
    {
        _timer.Stop();
        _sessionService.EndSession();
        IsSessionActive = false;
        
        var session = _sessionService.GetCurrentSession();
        MentorMessage = $"Session complete, {_currentStudent.Name}. You have performed admirably. " +
                       $"Total Score: {_currentStudent.TotalScore}, Total Tokens: {_currentStudent.TotalTokens}";
        
        Feedback = string.Empty;
    }

    private bool CanSubmitAnswer() => IsSessionActive && !string.IsNullOrWhiteSpace(SelectedAnswer);

    private void Timer_Tick(object? sender, EventArgs e)
    {
        TimeRemaining--;

        if (TimeRemaining <= 0)
        {
            _timer.Stop();
            Feedback = "⏱ Time's up! Moving to next problem.";
            MentorMessage = "Speed and accuracy are both essential. Focus on both.";
        }
    }

    private string GetEncouragementMessage()
    {
        var messages = new[]
        {
            "Focus your mind. The answer lies within your knowledge.",
            "Take your time, but not too much. Think clearly.",
            "You have prepared for this. Trust your training.",
            "Remember: logic and reason will guide you to the truth.",
            "Consider all possibilities before choosing your answer."
        };
        return messages[new Random().Next(messages.Length)];
    }

    private string GetPraiseMessage(int points)
    {
        if (points >= 40)
            return "Outstanding! Your mastery grows with each answer.";
        else if (points >= 25)
            return "Well done. You demonstrate strong understanding.";
        else
            return "Correct. Continue to build on this foundation.";
    }

    private string GetEncouragementAfterMistake()
    {
        var messages = new[]
        {
            "Mistakes are the path to wisdom. Learn from this and proceed.",
            "Do not be discouraged. Each error teaches us something valuable.",
            "The greatest scholars were once students who failed many times.",
            "Difficulty is merely an opportunity to grow stronger."
        };
        return messages[new Random().Next(messages.Length)];
    }
}
