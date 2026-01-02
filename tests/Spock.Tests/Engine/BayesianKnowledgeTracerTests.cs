using FluentAssertions;
using Spock.Engine;

namespace Spock.Tests.Engine;

[TestClass]
public class BayesianKnowledgeTracerTests
{
    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateSkillAsync_NewSkill_InitializesWithPrior()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var probability = await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);

        // Assert
        probability.Should().BeGreaterThan(0.1, "correct answer should increase from prior");
        probability.Should().BeLessThan(1.0, "single correct not enough for full mastery");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateSkillAsync_MultipleCorrect_IncreasesMastery()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - simulate streak of 5 correct answers
        double lastProb = 0;
        for (int i = 0; i < 5; i++)
        {
            lastProb = await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        }

        // Assert
        lastProb.Should().BeGreaterThan(0.5, "multiple correct answers should significantly increase mastery");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateSkillAsync_IncorrectAnswer_DecreasesMastery()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Build up some mastery first
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        var highProb = await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);

        // Act - incorrect answer
        var afterIncorrect = await bkt.UpdateSkillAsync("fractions-add", wasCorrect: false, cts.Token);

        // Assert
        afterIncorrect.Should().BeLessThan(highProb, "incorrect answer should decrease mastery probability");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateSkillAsync_ConvergesToMastery_WithConsistentCorrect()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - simulate 15 correct answers in a row
        double finalProb = 0;
        for (int i = 0; i < 15; i++)
        {
            finalProb = await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        }

        // Assert
        finalProb.Should().BeGreaterThan(0.9, "consistent correct performance should approach mastery");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetMasteryProbabilityAsync_UnknownSkill_ReturnsPrior()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var probability = await bkt.GetMasteryProbabilityAsync("never-seen", cts.Token);

        // Assert
        probability.Should().Be(0.1, "unknown skills should return default prior P(L0)");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetMasteryProbabilityAsync_KnownSkill_ReturnsCurrentEstimate()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);

        // Act
        var probability = await bkt.GetMasteryProbabilityAsync("fractions-add", cts.Token);

        // Assert
        probability.Should().BeGreaterThan(0.1, "should reflect updated estimate");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task IsMasteredAsync_BelowThreshold_ReturnsFalse()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);

        // Act
        var isMastered = await bkt.IsMasteredAsync("fractions-add", threshold: 0.95, cts.Token);

        // Assert
        isMastered.Should().BeFalse("single correct not enough for 0.95 threshold");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task IsMasteredAsync_AboveThreshold_ReturnsTrue()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Build to mastery
        for (int i = 0; i < 20; i++)
        {
            await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        }

        // Act
        var isMastered = await bkt.IsMasteredAsync("fractions-add", threshold: 0.95, cts.Token);

        // Assert
        isMastered.Should().BeTrue("20 consecutive correct should exceed 0.95 threshold");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task IsMasteredAsync_UnknownSkill_ReturnsFalse()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var isMastered = await bkt.IsMasteredAsync("never-seen", cancellationToken: cts.Token);

        // Assert
        isMastered.Should().BeFalse("unknown skills are not mastered");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetAllMasteryEstimatesAsync_ReturnsAllSkills()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("decimals-multiply", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("algebra-solve", wasCorrect: false, cts.Token);

        // Act
        var estimates = await bkt.GetAllMasteryEstimatesAsync(cts.Token);

        // Assert
        estimates.Should().HaveCount(3);
        estimates.Should().ContainKey("fractions-add");
        estimates.Should().ContainKey("decimals-multiply");
        estimates.Should().ContainKey("algebra-solve");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSkillStateAsync_ReturnsDetailedState()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("fractions-add", wasCorrect: false, cts.Token);

        // Act
        var state = await bkt.GetSkillStateAsync("fractions-add", cts.Token);

        // Assert
        state.Should().NotBeNull();
        state!.SkillId.Should().Be("fractions-add");
        state.TotalAttempts.Should().Be(3);
        state.CorrectAttempts.Should().Be(2);
        state.ProbabilityKnown.Should().BeGreaterThan(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSkillStateAsync_UnknownSkill_ReturnsNull()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var state = await bkt.GetSkillStateAsync("never-seen", cts.Token);

        // Assert
        state.Should().BeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SetParametersAsync_AdjustsBKTParameters()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - set custom parameters for difficult skill
        await bkt.SetParametersAsync("calculus-limits", pl0: 0.05, pt: 0.1, ps: 0.2, pg: 0.15, cts.Token);
        var state = await bkt.GetSkillStateAsync("calculus-limits", cts.Token);

        // Assert
        state.Should().NotBeNull();
        state!.PL0.Should().Be(0.05);
        state.PT.Should().Be(0.1);
        state.PS.Should().Be(0.2);
        state.PG.Should().Be(0.15);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SetParametersAsync_ClampsValues_ToValidRange()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - try to set invalid values
        await bkt.SetParametersAsync("test-skill", pl0: 1.5, pt: -0.1, ps: 2.0, pg: -1.0, cts.Token);
        var state = await bkt.GetSkillStateAsync("test-skill", cts.Token);

        // Assert - values should be clamped to [0, 1]
        state.Should().NotBeNull();
        state!.PL0.Should().Be(1.0);
        state.PT.Should().Be(0.0);
        state.PS.Should().Be(1.0);
        state.PG.Should().Be(0.0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ResetSkillAsync_ClearsMasteryEstimate()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Build mastery
        for (int i = 0; i < 10; i++)
        {
            await bkt.UpdateSkillAsync("fractions-add", wasCorrect: true, cts.Token);
        }
        var highProb = await bkt.GetMasteryProbabilityAsync("fractions-add", cts.Token);

        // Act
        await bkt.ResetSkillAsync("fractions-add", cts.Token);
        var afterReset = await bkt.GetMasteryProbabilityAsync("fractions-add", cts.Token);
        var state = await bkt.GetSkillStateAsync("fractions-add", cts.Token);

        // Assert
        highProb.Should().BeGreaterThan(0.5, "should have built mastery");
        afterReset.Should().Be(0.1, "should reset to prior P(L0)");
        state!.TotalAttempts.Should().Be(0, "attempts should be cleared");
        state.CorrectAttempts.Should().Be(0, "correct count should be cleared");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSkillsNeedingReinforcementAsync_ReturnsLowMasterySkills()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Create mix of mastery levels
        for (int i = 0; i < 10; i++)
            await bkt.UpdateSkillAsync("mastered-skill", wasCorrect: true, cts.Token);
        
        await bkt.UpdateSkillAsync("weak-skill-1", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("weak-skill-1", wasCorrect: false, cts.Token);
        
        await bkt.UpdateSkillAsync("weak-skill-2", wasCorrect: false, cts.Token);

        // Act
        var needsWork = await bkt.GetSkillsNeedingReinforcementAsync(threshold: 0.7, cts.Token);

        // Assert
        needsWork.Should().Contain("weak-skill-1");
        needsWork.Should().Contain("weak-skill-2");
        needsWork.Should().NotContain("mastered-skill");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSkillsNeedingReinforcementAsync_OrdersByLowestMastery()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Create skills with different mastery levels
        await bkt.UpdateSkillAsync("medium-weak", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("medium-weak", wasCorrect: true, cts.Token);
        await bkt.UpdateSkillAsync("medium-weak", wasCorrect: false, cts.Token);

        await bkt.UpdateSkillAsync("very-weak", wasCorrect: false, cts.Token);

        // Act
        var needsWork = await bkt.GetSkillsNeedingReinforcementAsync(threshold: 0.7, cts.Token);

        // Assert
        needsWork[0].Should().Be("very-weak", "weakest skill should be first");
        needsWork.Should().Contain("medium-weak");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateSkillAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
        {
            await bkt.UpdateSkillAsync("test", wasCorrect: true, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task BKTFormula_CorrectAnswer_FollowsBayesianUpdate()
    {
        // Arrange - Test the mathematical correctness of BKT update
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Set known parameters
        await bkt.SetParametersAsync("test-skill", pl0: 0.1, pt: 0.2, ps: 0.15, pg: 0.25, cts.Token);

        // Act - first correct answer
        var prob = await bkt.UpdateSkillAsync("test-skill", wasCorrect: true, cts.Token);

        // Assert - verify Bayesian formula
        // P(Ln|correct) = P(L0) * (1 - PS) / [P(L0) * (1 - PS) + (1 - P(L0)) * PG]
        // = 0.1 * 0.85 / [0.1 * 0.85 + 0.9 * 0.25]
        // = 0.085 / 0.31 ≈ 0.274
        // Then apply learning: P' = P + (1 - P) * PT = 0.274 + 0.726 * 0.2 ≈ 0.419
        prob.Should().BeApproximately(0.419, 0.01, "BKT formula should match expected calculation");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task BKTFormula_IncorrectAnswer_FollowsBayesianUpdate()
    {
        // Arrange
        var bkt = new BayesianKnowledgeTracer();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        await bkt.SetParametersAsync("test-skill", pl0: 0.5, pt: 0.2, ps: 0.15, pg: 0.25, cts.Token);

        // Act - incorrect answer
        var prob = await bkt.UpdateSkillAsync("test-skill", wasCorrect: false, cts.Token);

        // Assert - P(Ln|incorrect) should decrease from prior
        // But learning still applies, so final value depends on both factors
        prob.Should().BeLessThan(0.7, "incorrect answer should reduce confidence");
        prob.Should().BeGreaterThan(0.1, "learning component prevents dropping to zero");
    }
}
