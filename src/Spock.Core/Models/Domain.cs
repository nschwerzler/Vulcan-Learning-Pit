namespace Spock.Core.Models;

/// <summary>
/// Learning domains for adaptive problem selection
/// </summary>
public enum Domain
{
    Math,
    Logic,
    Reading,
    Science,
    Executive,
    WashingtonHistory,
    Bitcoin,
    Minecraft,
    Health
}

/// <summary>
/// Problem format types for ADD-friendly variety
/// </summary>
public enum ProblemFormat
{
    MultipleChoice,
    FreeResponse,
    Visual,
    Interactive
}

/// <summary>
/// Approval types for Spock's variable-ratio reinforcement
/// </summary>
public enum ApprovalType
{
    Streak,        // Triggered after 3-7 correct sequence
    Mastery,       // Triggered when weakness conquered
    RapidMastery   // Triggered by exceptional breakthrough (unlocks Vulcan insights)
}

/// <summary>
/// Intensity of approval display
/// </summary>
public enum ApprovalIntensity
{
    Subtle,      // For streak-based approvals
    Strong       // For mastery breakthroughs
}

/// <summary>
/// Reason a learning session ended
/// </summary>
public enum SessionEndReason
{
    StudentExit,   // Student chose to stop
    TimeLimit,     // Reached session length cap
    ForcedBreak,   // Parent-set break enforcement
    ParentEnd      // Parent manually ended session
}
