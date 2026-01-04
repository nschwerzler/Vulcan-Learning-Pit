namespace Spock.Core.Models;

/// <summary>
/// Represents a student's profile including current levels, weaknesses, and history.
/// Core entity for tracking learning progress and personalizing experience.
/// </summary>
public class StudentProfile
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;              // Student name for identification
    public int Age { get; set; }
    public Domain CurrentDomain { get; set; } = Domain.Math;      // Current active learning domain
    public CurrentLevel Level { get; set; } = new();
    public List<WeaknessRecord> Weaknesses { get; set; } = new();
    public List<ApprovalEvent> ApprovalHistory { get; set; } = new();
    public List<Session> SessionHistory { get; set; } = new();
    public StudentPreferences Preferences { get; set; } = new();
    public ParentSettings ParentSettings { get; set; } = new();
    
    /// <summary>
    /// Game time earned in seconds. Earned at rate of: 1 second × problem difficulty level.
    /// Penalty: -1 second per incorrect answer (minimum 0 seconds total).
    /// Display format: "2m 15s" or "1h 3m"
    /// </summary>
    public int GameTokenSeconds { get; set; } = 0;  // Start at 0 seconds
}

/// <summary>
/// Current achievement level across all domains
/// </summary>
public class CurrentLevel
{
    public string Math { get; set; } = "Grade 4";        // e.g., "Grade 5" or "High School Algebra"
    public int Logic { get; set; } = 1;                  // 1-10 adaptive scale
    public string Reading { get; set; } = "Grade 4";
    public string Science { get; set; } = "Grade 4";
    public List<Domain> UnlockedDomains { get; set; } = new() { Domain.Math, Domain.Reading };  // Domains available for learning
}

/// <summary>
/// Student preferences for personalizing content and pacing.
/// Used for ADD-friendly engagement optimization.
/// </summary>
public class StudentPreferences
{
    public List<string> ReadingGenres { get; set; } = new();  // Sci-fi, mystery, tactical
    public int FocusDuration { get; set; } = 10;              // Typical sustained attention (minutes)
}

/// <summary>
/// Parent-configured safety and control settings.
/// Ensures healthy usage patterns and prevents overuse.
/// </summary>
public class ParentSettings
{
    public int SessionLengthCap { get; set; } = 20;           // Maximum minutes per session
    public int MaxSessionsPerDay { get; set; } = 3;           // Daily session limit
    public bool AccelerationAllowed { get; set; } = true;     // Can system auto-advance levels?
    public bool DashboardNotifications { get; set; } = true;  // Parent alerts for milestones
}
