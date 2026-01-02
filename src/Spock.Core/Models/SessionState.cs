namespace Spock.Core.Models;

/// <summary>
/// Session state enumeration matching the state machine specification.
/// Tracks the current phase of a student's learning session.
/// </summary>
public enum SessionState
{
    Initializing,        // Loading student profile, recent history
    ProblemPresentation, // Showing current problem
    AwaitingInput,       // Student working (timer running)
    Evaluating,          // Checking answer, updating metrics
    Feedback,            // Showing Spock response
    SwitchingTopic,      // Transitioning domains
    ApprovalMoment,      // Rare approval sequence
    SessionComplete,     // Wrap-up, save state
    ForcedBreak          // Parent-set limit reached
}

/// <summary>
/// Triggers that cause state transitions in the session state machine.
/// </summary>
public enum SessionTrigger
{
    Start,               // Begin session
    ProblemReady,        // Problem loaded and ready to display
    StudentSubmitted,    // Student submitted answer
    AnswerEvaluated,     // Evaluation complete
    ApprovalTriggered,   // Approval condition met
    ApprovalComplete,    // Approval display finished
    TopicSwitchNeeded,   // Domain switch required
    TopicSwitchComplete, // Switch complete
    Continue,            // Continue to next problem
    TimeLimit,           // Session time limit reached
    StudentExit,         // Student chose to exit
    ParentEnd,           // Parent ended session
    BreakRequired        // Forced break triggered
}
