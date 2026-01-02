using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

/// <summary>
/// Tests for WeaknessTracker's detection and disguise management.
/// Validates weakness identification and ADD-friendly disguise rotation.
/// </summary>
[TestClass]
public class WeaknessTrackerTests
{
    [TestMethod]
    [Timeout(5000)]
    public void IsWeakness_LowAccuracy_ReturnsTrue()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 6, totalCount: 10, avgTime: 30);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();

        // Act - 60% accuracy is below 75% threshold
        var isWeak = tracker.IsWeakness("fractions-add", targetTime: 60);

        // Assert - Adaptive reasoning: Low accuracy indicates weakness
        isWeak.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void IsWeakness_SlowTime_ReturnsTrue()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 9, totalCount: 10, avgTime: 80);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();

        // Act - 80s average is > 130% of 60s target
        var isWeak = tracker.IsWeakness("fractions-add", targetTime: 60);

        // Assert - Speed reasoning: Slow but accurate still needs improvement
        isWeak.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void IsWeakness_LowConfidence_ReturnsTrue()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttemptsWithChanges(correctCount: 8, totalCount: 10, avgTime: 50, avgChanges: 3);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();

        // Act
        var isWeak = tracker.IsWeakness("fractions-add", targetTime: 60);

        // Assert - Confidence reasoning: Many changes indicate uncertainty
        isWeak.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void IsWeakness_MasteryLevel_ReturnsFalse()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 9, totalCount: 10, avgTime: 40);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();

        // Act - 90% accurate, under time, should not be weakness
        var isWeak = tracker.IsWeakness("fractions-add", targetTime: 60);

        // Assert
        isWeak.Should().BeFalse();
    }

    [TestMethod]
    [Timeout(5000)]
    public void IsWeakness_UnknownSkill_ReturnsFalse()
    {
        // Arrange
        var tracker = new WeaknessTracker();

        // Act - No data for this skill
        var isWeak = tracker.IsWeakness("unknown-skill", targetTime: 60);

        // Assert
        isWeak.Should().BeFalse();
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetDisguiseContext_WithAvailableContexts_ReturnsUnused()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();
        
        tracker.RecordDisguiseUsed("fractions-add", "math-direct");
        var allContexts = new List<string> { "math-direct", "science-ratio", "logic-puzzle", "word-problem" };

        // Act - Should return one of the unused contexts
        var context = tracker.GetDisguiseContext("fractions-add", allContexts);

        // Assert - ADD-aware reasoning: Rotation prevents boredom
        context.Should().NotBeNull();
        context.Should().NotBe("math-direct");
        allContexts.Should().Contain(context!);
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetDisguiseContext_AllUsed_ReturnsNull()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();
        
        var allContexts = new List<string> { "math-direct", "science-ratio" };
        tracker.RecordDisguiseUsed("fractions-add", "math-direct");
        tracker.RecordDisguiseUsed("fractions-add", "science-ratio");

        // Act - All contexts exhausted
        var context = tracker.GetDisguiseContext("fractions-add", allContexts);

        // Assert
        context.Should().BeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void RecordDisguiseUsed_IncrementsCount()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();

        // Act
        tracker.RecordDisguiseUsed("fractions-add", "math-direct");
        tracker.RecordDisguiseUsed("fractions-add", "science-ratio");

        // Assert - Tracking reasoning: Monitor variety in presentation
        var metrics = tracker.GetMetrics("fractions-add");
        metrics.Should().NotBeNull();
        metrics!.DisguiseCount.Should().Be(2);
        metrics.PresentedAs.Should().HaveCount(2);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateMetricsAsync_CalculatesAccuracyCorrectly()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 7, totalCount: 10, avgTime: 50);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60, cts.Token);

        // Assert
        var metrics = tracker.GetMetrics("fractions-add");
        metrics.Should().NotBeNull();
        metrics!.Accuracy.Should().BeApproximately(0.70, 0.01);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateMetricsAsync_CalculatesAverageTime()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = new List<ProblemAttempt>
        {
            new() { IsCorrect = true, TimeSpentSeconds = 40 },
            new() { IsCorrect = true, TimeSpentSeconds = 60 },
            new() { IsCorrect = false, TimeSpentSeconds = 80 }
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60, cts.Token);

        // Assert
        var metrics = tracker.GetMetrics("fractions-add");
        metrics.Should().NotBeNull();
        metrics!.AvgTime.Should().BeApproximately(60.0, 0.1);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateMetricsAsync_PreservesDisguiseHistory()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        await tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60, cts.Token);
        tracker.RecordDisguiseUsed("fractions-add", "math-direct");

        // Act - Update metrics again
        await tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60, cts.Token);

        // Assert - History reasoning: Must preserve context tracking across updates
        var metrics = tracker.GetMetrics("fractions-add");
        metrics!.PresentedAs.Should().Contain("math-direct");
        metrics.DisguiseCount.Should().Be(1);
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetActiveWeaknesses_ReturnsAllWeakSkills()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var weakAttempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 80);
        var strongAttempts = CreateAttempts(correctCount: 9, totalCount: 10, avgTime: 40);
        
        tracker.UpdateMetricsAsync("fractions-add", weakAttempts, targetTime: 60).Wait();
        tracker.UpdateMetricsAsync("fractions-multiply", weakAttempts, targetTime: 60).Wait();
        tracker.UpdateMetricsAsync("decimals", strongAttempts, targetTime: 60).Wait();

        var targetTimes = new Dictionary<string, double>
        {
            { "fractions-add", 60 },
            { "fractions-multiply", 60 },
            { "decimals", 60 }
        };

        // Act
        var weaknesses = tracker.GetActiveWeaknesses(targetTimes);

        // Assert - Dashboard reasoning: Parent needs complete weakness list
        weaknesses.Should().HaveCount(2);
        weaknesses.Should().Contain("fractions-add");
        weaknesses.Should().Contain("fractions-multiply");
        weaknesses.Should().NotContain("decimals");
    }

    [TestMethod]
    [Timeout(5000)]
    public void IsWeaknessResolved_MasteryAchieved_ReturnsTrue()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var masteryAttempts = CreateAttempts(correctCount: 10, totalCount: 10, avgTime: 40);
        tracker.UpdateMetricsAsync("fractions-add", masteryAttempts, targetTime: 60).Wait();

        // Act - >90% accuracy, <80% time, high confidence
        var resolved = tracker.IsWeaknessResolved("fractions-add", targetTime: 60);

        // Assert - Approval trigger reasoning: Mastery triggers strong approval
        resolved.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void TrackedSkillCount_ReturnsCorrectCount()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();
        tracker.UpdateMetricsAsync("fractions-multiply", attempts, targetTime: 60).Wait();

        // Act & Assert
        tracker.TrackedSkillCount.Should().Be(2);
    }

    [TestMethod]
    [Timeout(5000)]
    public void Clear_RemovesAllTrackedSkills()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60).Wait();
        tracker.TrackedSkillCount.Should().Be(1);

        // Act
        tracker.Clear();

        // Assert
        tracker.TrackedSkillCount.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task UpdateMetricsAsync_CancellationToken_ThrowsOnCancel()
    {
        // Arrange
        var tracker = new WeaknessTracker();
        var attempts = CreateAttempts(correctCount: 5, totalCount: 10, avgTime: 70);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert - Timeout safety reasoning: Must respect cancellation
        await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () =>
        {
            await tracker.UpdateMetricsAsync("fractions-add", attempts, targetTime: 60, cts.Token);
        });
    }

    // Helper methods
    private List<ProblemAttempt> CreateAttempts(int correctCount, int totalCount, double avgTime)
    {
        var attempts = new List<ProblemAttempt>();
        for (int i = 0; i < totalCount; i++)
        {
            attempts.Add(new ProblemAttempt
            {
                IsCorrect = i < correctCount,
                TimeSpentSeconds = (int)avgTime,
                AnswerChanges = 0,
                AttemptTime = DateTime.UtcNow.AddMinutes(-i)
            });
        }
        return attempts;
    }

    private List<ProblemAttempt> CreateAttemptsWithChanges(int correctCount, int totalCount, double avgTime, int avgChanges)
    {
        var attempts = new List<ProblemAttempt>();
        for (int i = 0; i < totalCount; i++)
        {
            attempts.Add(new ProblemAttempt
            {
                IsCorrect = i < correctCount,
                TimeSpentSeconds = (int)avgTime,
                AnswerChanges = avgChanges,
                AttemptTime = DateTime.UtcNow.AddMinutes(-i)
            });
        }
        return attempts;
    }
}
