using FluentAssertions;
using Spock.Core.Models;

namespace Spock.Tests.Core.Models;

/// <summary>
/// Tests for WeaknessRecord model and metrics tracking.
/// Ensures weakness detection and resolution tracking works correctly.
/// </summary>
[TestClass]
public class WeaknessRecordTests
{
    [TestMethod]
    [Timeout(5000)]
    public void Constructor_ShouldInitializeWithDefaults()
    {
        // Arrange & Act
        var record = new WeaknessRecord();

        // Assert
        record.SkillId.Should().NotBeNull();
        record.SkillName.Should().NotBeNull();
        record.IsResolved.Should().BeFalse();
        record.ResolvedDate.Should().BeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void FirstDetected_ShouldBeSetOnCreation()
    {
        // Arrange
        var beforeTime = DateTime.UtcNow;

        // Act
        var record = new WeaknessRecord();

        // Assert - Tracking reasoning: Need to know when weakness first appeared
        var afterTime = DateTime.UtcNow;
        record.FirstDetected.Should().BeOnOrAfter(beforeTime).And.BeOnOrBefore(afterTime);
        record.LastAttempt.Should().BeOnOrAfter(beforeTime).And.BeOnOrBefore(afterTime);
    }

    [TestMethod]
    [Timeout(5000)]
    public void WeaknessMetrics_ShouldInitializeCollections()
    {
        // Arrange & Act
        var metrics = new WeaknessMetrics();

        // Assert - Disguise tracking reasoning: Must track which contexts were used
        metrics.PresentedAs.Should().NotBeNull().And.BeEmpty();
        metrics.ErrorPattern.Should().Be("unknown");
        metrics.DisguiseCount.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public void WeaknessMetrics_CanTrackPerformanceData()
    {
        // Arrange & Act
        var metrics = new WeaknessMetrics
        {
            Accuracy = 0.65,
            AvgTime = 75.5,
            Confidence = 0.8,
            TotalAttempts = 10
        };

        // Assert - Adaptive engine reasoning: These metrics determine mastery thresholds
        metrics.Accuracy.Should().Be(0.65);
        metrics.AvgTime.Should().Be(75.5);
        metrics.Confidence.Should().Be(0.8);
        metrics.TotalAttempts.Should().Be(10);
    }

    [TestMethod]
    [Timeout(5000)]
    public void WeaknessRecord_CanBeMarkedAsResolved()
    {
        // Arrange
        var record = new WeaknessRecord
        {
            SkillId = "fractions-addition",
            IsResolved = false
        };

        // Act - Approval trigger reasoning: Resolution triggers strong approval
        var resolveTime = DateTime.UtcNow;
        record.IsResolved = true;
        record.ResolvedDate = resolveTime;

        // Assert
        record.IsResolved.Should().BeTrue();
        record.ResolvedDate.Should().Be(resolveTime);
    }

    [TestMethod]
    [Timeout(5000)]
    public void WeaknessMetrics_CanTrackDisguiseContexts()
    {
        // Arrange & Act
        var metrics = new WeaknessMetrics();
        metrics.PresentedAs.Add("math-word-problem");
        metrics.PresentedAs.Add("science-ratio");
        metrics.DisguiseCount = 2;

        // Assert - ADD-friendly reasoning: Disguises prevent pattern recognition fatigue
        metrics.PresentedAs.Should().HaveCount(2);
        metrics.PresentedAs.Should().Contain("math-word-problem");
        metrics.PresentedAs.Should().Contain("science-ratio");
        metrics.DisguiseCount.Should().Be(2);
    }

    [TestMethod]
    [Timeout(5000)]
    public void WeaknessMetrics_CanIdentifyErrorPatterns()
    {
        // Arrange & Act
        var metrics = new WeaknessMetrics
        {
            ErrorPattern = "conceptual"
        };

        // Assert - Remediation reasoning: Error type determines intervention strategy
        metrics.ErrorPattern.Should().Be("conceptual");
    }
}
