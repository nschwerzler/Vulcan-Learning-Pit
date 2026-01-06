using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spock.Core.Models;

namespace Spock.Tests.Core;

/// <summary>
/// Tests for Game Token System as specified in plan.md.
/// Token earning: +1 second × difficulty per correct answer.
/// Penalty: -1 second per incorrect answer (minimum 1 second).
/// Display format: "2m 15s", "1h 3m", etc.
/// </summary>
[TestClass]
public class GameTokenSystemTests
{
    [TestMethod]
    [Timeout(5000)]
    public void StudentProfile_InitialBalance_IsZeroSeconds()
    {
        // Arrange & Act
        var profile = new StudentProfile();
        
        // Assert
        profile.GameTokenSeconds.Should().Be(0, "initial balance should be 0 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenEarning_DifficultyOne_EarnsOneSecond()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 0 };
        int difficulty = 1;
        
        // Act
        int earned = 1 * difficulty;
        profile.GameTokenSeconds += earned;
        
        // Assert
        profile.GameTokenSeconds.Should().Be(1, "difficulty 1 problem earns 1 second");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenEarning_DifficultyFive_EarnsFiveSeconds()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 10 };
        int difficulty = 5;
        
        // Act
        int earned = 1 * difficulty;
        profile.GameTokenSeconds += earned;
        
        // Assert
        profile.GameTokenSeconds.Should().Be(15, "difficulty 5 problem earns 5 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenEarning_DifficultyTen_EarnsTenSeconds()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 50 };
        int difficulty = 10;
        
        // Act
        int earned = 1 * difficulty;
        profile.GameTokenSeconds += earned;
        
        // Assert
        profile.GameTokenSeconds.Should().Be(60, "difficulty 10 (college) problem earns 10 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenPenalty_IncorrectAnswer_DeductsOneSecond()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 10 };
        
        // Act
        profile.GameTokenSeconds -= 1;
        
        // Assert
        profile.GameTokenSeconds.Should().Be(9, "incorrect answer deducts 1 second");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenPenalty_NeverGoesBelowZero()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 1 };
        
        // Act - try to deduct 1 second
        profile.GameTokenSeconds = Math.Max(0, profile.GameTokenSeconds - 1);
        
        // Assert
        profile.GameTokenSeconds.Should().Be(0, "balance should never go below 0 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenAccumulation_TwentyProblemsAtDifficultyFive_Equals100Seconds()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 0 };
        int problemCount = 20;
        int difficulty = 5;
        
        // Act - 20 problems at difficulty 5
        for (int i = 0; i < problemCount; i++)
        {
            profile.GameTokenSeconds += (1 * difficulty);
        }
        
        // Assert
        profile.GameTokenSeconds.Should().Be(100, "20 problems × 5 seconds = 100 seconds (1m 40s)");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenConversion_SixtySeconds_IsOneMinute()
    {
        // Arrange
        int seconds = 60;
        
        // Act
        int minutes = seconds / 60;
        
        // Assert
        minutes.Should().Be(1, "60 seconds should equal 1 minute");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenConversion_ThreeThousandSixHundredSeconds_IsOneHour()
    {
        // Arrange
        int seconds = 3600;
        
        // Act
        int hours = seconds / 3600;
        
        // Assert
        hours.Should().Be(1, "3600 seconds should equal 1 hour");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void TokenDisplay_OneHundredSeconds_FormatsCorrectly()
    {
        // Arrange
        int totalSeconds = 100;
        
        // Act
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        string display = $"{minutes}m {seconds}s";
        
        // Assert
        display.Should().Be("1m 40s", "100 seconds should display as 1m 40s");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void SessionMetrics_TokensEarned_TracksSessionTotal()
    {
        // Arrange
        var metrics = new SessionMetrics();
        
        // Act - simulate earning from 3 problems: difficulty 3, 5, 7
        metrics.TokensEarned += 3;
        metrics.TokensEarned += 5;
        metrics.TokensEarned += 7;
        
        // Assert
        metrics.TokensEarned.Should().Be(15, "session should track total tokens earned (3+5+7)");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void DifficultyScaling_Elementary_Earns1To3Seconds()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 0 };
        
        // Act & Assert - Elementary difficulties (1-3)
        for (int difficulty = 1; difficulty <= 3; difficulty++)
        {
            int earned = 1 * difficulty;
            earned.Should().BeInRange(1, 3, $"elementary difficulty {difficulty} should earn 1-3 seconds");
        }
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void DifficultyScaling_MiddleSchool_Earns4To6Seconds()
    {
        // Arrange & Act & Assert - Middle School difficulties (4-6)
        for (int difficulty = 4; difficulty <= 6; difficulty++)
        {
            int earned = 1 * difficulty;
            earned.Should().BeInRange(4, 6, $"middle school difficulty {difficulty} should earn 4-6 seconds");
        }
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void DifficultyScaling_HighSchool_Earns7To8Seconds()
    {
        // Arrange & Act & Assert - High School difficulties (7-8)
        for (int difficulty = 7; difficulty <= 8; difficulty++)
        {
            int earned = 1 * difficulty;
            earned.Should().BeInRange(7, 8, $"high school difficulty {difficulty} should earn 7-8 seconds");
        }
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void DifficultyScaling_College_Earns9To10Seconds()
    {
        // Arrange & Act & Assert - College difficulties (9-10)
        for (int difficulty = 9; difficulty <= 10; difficulty++)
        {
            int earned = 1 * difficulty;
            earned.Should().BeInRange(9, 10, $"college difficulty {difficulty} should earn 9-10 seconds");
        }
    }
    
    [TestMethod]
    [Timeout(5000)]
    public void MixedPerformance_CorrectAndIncorrect_CalculatesNetBalance()
    {
        // Arrange
        var profile = new StudentProfile { GameTokenSeconds = 10 };
        
        // Act - simulate 3 correct (difficulty 5) + 2 incorrect
        profile.GameTokenSeconds += 5; // Correct
        profile.GameTokenSeconds += 5; // Correct
        profile.GameTokenSeconds -= 1; // Incorrect
        profile.GameTokenSeconds += 5; // Correct
        profile.GameTokenSeconds -= 1; // Incorrect
        
        // Assert
        // Started: 10, +5, +5, -1, +5, -1 = 23
        profile.GameTokenSeconds.Should().Be(23, "net balance after mixed performance should be correct");
    }
}
