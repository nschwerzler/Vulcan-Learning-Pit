using FluentAssertions;
using Spock.Core.Models;
using Spock.Data;

namespace Spock.Tests.Data;

/// <summary>
/// Tests for StudentDataService persistence layer.
/// Ensures sessions, profiles, and weaknesses are correctly saved and retrieved.
/// </summary>
[TestClass]
public class StudentDataServiceTests : IDisposable
{
    private StudentDataService? _service;
    private readonly string _testDbPath = $"test_{Guid.NewGuid()}.db";

    [TestInitialize]
    public void Setup()
    {
        _service = new StudentDataService(_testDbPath);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _service?.Dispose();
        _service = null;
        
        // Wait a moment for file locks to be released
        System.Threading.Thread.Sleep(100);
        
        if (File.Exists(_testDbPath))
        {
            try
            {
                File.Delete(_testDbPath);
            }
            catch (IOException)
            {
                // Ignore - file may still be locked, will be cleaned up eventually
            }
        }
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetOrCreateStudent_NewStudent_ShouldCreateProfile()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var student = await _service!.GetOrCreateStudentAsync("Alice", 10, cts.Token);

        // Assert
        student.Should().NotBeNull();
        student.Name.Should().Be("Alice");
        student.Age.Should().Be(10);
        student.GameTokenSeconds.Should().Be(1);
        student.Id.Should().NotBeEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetOrCreateStudent_ExistingStudent_ShouldReturnSameProfile()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var first = await _service!.GetOrCreateStudentAsync("Bob", 12, cts.Token);
        var firstId = first.Id;

        // Act
        var second = await _service.GetOrCreateStudentAsync("Bob", 12, cts.Token);

        // Assert
        second.Id.Should().Be(firstId);
        second.Name.Should().Be("Bob");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveSession_CompleteSession_ShouldPersist()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Charlie", 11, cts.Token);
        var session = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddMinutes(-10),
            EndTime = DateTime.UtcNow,
            EndReason = SessionEndReason.StudentExit,
            Metrics = new SessionMetrics
            {
                TotalCorrect = 8,
                TotalAttempts = 10,
                AverageTime = 45.5,
                FocusScore = 0.85,
                TokensEarned = 40
            }
        };

        session.Problems.Add(new ProblemAttempt
        {
            ProblemId = "math-fractions-1",
            Domain = Domain.Math,
            IsCorrect = true,
            TimeSpentSeconds = 30,
            Difficulty = 5
        });

        // Act
        await _service.SaveSessionAsync(session, cts.Token);

        // Assert - verify can retrieve
        var sessions = await _service.GetRecentSessionsAsync(student.Id, 5, cts.Token);
        sessions.Should().HaveCount(1);
        sessions[0].Id.Should().Be(session.Id);
        sessions[0].Metrics.TotalCorrect.Should().Be(8);
        sessions[0].Problems.Should().HaveCount(1);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetRecentSessions_MultipleSessions_ShouldReturnMostRecent()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Diana", 9, cts.Token);
        
        // Create 3 sessions at different times
        for (int i = 0; i < 3; i++)
        {
            var session = new Session
            {
                StudentId = student.Id,
                StartTime = DateTime.UtcNow.AddDays(-i),
                EndTime = DateTime.UtcNow.AddDays(-i).AddMinutes(15),
                Metrics = new SessionMetrics { TotalCorrect = i + 1, TotalAttempts = 10 }
            };
            await _service.SaveSessionAsync(session, cts.Token);
        }

        // Act
        var recent = await _service.GetRecentSessionsAsync(student.Id, 2, cts.Token);

        // Assert
        recent.Should().HaveCount(2);
        recent[0].Metrics.TotalCorrect.Should().Be(1); // Most recent (i=0)
        recent[1].Metrics.TotalCorrect.Should().Be(2); // Second most recent (i=1)
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveWeakness_NewWeakness_ShouldPersist()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Eve", 10, cts.Token);
        var weakness = new WeaknessRecord
        {
            StudentId = student.Id,
            SkillId = "fractions-addition",
            SkillName = "Adding Fractions",
            Domain = Domain.Math,
            Accuracy = 0.55,
            IsResolved = false
        };

        // Act
        await _service.SaveWeaknessAsync(weakness, cts.Token);

