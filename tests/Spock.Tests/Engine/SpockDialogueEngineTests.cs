using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

[TestClass]
public class SpockDialogueEngineTests
{
    [TestMethod]
    [Timeout(5000)]
    public async Task GetNeutralDialogueAsync_ReturnsNeutralMessage()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetNeutralDialogueAsync(cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.ApprovalType.Should().BeNull("neutral dialogue has no approval");
        var validNeutral = new[] { "Proceed.", "Next problem.", "Continue.", "" };
        validNeutral.Should().Contain(response.Message);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSubtleApprovalAsync_ReturnsSubtleMessage()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetSubtleApprovalAsync(streakLength: 5, skillContext: "fractions", cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().NotBeEmpty();
        response.ApprovalType.Should().Be(ApprovalType.Streak);
        response.Intensity.Should().Be(ApprovalIntensity.Subtle);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSubtleApprovalAsync_RecordsApprovalHistory()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await engine.GetSubtleApprovalAsync(streakLength: 5, skillContext: "fractions", cts.Token);
        await engine.GetSubtleApprovalAsync(streakLength: 7, skillContext: "decimals", cts.Token);
        var history = await engine.GetApprovalHistoryAsync(cancellationToken: cts.Token);

        // Assert
        history.Should().HaveCount(2);
        history[0].Context.Should().Be("fractions");
        history[1].Context.Should().Be("decimals");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetStrongApprovalAsync_ReturnsStrongMessage()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetStrongApprovalAsync(
            skillName: "fractions-addition",
            sessionsAgo: 3,
            cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().NotBeEmpty();
        response.ApprovalType.Should().Be(ApprovalType.Mastery);
        response.Intensity.Should().Be(ApprovalIntensity.Strong);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetStrongApprovalAsync_MentionsWeaknessResolution()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetStrongApprovalAsync("fractions", sessionsAgo: 5, cts.Token);

        // Assert
        var expectedPhrases = new[] { "inefficient", "eliminated", "meets standards", "resolved" };
        expectedPhrases.Any(phrase => response.Message.Contains(phrase, StringComparison.OrdinalIgnoreCase))
            .Should().BeTrue("strong approval should reference weakness resolution");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetCorrectiveFeedbackAsync_ReturnsCalmFeedback()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetCorrectiveFeedbackAsync("fractions", cancellationToken: cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().NotBeEmpty("corrective feedback should provide guidance");
        response.ApprovalType.Should().BeNull("corrective feedback is not approval");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetCorrectiveFeedbackAsync_WithSpecificGuidance_IncludesIt()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetCorrectiveFeedbackAsync(
            "fractions",
            specificGuidance: "Review the common denominator rule.",
            cts.Token);

        // Assert
        response.Message.Should().Contain("Review the common denominator rule.");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetNarrativeEchoAsync_WithNoHistory_ReturnsCurrentApproval()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var approval = new ApprovalEvent
        {
            Id = Guid.NewGuid().ToString(),
            Type = ApprovalType.Mastery,
            Intensity = ApprovalIntensity.Strong,
            Message = "Test approval",
            Context = "test-skill",
            Timestamp = DateTime.UtcNow
        };

        // Act
        var response = await engine.GetNarrativeEchoAsync(approval, cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().Be("Test approval", "no prior history means no echo");
        response.IsNarrativeEcho.Should().BeFalse();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetNarrativeEchoAsync_WithHistory_CanLinkToPrior()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Build history
        for (int i = 0; i < 5; i++)
        {
            await engine.GetStrongApprovalAsync($"skill-{i}", sessionsAgo: i + 1, cts.Token);
        }

        var currentApproval = new ApprovalEvent
        {
            Id = Guid.NewGuid().ToString(),
            Type = ApprovalType.Mastery,
            Intensity = ApprovalIntensity.Strong,
            Message = "Current mastery achieved.",
            Context = "current-skill",
            Timestamp = DateTime.UtcNow
        };

        // Act
        var response = await engine.GetNarrativeEchoAsync(currentApproval, cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().NotBeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SubtleApproval_OccasionallyTriggersNarrativeEcho()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Build history with mastery approvals
        for (int i = 0; i < 5; i++)
        {
            await engine.GetStrongApprovalAsync($"skill-{i}", sessionsAgo: i + 1, cts.Token);
        }

        // Act - call subtle approval many times, some should echo
        int echoCount = 0;
        for (int i = 0; i < 50; i++)
        {
            var response = await engine.GetSubtleApprovalAsync(streakLength: 5, skillContext: $"test-{i}", cts.Token);
            if (response.IsNarrativeEcho) echoCount++;
        }

        // Assert - approximately 20% should be echoes (probabilistic test)
        echoCount.Should().BeGreaterThan(3, "some subtle approvals should trigger narrative echoes");
        echoCount.Should().BeLessThan(20, "not all subtle approvals should echo");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetAdvancedApprovalAsync_ReturnsAdvancedMessage()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.GetAdvancedApprovalAsync("calculus proof", cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().NotBeEmpty();
        response.ApprovalType.Should().Be(ApprovalType.Mastery);
        response.Intensity.Should().Be(ApprovalIntensity.Strong);
        
        var advancedPhrases = new[] { "rigorous", "generalized", "synthesis", "predicts" };
        advancedPhrases.Any(phrase => response.Message.Contains(phrase, StringComparison.OrdinalIgnoreCase))
            .Should().BeTrue("advanced approval should use sophisticated language");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UnlockVulcanInsightAsync_CreatesInsightFragment()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var response = await engine.UnlockVulcanInsightAsync("rapid-mastery-calculus", cts.Token);
        var insights = await engine.GetVulcanInsightsAsync(cts.Token);

        // Assert
        response.Should().NotBeNull();
        response.IsInsightFragment.Should().BeTrue();
        response.Message.Should().StartWith("*").And.EndWith("*", "insights are formatted with asterisks");
        insights.Should().HaveCount(1);
        insights[0].UnlockedBy.Should().Be("rapid-mastery-calculus");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UnlockVulcanInsightAsync_InsightsAreCollectible()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - unlock multiple insights
        await engine.UnlockVulcanInsightAsync("achievement-1", cts.Token);
        await engine.UnlockVulcanInsightAsync("achievement-2", cts.Token);
        await engine.UnlockVulcanInsightAsync("achievement-3", cts.Token);
        var insights = await engine.GetVulcanInsightsAsync(cts.Token);

        // Assert
        insights.Should().HaveCount(3);
        insights.Should().OnlyHaveUniqueItems(i => i.Id);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetApprovalHistoryAsync_ReturnsAllApprovals()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await engine.GetSubtleApprovalAsync(5, "skill-1", cts.Token);
        await engine.GetStrongApprovalAsync("skill-2", 3, cts.Token);
        await engine.GetSubtleApprovalAsync(7, "skill-3", cts.Token);
        var history = await engine.GetApprovalHistoryAsync(cancellationToken: cts.Token);

        // Assert
        history.Should().HaveCount(3);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetApprovalHistoryAsync_WithMaxCount_LimitsResults()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - create 5 approvals
        for (int i = 0; i < 5; i++)
        {
            await engine.GetSubtleApprovalAsync(5, $"skill-{i}", cts.Token);
        }
        var limitedHistory = await engine.GetApprovalHistoryAsync(maxCount: 3, cancellationToken: cts.Token);

        // Assert
        limitedHistory.Should().HaveCount(3, "should respect maxCount parameter");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetApprovalFrequencyAsync_CalculatesCorrectRatio()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - 3 approvals out of 60 problems
        await engine.GetSubtleApprovalAsync(5, "skill-1", cts.Token);
        await engine.GetSubtleApprovalAsync(5, "skill-2", cts.Token);
        await engine.GetStrongApprovalAsync("skill-3", 2, cts.Token);
        var frequency = await engine.GetApprovalFrequencyAsync(totalProblems: 60, cts.Token);

        // Assert
        frequency.Should().BeApproximately(0.05, 0.001, "3/60 = 0.05");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetApprovalFrequencyAsync_ZeroProblems_ReturnsZero()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var frequency = await engine.GetApprovalFrequencyAsync(totalProblems: 0, cts.Token);

        // Assert
        frequency.Should().Be(0.0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ResetApprovalHistoryAsync_ClearsApprovals()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await engine.GetSubtleApprovalAsync(5, "skill-1", cts.Token);
        await engine.GetStrongApprovalAsync("skill-2", 3, cts.Token);

        // Act
        await engine.ResetApprovalHistoryAsync(cts.Token);
        var history = await engine.GetApprovalHistoryAsync(cancellationToken: cts.Token);

        // Assert
        history.Should().BeEmpty("reset should clear approval history");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ResetApprovalHistoryAsync_PreservesInsightFragments()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await engine.UnlockVulcanInsightAsync("achievement-1", cts.Token);
        await engine.UnlockVulcanInsightAsync("achievement-2", cts.Token);

        // Act
        await engine.ResetApprovalHistoryAsync(cts.Token);
        var insights = await engine.GetVulcanInsightsAsync(cts.Token);

        // Assert
        insights.Should().HaveCount(2, "insights are collectible and persist across resets");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetNeutralDialogueAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
        {
            await engine.GetNeutralDialogueAsync(cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task PsychologicalPrinciple_ApprovalsAreRare()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - simulate 100 problems with some approvals
        for (int i = 0; i < 5; i++)
        {
            await engine.GetSubtleApprovalAsync(5, $"skill-{i}", cts.Token);
        }
        var frequency = await engine.GetApprovalFrequencyAsync(totalProblems: 100, cts.Token);

        // Assert - target is 1 approval per 15-20 problems (0.05-0.067)
        frequency.Should().BeLessThan(0.1, "approvals must remain rare to maintain motivation");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task NarrativeEcho_LinksToDistantPast()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Build substantial history
        for (int i = 0; i < 10; i++)
        {
            await engine.GetStrongApprovalAsync($"skill-{i}", sessionsAgo: i + 1, cts.Token);
        }

        var currentApproval = new ApprovalEvent
        {
            Id = Guid.NewGuid().ToString(),
            Type = ApprovalType.Mastery,
            Intensity = ApprovalIntensity.Strong,
            Message = "Current achievement.",
            Context = "current-skill",
            Timestamp = DateTime.UtcNow
        };

        // Act
        var response = await engine.GetNarrativeEchoAsync(currentApproval, cts.Token);

        // Assert - should link to one of the earlier approvals (skips 3 most recent)
        if (response.IsNarrativeEcho)
        {
            response.LinkedApprovalId.Should().NotBeNull();
            response.Message.Should().Contain("skill-", "should reference a prior skill");
        }
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task DialogueVariety_DifferentMessagesForSameContext()
    {
        // Arrange
        var engine = new SpockDialogueEngine();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - get multiple neutral dialogues
        var messages = new HashSet<string>();
        for (int i = 0; i < 20; i++)
        {
            var response = await engine.GetNeutralDialogueAsync(cts.Token);
            messages.Add(response.Message);
        }

        // Assert - should have variety
        messages.Count.Should().BeGreaterThan(1, "dialogue should vary to maintain engagement");
    }
}
