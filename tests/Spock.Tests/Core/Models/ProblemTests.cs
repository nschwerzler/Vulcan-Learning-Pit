using FluentAssertions;
using Spock.Core.Models;

namespace Spock.Tests.Core.Models;

/// <summary>
/// Tests for Problem model structure and validation.
/// Ensures problems are properly structured for adaptive selection and tracking.
/// </summary>
[TestClass]
public class ProblemTests
{
    [TestMethod]
    [Timeout(5000)]
    public void Constructor_ShouldInitializeWithDefaults()
    {
        // Arrange & Act
        var problem = new Problem();

        // Assert
        problem.Id.Should().NotBeNullOrEmpty();
        problem.MicroTopic.Should().NotBeNull();
        problem.Content.Should().NotBeNull();
        problem.Metadata.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void ProblemContent_ShouldInitializeCollections()
    {
        // Arrange & Act
        var content = new ProblemContent();

        // Assert - ADD-friendly reasoning: Collections must be initialized to prevent null checks
        content.Options.Should().NotBeNull().And.BeEmpty();
        content.CorrectAnswers.Should().NotBeNull().And.BeEmpty();
        content.Question.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void ProblemMetadata_ShouldInitializePrereqsList()
    {
        // Arrange & Act
        var metadata = new ProblemMetadata();

        // Assert - Adaptive engine reasoning: Prerequisites list needed for skill tracking
        metadata.ConceptualPrereqs.Should().NotBeNull().And.BeEmpty();
        metadata.IsPreview.Should().BeFalse();
        metadata.DisguisedWeakness.Should().BeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void Problem_CanSetDomainAndDifficulty()
    {
        // Arrange & Act
        var problem = new Problem
        {
            Domain = Domain.Math,
            Difficulty = 5
        };

        // Assert
        problem.Domain.Should().Be(Domain.Math);
        problem.Difficulty.Should().Be(5);
    }

    [TestMethod]
    [Timeout(5000)]
    public void Problem_CanSetMicroTopicAndTargetTime()
    {
        // Arrange & Act
        var problem = new Problem
        {
            MicroTopic = "fractions-addition",
            TargetTime = 60
        };

        // Assert - Weakness tracking reasoning: MicroTopic identifies specific skill
        problem.MicroTopic.Should().Be("fractions-addition");
        problem.TargetTime.Should().Be(60);
    }

    [TestMethod]
    [Timeout(5000)]
    public void ProblemAttempt_ShouldInitializeWithTimestamp()
    {
        // Arrange
        var beforeTime = DateTime.UtcNow;

        // Act
        var attempt = new ProblemAttempt();

        // Assert - Data integrity reasoning: Timestamps critical for performance tracking
        var afterTime = DateTime.UtcNow;
        attempt.AttemptTime.Should().BeOnOrAfter(beforeTime).And.BeOnOrBefore(afterTime);
        attempt.GivenAnswers.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public void ProblemAttempt_CanTrackWeaknessStatus()
    {
        // Arrange & Act
        var attempt = new ProblemAttempt
        {
            WasWeakness = true,
            NowMastered = true
        };

        // Assert - Approval trigger reasoning: These flags determine mastery-based approvals
        attempt.WasWeakness.Should().BeTrue();
        attempt.NowMastered.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void ProblemAttempt_CanTrackConfidenceIndicators()
    {
        // Arrange & Act
        var attempt = new ProblemAttempt
        {
            AnswerChanges = 3,
            TimeSpentSeconds = 45
        };

        // Assert - Weakness detection reasoning: Answer changes indicate uncertainty
        attempt.AnswerChanges.Should().Be(3);
        attempt.TimeSpentSeconds.Should().Be(45);
    }
}
