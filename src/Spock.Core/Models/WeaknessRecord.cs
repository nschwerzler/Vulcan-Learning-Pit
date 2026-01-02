namespace Spock.Core.Models;

/// <summary>
/// Tracks a specific skill weakness for targeted remediation.
/// Weaknesses are addressed through disguised repetition across multiple domains.
/// </summary>
public class WeaknessRecord
{
    public string SkillId { get; set; } = string.Empty;
    public string SkillName { get; set; } = string.Empty;
    public DateTime FirstDetected { get; set; } = DateTime.UtcNow;
    public DateTime LastAttempt { get; set; } = DateTime.UtcNow;
    public WeaknessMetrics Metrics { get; set; } = new();
    public bool IsResolved { get; set; }
    public DateTime? ResolvedDate { get; set; }
}

/// <summary>
/// Detailed metrics for weakness detection and tracking.
/// Used by adaptive engine to determine mastery thresholds.
/// </summary>
public class WeaknessMetrics
{
    public double Accuracy { get; set; }                         // Current accuracy percentage
    public double AvgTime { get; set; }                          // Average time vs target
    public double Confidence { get; set; }                       // 1 - (answer_changes / attempts)
    public string ErrorPattern { get; set; } = "unknown";        // "conceptual", "procedural", "speed"
    public DateTime LastAttempt { get; set; } = DateTime.UtcNow; // Last time this skill was attempted
    public int DisguiseCount { get; set; }                       // How many different contexts shown
    public List<string> PresentedAs { get; set; } = new();       // Contexts where this was disguised
    public int TotalAttempts { get; set; }                       // Total problem attempts
}