        // Assert
        var weaknesses = await _service.GetActiveWeaknessesAsync(student.Id, cts.Token);
        weaknesses.Should().HaveCount(1);
        weaknesses[0].SkillId.Should().Be("fractions-addition");
        weaknesses[0].Accuracy.Should().Be(0.55);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveWeakness_UpdateExisting_ShouldModifyNotDuplicate()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Frank", 11, cts.Token);
        var weakness = new WeaknessRecord
        {
            StudentId = student.Id,
            SkillId = "deduction",
            SkillName = "Logical Deduction",
            Domain = Domain.Logic,
            Accuracy = 0.60,
            IsResolved = false
        };
        await _service.SaveWeaknessAsync(weakness, cts.Token);

        // Act - Update with improved accuracy
        weakness.Accuracy = 0.92;
        weakness.IsResolved = true;
        weakness.ResolvedDate = DateTime.UtcNow;
        await _service.SaveWeaknessAsync(weakness, cts.Token);

        // Assert
        var weaknesses = await _service.GetActiveWeaknessesAsync(student.Id, cts.Token);
        weaknesses.Should().BeEmpty(); // Should be resolved now

        var conquests = await _service.GetRecentConquestsAsync(student.Id, 30, cts.Token);
        conquests.Should().HaveCount(1);
        conquests[0].Accuracy.Should().Be(0.92);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSessionStatistics_MultipleProblems_ShouldCalculateCorrectly()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Grace", 12, cts.Token);
        
        var session1 = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddHours(-2),
            EndTime = DateTime.UtcNow.AddHours(-2).AddMinutes(20),
            Metrics = new SessionMetrics 
            { 
                TotalCorrect = 7,
                TotalAttempts = 10,
                TokensEarned = 35
            }
        };
        session1.Problems.AddRange(Enumerable.Range(1, 10).Select(i => new ProblemAttempt
        {
            ProblemId = $"problem-{i}",
            Domain = Domain.Math,
            IsCorrect = i <= 7,
            Difficulty = 5
        }));

        var session2 = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddHours(-1),
            EndTime = DateTime.UtcNow.AddHours(-1).AddMinutes(15),
            Metrics = new SessionMetrics 
            { 
                TotalCorrect = 9,
                TotalAttempts = 10,
                TokensEarned = 45
            }
        };
        session2.Problems.AddRange(Enumerable.Range(11, 10).Select(i => new ProblemAttempt
        {
            ProblemId = $"problem-{i}",
            Domain = Domain.Logic,
            IsCorrect = i <= 19,
            Difficulty = 5
        }));

        await _service.SaveSessionAsync(session1, cts.Token);
        await _service.SaveSessionAsync(session2, cts.Token);

        // Act
        var stats = await _service.GetSessionStatisticsAsync(student.Id, DateTime.UtcNow.AddDays(-1), cts.Token);

        // Assert
        stats.TotalSessions.Should().Be(2);
        stats.TotalProblems.Should().Be(20);
        stats.TotalCorrect.Should().Be(16);
        stats.TokensEarned.Should().Be(80);
        stats.AverageAccuracy.Should().BeApproximately(0.8, 0.01); // (7+9)/20 = 0.8
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSessionsByDateRange_FiltersByDate_ShouldReturnOnlyMatching()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Arrange
        var student = await _service!.GetOrCreateStudentAsync("Henry", 10, cts.Token);
        
        var oldSession = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddDays(-10),
            EndTime = DateTime.UtcNow.AddDays(-10).AddMinutes(15),
            Metrics = new SessionMetrics { TotalCorrect = 5, TotalAttempts = 10 }
        };
        
        var recentSession = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddDays(-2),
            EndTime = DateTime.UtcNow.AddDays(-2).AddMinutes(15),
            Metrics = new SessionMetrics { TotalCorrect = 8, TotalAttempts = 10 }
        };

        await _service.SaveSessionAsync(oldSession, cts.Token);
        await _service.SaveSessionAsync(recentSession, cts.Token);

        // Act - Get only last 7 days
        var recent = await _service.GetSessionsByDateRangeAsync(
            student.Id,
            DateTime.UtcNow.AddDays(-7),
            DateTime.UtcNow,
            cts.Token);

        // Assert
        recent.Should().HaveCount(1);
        recent[0].Metrics.TotalCorrect.Should().Be(8);
    }

    public void Dispose()
    {
        _service?.Dispose();
        _service = null;
        
        // Wait for file locks
        System.Threading.Thread.Sleep(100);
        
        if (File.Exists(_testDbPath))
        {
            try
            {
                File.Delete(_testDbPath);
            }
            catch (IOException)
            {
                // Ignore - file may still be locked
            }
        }
    }
}
