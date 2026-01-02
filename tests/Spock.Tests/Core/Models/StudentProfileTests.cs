using FluentAssertions;
using Spock.Core.Models;

namespace Spock.Tests.Core.Models;

/// <summary>
/// Tests for StudentProfile model validation and initialization.
/// Ensures profiles are created with safe defaults and proper structure.
/// </summary>
[TestClass]
public class StudentProfileTests
{
    [TestMethod]
    [Timeout(5000)]
    public void Constructor_ShouldInitializeWithDefaults()
    {
        // Arrange & Act
        var profile = new StudentProfile();

        // Assert - Psychological reasoning: Safe defaults prevent null reference errors
        profile.Id.Should().NotBeNullOrEmpty();
        profile.Level.Should().NotBeNull();
        profile.Weaknesses.Should().NotBeNull().And.BeEmpty();
        profile.ApprovalHistory.Should().NotBeNull().And.BeEmpty();
        profile.SessionHistory.Should().NotBeNull().And.BeEmpty();
        profile.Preferences.Should().NotBeNull();
        profile.ParentSettings.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public void CurrentLevel_ShouldStartAtGrade4()
    {
        // Arrange & Act
        var profile = new StudentProfile();

        // Assert - Pedagogical reasoning: Grade 4 is our baseline starting point
        profile.Level.Math.Should().Be("Grade 4");
        profile.Level.Reading.Should().Be("Grade 4");
        profile.Level.Science.Should().Be("Grade 4");
        profile.Level.Logic.Should().Be(1); // Logic uses 1-10 scale
    }

    [TestMethod]
    [Timeout(5000)]
    public void ParentSettings_ShouldHaveSafeDefaults()
    {
        // Arrange & Act
        var profile = new StudentProfile();

        // Assert - Safety reasoning: Prevent overuse and unhealthy patterns
        profile.ParentSettings.SessionLengthCap.Should().Be(20);
        profile.ParentSettings.MaxSessionsPerDay.Should().Be(3);
        profile.ParentSettings.AccelerationAllowed.Should().BeTrue();
        profile.ParentSettings.DashboardNotifications.Should().BeTrue();
    }

    [TestMethod]
    [Timeout(5000)]
    public void StudentPreferences_ShouldInitializeWithADDFriendlyDefaults()
    {
        // Arrange & Act
        var profile = new StudentProfile();

        // Assert - ADD-aware reasoning: 10-minute default matches typical attention span
        profile.Preferences.FocusDuration.Should().Be(10);
        profile.Preferences.ReadingGenres.Should().NotBeNull().And.BeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public void Age_CanBeSetAndRetrieved()
    {
        // Arrange
        var profile = new StudentProfile { Age = 10 };

        // Act & Assert
        profile.Age.Should().Be(10);
    }

    [TestMethod]
    [Timeout(5000)]
    public void MultipleProfiles_ShouldHaveUniqueIds()
    {
        // Arrange & Act
        var profile1 = new StudentProfile();
        var profile2 = new StudentProfile();

        // Assert - Data integrity reasoning: Each student needs unique identification
        profile1.Id.Should().NotBe(profile2.Id);
    }
}
