using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

/// <summary>
/// Tests for ApprovalEngine's variable-ratio reinforcement system.
/// Validates that approvals trigger correctly and maintain psychological effectiveness.
/// </summary>
[TestClass]
public class ApprovalEngineTests
{
    [TestMethod]
    [Timeout(5000)]
    public void Constructor_ShouldInitializeWithRandomThreshold()
    {
        // Arrange & Act
        var engine = new ApprovalEngine();

        // Assert - Psychological reasoning: Threshold must be 3-7 for variable-ratio pattern
        engine.CurrentThreshold.Should().BeInRange(3, 7);
        engine.CurrentStreak.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_CorrectAnswer_IncrementsStreak()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var problem = new ProblemAttempt { IsCorrect = true };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await engine.ProcessProblemAsync(problem, cts.Token);

        // Assert
        engine.CurrentStreak.Should().Be(1);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_IncorrectAnswer_ResetsStreak()
    {
        // Arrange
        var engine = new ApprovalEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Build up a streak
        await engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }, cts.Token);
        await engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }, cts.Token);
        
        engine.CurrentStreak.Should().Be(2);

        // Act - incorrect answer
        await engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = false }, cts.Token);

        // Assert - Psychological reasoning: Streak reset maintains variable-ratio effectiveness
        engine.CurrentStreak.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_ReachingThreshold_TriggersStreakApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var initialThreshold = engine.CurrentThreshold;
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - reach the threshold
        List<ApprovalEvent> approvals = new();
        for (int i = 0; i < initialThreshold; i++)
        {
            var result = await engine.ProcessProblemAsync(
                new ProblemAttempt { IsCorrect = true }, 
                cts.Token);
            approvals.AddRange(result);
        }

        // Assert - Motivation reasoning: Approval earned after variable-ratio threshold
        approvals.Should().ContainSingle();
        approvals[0].Type.Should().Be(ApprovalType.Streak);
        approvals[0].Intensity.Should().Be(ApprovalIntensity.Subtle);
        approvals[0].Message.Should().NotBeEmpty();
        engine.CurrentStreak.Should().Be(0); // Reset after approval
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_WeaknessMastered_TriggersStrongApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var problem = new ProblemAttempt
        {
            IsCorrect = true,
            WasWeakness = true,
            NowMastered = true
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var approvals = await engine.ProcessProblemAsync(problem, cts.Token);

        // Assert - Motivation reasoning: Mastery triggers strongest approval type
        approvals.Should().ContainSingle();
        approvals[0].Type.Should().Be(ApprovalType.Mastery);
        approvals[0].Intensity.Should().Be(ApprovalIntensity.Strong);
        approvals[0].Message.Should().NotBeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_WeaknessNotMastered_DoesNotTriggerMasteryApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var problem = new ProblemAttempt
        {
            IsCorrect = true,
            WasWeakness = true,
            NowMastered = false  // Still working on it
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var approvals = await engine.ProcessProblemAsync(problem, cts.Token);

        // Assert
        approvals.Should().NotContain(a => a.Type == ApprovalType.Mastery);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_MultipleCorrect_EventuallyTriggersApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        bool approvalTriggered = false;

        // Act - try up to 10 correct answers (well beyond max threshold of 7)
        for (int i = 0; i < 10; i++)
        {
            var approvals = await engine.ProcessProblemAsync(
                new ProblemAttempt { IsCorrect = true }, 
                cts.Token);
            
            if (approvals.Any())
            {
                approvalTriggered = true;
                break;
            }
        }

        // Assert - Psychological reasoning: Approval must trigger within 7 correct
        approvalTriggered.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_ThresholdResetsAfterApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var initialThreshold = engine.CurrentThreshold;
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - trigger first approval
        for (int i = 0; i < initialThreshold; i++)
        {
            await engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }, cts.Token);
        }

        var newThreshold = engine.CurrentThreshold;

        // Assert - Variable-ratio reasoning: New random threshold maintains unpredictability
        newThreshold.Should().BeInRange(3, 7);
        engine.CurrentStreak.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public void Reset_ShouldClearAllState()
    {
        // Arrange
        var engine = new ApprovalEngine();
        // Build some state
        engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }).Wait();

        // Act
        engine.Reset();

        // Assert - Session management reasoning: Clean state for new session
        engine.CurrentStreak.Should().Be(0);
        engine.CurrentThreshold.Should().BeInRange(3, 7);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_ApprovalMessages_AreDataBased()
    {
        // Arrange
        var engine = new ApprovalEngine();
        var initialThreshold = engine.CurrentThreshold;
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        List<ApprovalEvent> approvals = new();
        for (int i = 0; i < initialThreshold; i++)
        {
            var result = await engine.ProcessProblemAsync(
                new ProblemAttempt { IsCorrect = true }, 
                cts.Token);
            approvals.AddRange(result);
        }

        // Assert - Spock personality reasoning: Never generic praise like "good job"
        approvals[0].Message.Should().NotContain("good job");
        approvals[0].Message.Should().NotContain("great");
        approvals[0].Message.Should().NotContain("excellent");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessProblemAsync_CancellationToken_StopsProcessing()
    {
        // Arrange
        var engine = new ApprovalEngine();
        using var cts = new CancellationTokenSource();
        cts.Cancel(); // Cancel immediately

        // Act & Assert - Timeout safety reasoning: All async operations must respect cancellation
        await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () =>
        {
            await engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public void ApprovalTriggered_Event_FiresOnApproval()
    {
        // Arrange
        var engine = new ApprovalEngine();
        ApprovalEvent? capturedEvent = null;
        engine.ApprovalTriggered += (sender, e) => capturedEvent = e;
        var initialThreshold = engine.CurrentThreshold;
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - trigger approval
        for (int i = 0; i < initialThreshold; i++)
        {
            engine.ProcessProblemAsync(new ProblemAttempt { IsCorrect = true }, cts.Token).Wait();
        }

        // Assert - UI integration reasoning: Event allows decoupled UI updates
        capturedEvent.Should().NotBeNull();
        capturedEvent!.Type.Should().Be(ApprovalType.Streak);
    }
}
