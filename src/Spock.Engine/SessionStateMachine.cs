using Spock.Core.Models;
using Stateless;

namespace Spock.Engine;

/// <summary>
/// Manages the state machine for a student learning session.
/// Implements the session flow: Initialize -> Problem -> Input -> Evaluate -> Feedback -> (Approval?) -> Next
/// Uses Stateless library for robust state management with safety guards.
/// </summary>
public class SessionStateMachine
{
    private readonly StateMachine<SessionState, SessionTrigger> _machine;
    private readonly Session _session;
    private DateTime _sessionStartTime;
    private readonly object _lock = new();

    /// <summary>
    /// Event fired when state changes (for logging/UI updates)
    /// </summary>
    public event EventHandler<SessionState>? StateChanged;

    /// <summary>
    /// Gets the current session state
    /// </summary>
    public SessionState CurrentState => _machine.State;

    /// <summary>
    /// Gets the session being managed
    /// </summary>
    public Session Session => _session;

    public SessionStateMachine(Session session)
    {
        _session = session ?? throw new ArgumentNullException(nameof(session));
        _machine = new StateMachine<SessionState, SessionTrigger>(SessionState.Initializing);
        
        ConfigureStateMachine();
        _sessionStartTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Configures all state transitions according to specification.
    /// Psychological reasoning: Clear state flow prevents confusion and ensures safety limits.
    /// </summary>
    private void ConfigureStateMachine()
    {
        // INITIALIZING -> PROBLEM_PRESENTATION
        _machine.Configure(SessionState.Initializing)
            .Permit(SessionTrigger.Start, SessionState.ProblemPresentation)
            .OnEntry(() => OnStateEntered(SessionState.Initializing));

        // PROBLEM_PRESENTATION -> AWAITING_INPUT (automatic)
        _machine.Configure(SessionState.ProblemPresentation)
            .Permit(SessionTrigger.ProblemReady, SessionState.AwaitingInput)
            .PermitReentry(SessionTrigger.Continue) // Allow same state for problem refresh
            .OnEntry(() => OnStateEntered(SessionState.ProblemPresentation));

        // AWAITING_INPUT -> EVALUATING (on submission)
        _machine.Configure(SessionState.AwaitingInput)
            .Permit(SessionTrigger.StudentSubmitted, SessionState.Evaluating)
            .OnEntry(() => OnStateEntered(SessionState.AwaitingInput));

        // EVALUATING -> FEEDBACK (always)
        _machine.Configure(SessionState.Evaluating)
            .Permit(SessionTrigger.AnswerEvaluated, SessionState.Feedback)
            .OnEntry(() => OnStateEntered(SessionState.Evaluating));

        // FEEDBACK -> APPROVAL_MOMENT | SWITCHING_TOPIC | PROBLEM_PRESENTATION
        _machine.Configure(SessionState.Feedback)
            .Permit(SessionTrigger.ApprovalTriggered, SessionState.ApprovalMoment)
            .Permit(SessionTrigger.TopicSwitchNeeded, SessionState.SwitchingTopic)
            .Permit(SessionTrigger.Continue, SessionState.ProblemPresentation)
            .OnEntry(() => OnStateEntered(SessionState.Feedback));

        // APPROVAL_MOMENT -> PROBLEM_PRESENTATION
        _machine.Configure(SessionState.ApprovalMoment)
            .Permit(SessionTrigger.ApprovalComplete, SessionState.ProblemPresentation)
            .OnEntry(() => OnStateEntered(SessionState.ApprovalMoment));

        // SWITCHING_TOPIC -> PROBLEM_PRESENTATION
        _machine.Configure(SessionState.SwitchingTopic)
            .Permit(SessionTrigger.TopicSwitchComplete, SessionState.ProblemPresentation)
            .OnEntry(() => OnStateEntered(SessionState.SwitchingTopic));

        // SESSION_COMPLETE (terminal state)
        _machine.Configure(SessionState.SessionComplete)
            .OnEntry(() => OnStateEntered(SessionState.SessionComplete));

        // FORCED_BREAK (terminal state)
        _machine.Configure(SessionState.ForcedBreak)
            .OnEntry(() => OnStateEntered(SessionState.ForcedBreak));

        // Global transitions from any state
        _machine.Configure(SessionState.AwaitingInput)
            .Permit(SessionTrigger.TimeLimit, SessionState.ForcedBreak)
            .Permit(SessionTrigger.StudentExit, SessionState.SessionComplete)
            .Permit(SessionTrigger.ParentEnd, SessionState.SessionComplete)
            .Permit(SessionTrigger.BreakRequired, SessionState.ForcedBreak);

        _machine.Configure(SessionState.ProblemPresentation)
            .Permit(SessionTrigger.TimeLimit, SessionState.ForcedBreak)
            .Permit(SessionTrigger.StudentExit, SessionState.SessionComplete)
            .Permit(SessionTrigger.ParentEnd, SessionState.SessionComplete);

        _machine.Configure(SessionState.Feedback)
            .Permit(SessionTrigger.TimeLimit, SessionState.ForcedBreak)
            .Permit(SessionTrigger.StudentExit, SessionState.SessionComplete)
            .Permit(SessionTrigger.ParentEnd, SessionState.SessionComplete);
    }

    /// <summary>
    /// Fires a trigger to transition state.
    /// Thread-safe with timeout support via CancellationToken.
    /// </summary>
    /// <param name="trigger">The trigger to fire</param>
    /// <param name="cancellationToken">Cancellation token for timeout support</param>
    public async Task FireAsync(SessionTrigger trigger, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            lock (_lock)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                if (_machine.CanFire(trigger))
                {
                    _machine.Fire(trigger);
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Cannot fire trigger {trigger} in state {_machine.State}");
                }
            }
        }, cancellationToken);
    }

    /// <summary>
    /// Checks if a trigger can be fired from current state.
    /// </summary>
    public bool CanFire(SessionTrigger trigger)
    {
        lock (_lock)
        {
            return _machine.CanFire(trigger);
        }
    }

    /// <summary>
    /// Checks safety limits and auto-transitions to break/complete states.
    /// Called periodically to enforce parent settings.
    /// </summary>
    /// <param name="parentSettings">Parent-configured limits</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task<bool> CheckSafetyLimitsAsync(
        ParentSettings parentSettings,
        CancellationToken cancellationToken = default)
    {
        var elapsed = DateTime.UtcNow - _sessionStartTime;
        
        // Check session length cap
        if (elapsed.TotalMinutes >= parentSettings.SessionLengthCap)
        {
            if (CanFire(SessionTrigger.TimeLimit))
            {
                await FireAsync(SessionTrigger.TimeLimit, cancellationToken);
                _session.EndReason = SessionEndReason.TimeLimit;
                return true; // Session ended
            }
        }

        return false; // Session continues
    }

    /// <summary>
    /// Called when entering a new state. Updates session tracking and fires event.
    /// </summary>
    private void OnStateEntered(SessionState state)
    {
        StateChanged?.Invoke(this, state);

        // Update session end time when reaching terminal states
        if (state == SessionState.SessionComplete || state == SessionState.ForcedBreak)
        {
            _session.EndTime = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// Gets permitted triggers from current state (for debugging/UI)
    /// </summary>
    public async Task<IEnumerable<SessionTrigger>> GetPermittedTriggersAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<SessionTrigger> triggers;
        lock (_lock)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            triggers = _machine.PermittedTriggers;
#pragma warning restore CS0618 // Type or member is obsolete
        }
        return await Task.FromResult(triggers);
    }
}
