namespace Spock.Core.Models;

/// <summary>
/// Represents a single learning problem with content, difficulty, and metadata.
/// Problems are selected by the adaptive engine based on weakness patterns and mastery levels.
/// </summary>
public class Problem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public Domain Domain { get; set; }
    public string MicroTopic { get; set; } = string.Empty;       // e.g., "fractions-addition", "deductive-chains"
    public int Difficulty { get; set; }                          // 1-10 scale
    public int TargetTime { get; set; }                          // Expected completion time in seconds
    public ProblemContent Content { get; set; } = new();
    public ProblemMetadata Metadata { get; set; } = new();
}

/// <summary>
/// The actual problem content shown to the student
/// </summary>
public class ProblemContent
{
    public string Question { get; set; } = string.Empty;
    public ProblemFormat Format { get; set; }
    public List<string> Options { get; set; } = new();           // For multiple choice
    public List<string> CorrectAnswers { get; set; } = new();    // Can have multiple correct answers
}

/// <summary>
/// Metadata for adaptive engine's problem selection logic.
/// Tracks prerequisites, weakness disguises, and preview status.
/// </summary>
public class ProblemMetadata
{
    public string? DisguisedWeakness { get; set; }               // If targeting weakness in different context
    public bool IsPreview { get; set; }                          // Testing readiness for next level
    public List<string> ConceptualPrereqs { get; set; } = new(); // Required prior skills
}

/// <summary>
/// Record of a student's attempt at solving a problem.
/// Tracks correctness, time taken, and confidence indicators.
/// </summary>
public class ProblemAttempt
{
    public string ProblemId { get; set; } = string.Empty;
    public DateTime AttemptTime { get; set; } = DateTime.UtcNow;
    public bool IsCorrect { get; set; }
    public int TimeSpentSeconds { get; set; }
    public List<string> GivenAnswers { get; set; } = new();     // Student's answer(s)
    public int AnswerChanges { get; set; }                      // Number of times answer was changed
    public bool WasWeakness { get; set; }                       // Was this addressing a known weakness?
    public bool NowMastered { get; set; }                       // Did this complete mastery of a weakness?
}
