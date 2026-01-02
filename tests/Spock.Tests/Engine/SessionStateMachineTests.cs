using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

/// <summary>
/// Tests for SessionStateMachine's state transitions and safety enforcement.
/// Validates the session flow matches psychological/pedagogical requirements.
/// </summary>
[TestClass]
public class SessionStateMachineTests
{
    [TestMethod]
    [Timeout(5000)]
    public void Constructor_ShouldInitializeInInitializingState()
    {
        // Arrange & Act
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);

        // Assert - Session management reasoning: Start in known state
        stateMachine.CurrentState.Should().Be(SessionState.Initializing);
    }

    [TestMethod]
    [Timeout(5000)]
    public void Constructor_WithNullSession_ShouldThrow()
    {
        // Arrange, Act & Assert
        Action act = () => new SessionStateMachine(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_Start_TransitionsFromInitializingToProblemPresentation()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.ProblemPresentation);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_ProblemFlow_TransitionsThroughNormalSequence()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act & Assert - Pedagogical reasoning: Normal flow should be smooth
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        stateMachine.CurrentState.Should().Be(SessionState.ProblemPresentation);

        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);
        stateMachine.CurrentState.Should().Be(SessionState.AwaitingInput);

        await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        stateMachine.CurrentState.Should().Be(SessionState.Evaluating);

        await stateMachine.FireAsync(SessionTrigger.AnswerEvaluated, cts.Token);
        stateMachine.CurrentState.Should().Be(SessionState.Feedback);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_ApprovalPath_TransitionsToApprovalMoment()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Get to Feedback state
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.AnswerEvaluated, cts.Token);

        // Act - Motivation reasoning: Approval is special path
        await stateMachine.FireAsync(SessionTrigger.ApprovalTriggered, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.ApprovalMoment);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_TopicSwitch_TransitionsToSwitchingTopic()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Get to Feedback state
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.AnswerEvaluated, cts.Token);

        // Act - ADD-aware reasoning: Topic switching is key mechanism
        await stateMachine.FireAsync(SessionTrigger.TopicSwitchNeeded, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.SwitchingTopic);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_StudentExit_TransitionsToSessionComplete()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);

        // Act - Safety reasoning: Student can exit anytime
        await stateMachine.FireAsync(SessionTrigger.StudentExit, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.SessionComplete);
        session.EndTime.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_TimeLimit_TransitionsToForcedBreak()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);

        // Act - Safety reasoning: Hard time limits prevent overuse
        await stateMachine.FireAsync(SessionTrigger.TimeLimit, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.ForcedBreak);
        session.EndTime.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_InvalidTransition_ShouldThrow()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act & Assert - State machine reasoning: Invalid transitions must fail fast
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
        {
            await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public void CanFire_ValidTrigger_ReturnsTrue()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);

        // Act & Assert
        stateMachine.CanFire(SessionTrigger.Start).Should().BeTrue();
        stateMachine.CanFire(SessionTrigger.StudentSubmitted).Should().BeFalse();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetPermittedTriggersAsync_ReturnsAllowedTransitions()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var permitted = (await stateMachine.GetPermittedTriggersAsync(cts.Token)).ToList();

        // Assert - State machine reasoning: Transparency about allowed actions
        permitted.Should().Contain(SessionTrigger.Start);
        permitted.Should().NotBeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task CheckSafetyLimitsAsync_WithinLimit_ReturnsFalse()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        var parentSettings = new ParentSettings { SessionLengthCap = 20 }; // 20 minutes
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);

        // Act - just started, should be within limit
        var limitReached = await stateMachine.CheckSafetyLimitsAsync(parentSettings, cts.Token);

        // Assert - Safety reasoning: Early in session, no break needed
        limitReached.Should().BeFalse();
        stateMachine.CurrentState.Should().NotBe(SessionState.ForcedBreak);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task StateChanged_Event_FiresOnTransition()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        SessionState? capturedState = null;
        stateMachine.StateChanged += (sender, state) => capturedState = state;
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);

        // Assert - UI integration reasoning: Events enable decoupled updates
        capturedState.Should().Be(SessionState.ProblemPresentation);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_CancellationToken_ThrowsOnCancel()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert - Timeout safety reasoning: All async operations must respect cancellation
        await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () =>
        {
            await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_ApprovalComplete_ReturnsToProblems()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Navigate to approval moment
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.AnswerEvaluated, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ApprovalTriggered, cts.Token);

        // Act - Motivation reasoning: After approval, return to learning
        await stateMachine.FireAsync(SessionTrigger.ApprovalComplete, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.ProblemPresentation);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task FireAsync_TopicSwitchComplete_ReturnsToProblems()
    {
        // Arrange
        var session = new Session { StudentId = "test-student" };
        var stateMachine = new SessionStateMachine(session);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Navigate to topic switch
        await stateMachine.FireAsync(SessionTrigger.Start, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.ProblemReady, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.StudentSubmitted, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.AnswerEvaluated, cts.Token);
        await stateMachine.FireAsync(SessionTrigger.TopicSwitchNeeded, cts.Token);

        // Act - ADD-aware reasoning: After switch, present new domain
        await stateMachine.FireAsync(SessionTrigger.TopicSwitchComplete, cts.Token);

        // Assert
        stateMachine.CurrentState.Should().Be(SessionState.ProblemPresentation);
    }

    [TestMethod]
    [Timeout(5000)]
    public void Session_Property_ReturnsOriginalSession()
    {
        // Arrange
        var session = new Session { StudentId = "test-student", Id = "session-123" };
        var stateMachine = new SessionStateMachine(session);

        // Act & Assert - Data integrity reasoning: State machine tracks same session
        stateMachine.Session.Should().BeSameAs(session);
        stateMachine.Session.Id.Should().Be("session-123");
    }
}
