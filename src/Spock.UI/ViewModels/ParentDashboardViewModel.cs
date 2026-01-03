using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Spock.Core.Models;

namespace Spock.UI.ViewModels;

/// <summary>
/// ViewModel for Parent Dashboard with real-time metrics and analytics.
/// Implements psychological safety principles: data for support, not judgment.
/// </summary>
public class ParentDashboardViewModel : INotifyPropertyChanged
{
    private int _sessionsThisWeek;
    private double _averageAccuracy;
    private double _focusScore;
    private int _weaknessesResolved;
    private int _sessionLengthCap = 20;
    private int _maxSessionsPerDay = 3;
    private bool _accelerationAllowed = true;
    private bool _dashboardNotifications = true;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ParentDashboardViewModel()
    {
        // Initialize commands
        RefreshCommand = new RelayCommand(RefreshData);
        SettingsCommand = new RelayCommand(OpenSettings);
        SaveSettingsCommand = new RelayCommand(SaveSettings);

        // Load initial data
        LoadDashboardData();
    }

    #region Properties

    public int SessionsThisWeek
    {
        get => _sessionsThisWeek;
        set => SetProperty(ref _sessionsThisWeek, value);
    }

    public string SessionsChange => "+2 from last week";

    public double AverageAccuracy
    {
        get => _averageAccuracy;
        set => SetProperty(ref _averageAccuracy, value);
    }

    public string AccuracyChange => "+5% from last week";

    public double FocusScore
    {
        get => _focusScore;
        set => SetProperty(ref _focusScore, value);
    }

    public int WeaknessesResolved
    {
        get => _weaknessesResolved;
        set => SetProperty(ref _weaknessesResolved, value);
    }

    public ObservableCollection<SessionSummary> RecentSessions { get; } = new();
    public ObservableCollection<WeaknessSummary> ActiveWeaknesses { get; } = new();
    public ObservableCollection<WeaknessSummary> RecentConquests { get; } = new();

    // Domain Progress
    public double MathProgress => 65;
    public string MathLevel => "Grade 5 - Fractions & Decimals";

    public double LogicProgress => 80;
    public string LogicLevel => "Level 6 - Deductive Reasoning";

    public double ReadingProgress => 55;
    public string ReadingLevel => "Grade 4 - Inference & Analysis";

    public double ScienceProgress => 40;
    public string ScienceLevel => "Grade 4 - Hypothesis Testing";

    // Settings
    public int SessionLengthCap
    {
        get => _sessionLengthCap;
        set => SetProperty(ref _sessionLengthCap, value);
    }

    public int MaxSessionsPerDay
    {
        get => _maxSessionsPerDay;
        set => SetProperty(ref _maxSessionsPerDay, value);
    }

    public bool AccelerationAllowed
    {
        get => _accelerationAllowed;
        set => SetProperty(ref _accelerationAllowed, value);
    }

    public bool DashboardNotifications
    {
        get => _dashboardNotifications;
        set => SetProperty(ref _dashboardNotifications, value);
    }

    #endregion

    #region Commands

    public ICommand RefreshCommand { get; }
    public ICommand SettingsCommand { get; }
    public ICommand SaveSettingsCommand { get; }

    #endregion

    #region Methods

    private void LoadDashboardData()
    {
        // Load sample data - in production, this would query the database
        SessionsThisWeek = 8;
        AverageAccuracy = 78.5;
        FocusScore = 7.2;
        WeaknessesResolved = 3;

        // Recent sessions
        RecentSessions.Add(new SessionSummary
        {
            StartTime = DateTime.Now.AddHours(-2),
            ProblemsCompleted = 12,
            Accuracy = 83.3,
            DomainsVisited = "Math, Logic",
            Duration = "14 min",
            ApprovalsReceived = 2
        });

        RecentSessions.Add(new SessionSummary
        {
            StartTime = DateTime.Now.AddDays(-1),
            ProblemsCompleted = 15,
            Accuracy = 80.0,
            DomainsVisited = "Math, Reading, Science",
            Duration = "18 min",
            ApprovalsReceived = 1
        });

        RecentSessions.Add(new SessionSummary
        {
            StartTime = DateTime.Now.AddDays(-2),
            ProblemsCompleted = 10,
            Accuracy = 70.0,
            DomainsVisited = "Math, Logic",
            Duration = "12 min",
            ApprovalsReceived = 0
        });

        // Active weaknesses
        ActiveWeaknesses.Add(new WeaknessSummary
        {
            SkillName = "Fraction Addition",
            Accuracy = 62.5,
            AttemptsCount = 8,
            ErrorPattern = "Conceptual - denominator confusion"
        });

        ActiveWeaknesses.Add(new WeaknessSummary
        {
            SkillName = "Reading Inference",
            Accuracy = 66.7,
            AttemptsCount = 6,
            ErrorPattern = "Procedural - missing context clues"
        });

        ActiveWeaknesses.Add(new WeaknessSummary
        {
            SkillName = "Pattern Recognition",
            Accuracy = 71.4,
            AttemptsCount = 7,
            ErrorPattern = "Speed - rushing through analysis"
        });

        // Recent conquests
        RecentConquests.Add(new WeaknessSummary
        {
            SkillName = "Multiplication Fluency",
            FinalAccuracy = 92.0,
            MasteredDate = DateTime.Now.AddDays(-5)
        });

        RecentConquests.Add(new WeaknessSummary
        {
            SkillName = "Deductive Chains",
            FinalAccuracy = 94.5,
            MasteredDate = DateTime.Now.AddDays(-12)
        });

        RecentConquests.Add(new WeaknessSummary
        {
            SkillName = "Variable Identification",
            FinalAccuracy = 90.0,
            MasteredDate = DateTime.Now.AddDays(-18)
        });
    }

    private void RefreshData()
    {
        // Reload dashboard data
        RecentSessions.Clear();
        ActiveWeaknesses.Clear();
        RecentConquests.Clear();
        LoadDashboardData();
    }

    private void OpenSettings()
    {
        // Navigate to settings tab (handled by TabControl in UI)
    }

    private void SaveSettings()
    {
        // Save parent settings to database
        // In production, this would update the StudentProfile.ParentSettings
        System.Windows.MessageBox.Show(
            "Settings saved successfully!\n\n" +
            $"Session Length Cap: {SessionLengthCap} min\n" +
            $"Max Sessions Per Day: {MaxSessionsPerDay}\n" +
            $"Acceleration: {(AccelerationAllowed ? "Enabled" : "Disabled")}\n" +
            $"Notifications: {(DashboardNotifications ? "Enabled" : "Disabled")}",
            "Settings Saved",
            System.Windows.MessageBoxButton.OK,
            System.Windows.MessageBoxImage.Information);
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
}

/// <summary>
/// Summary data for a learning session displayed in the dashboard.
/// </summary>
public class SessionSummary
{
    public DateTime StartTime { get; set; }
    public int ProblemsCompleted { get; set; }
    public double Accuracy { get; set; }
    public string DomainsVisited { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public int ApprovalsReceived { get; set; }
}

/// <summary>
/// Summary data for skill weaknesses and mastery.
/// </summary>
public class WeaknessSummary
{
    public string SkillName { get; set; } = string.Empty;
    public double Accuracy { get; set; }
    public int AttemptsCount { get; set; }
    public string ErrorPattern { get; set; } = string.Empty;
    public double FinalAccuracy { get; set; }
    public DateTime MasteredDate { get; set; }
}
