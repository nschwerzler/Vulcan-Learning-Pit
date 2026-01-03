namespace Spock.Core.Models;

/// <summary>
/// Represents a complete learning session with problems, metrics, and approvals.
/// Sessions are analyzed for adaptive adjustments and parent dashboard insights.
/// </summary>
public class Session
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; set; } = string.Empty;
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public DateTime? EndTime { get; set; }
    public List<ProblemAttempt> Problems { get; set; } = new();
    public List<ApprovalEvent> Approvals { get; set; } = new();
    public SessionMetrics Metrics { get; set; } = new();
    public SessionEndReason? EndReason { get; set; }
}

/// <summary>
/// Aggregated metrics for a session used by adaptive engine and parent dashboard.
/// Tracks performance, focus, and learning progress.
/// </summary>
public class SessionMetrics
{
    public int TotalCorrect { get; set; }
    public int TotalAttempts { get; set; }                       // For calculating accuracy
    public double AverageTime { get; set; }
    public double FocusScore { get; set; }                       // 0-1, derived from consistency
    public List<string> DomainsVisited { get; set; } = new();
    public List<string> WeaknessesAddressed { get; set; } = new();
    public List<string> WeaknessesResolved { get; set; } = new();
    
    /// <summary>
    /// Game time earned this session in seconds. Tracks difficulty-based rewards:
    /// +1 second × difficulty per correct answer, -1 second per incorrect answer.
    /// </summary>
    public int TokensEarned { get; set; } = 0;
}

/// <summary>
/// Record of Spock's approval moments - the core motivation mechanism.
/// These are rare, data-based recognitions of genuine improvement.
/// </summary>
public class ApprovalEvent
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string SessionId { get; set; } = string.Empty;        // Session FK for persistence
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public ApprovalType Type { get; set; }
    public ApprovalIntensity Intensity { get; set; }
    public string Message { get; set; } = string.Empty;          // Spock's actual words
    public string Context { get; set; } = string.Empty;          // Skill or domain context
    public string? LinkedPriorApproval { get; set; }             // For narrative echoes
}
