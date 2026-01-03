using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;
using Spock.Data;

namespace Spock.Tests.Data;

/// <summary>
/// Tests for SessionService persistence and retrieval operations.
/// Validates Parent Dashboard data queries and trend analysis.
/// </summary>
[TestClass]
public class SessionServiceTests
{
    private SpockDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<SpockDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new SpockDbContext(options);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveSessionAsync_ValidSession_SavesSuccessfully()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);
        
        var student = new StudentProfile { Id = "test-1", Name = "Test Student", Age = 10 };
        context.StudentProfiles.Add(student);
        await context.SaveChangesAsync();

        var session = new Session
        {
            Id = Guid.NewGuid().ToString(),
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddMinutes(-15),
            EndTime = DateTime.UtcNow,
            Metrics = new SessionMetrics { TotalCorrect = 5, TotalAttempts = 7 }
        };

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var saved = await service.SaveSessionAsync(session, cts.Token);

        // Assert
        saved.Should().NotBeNull();
        saved.Id.Should().Be(session.Id);
        
        var retrieved = await context.Sessions.FindAsync(session.Id);
        retrieved.Should().NotBeNull();
        retrieved!.StudentId.Should().Be(student.Id);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveSessionAsync_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(
            async () => await service.SaveSessionAsync(null!, cts.Token));
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SaveSessionAsync_NonExistentStudent_ThrowsInvalidOperationException()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var session = new Session
        {
            StudentId = "non-existent-student",
            StartTime = DateTime.UtcNow
        };

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(
            async () => await service.SaveSessionAsync(session, cts.Token));
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSessionHistoryAsync_ReturnsOrderedSessions()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-2", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        // Add 3 sessions at different times
        var session1 = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-3) };
        var session2 = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-2) };
        var session3 = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-1) };
        
        context.Sessions.AddRange(session1, session2, session3);
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var history = await service.GetSessionHistoryAsync(student.Id, cancellationToken: cts.Token);

        // Assert
        history.Should().HaveCount(3);
        history[0].StartTime.Should().BeAfter(history[1].StartTime);
        history[1].StartTime.Should().BeAfter(history[2].StartTime);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSessionHistoryAsync_WithLimit_ReturnsCorrectCount()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-3", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        for (int i = 0; i < 10; i++)
        {
            context.Sessions.Add(new Session
            {
                StudentId = student.Id,
                StartTime = DateTime.UtcNow.AddDays(-i)
            });
        }
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var history = await service.GetSessionHistoryAsync(student.Id, limit: 5, cancellationToken: cts.Token);

        // Assert
        history.Should().HaveCount(5);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetLastSessionAsync_ReturnsMostRecentSession()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-4", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        var oldSession = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-5) };
        var recentSession = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddHours(-1) };
        
        context.Sessions.AddRange(oldSession, recentSession);
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var last = await service.GetLastSessionAsync(student.Id, cts.Token);

        // Assert
        last.Should().NotBeNull();
        last!.Id.Should().Be(recentSession.Id);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetSessionCountAsync_ReturnsCorrectCount()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-5", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        var startDate = DateTime.UtcNow.AddDays(-7);
        var endDate = DateTime.UtcNow;

        // Add 5 sessions within range, 2 outside range
        for (int i = 0; i < 5; i++)
        {
            context.Sessions.Add(new Session
            {
                StudentId = student.Id,
                StartTime = DateTime.UtcNow.AddDays(-i - 1)
            });
        }
        
        context.Sessions.Add(new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-10) });
        context.Sessions.Add(new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-15) });
        
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var count = await service.GetSessionCountAsync(student.Id, startDate, endDate, cts.Token);

        // Assert
        count.Should().Be(5, "only sessions within the date range should be counted");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetAggregateMetricsAsync_CalculatesCorrectAverages()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-6", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        var startDate = DateTime.UtcNow.AddDays(-7);
        var endDate = DateTime.UtcNow;

        // Add 3 sessions with known metrics
        var session1 = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddDays(-5),
            EndTime = DateTime.UtcNow.AddDays(-5).AddMinutes(10),
            Metrics = new SessionMetrics
            {
                TotalCorrect = 8,
                TotalAttempts = 10,
                FocusScore = 0.8,
                DomainsVisited = new List<string> { "Math", "Logic" }
            }
        };
        session1.Problems.Add(new ProblemAttempt { IsCorrect = true });
        session1.Approvals.Add(new ApprovalEvent());

        var session2 = new Session
        {
            StudentId = student.Id,
            StartTime = DateTime.UtcNow.AddDays(-3),
            EndTime = DateTime.UtcNow.AddDays(-3).AddMinutes(15),
            Metrics = new SessionMetrics
            {
                TotalCorrect = 6,
                TotalAttempts = 10,
                FocusScore = 0.9,
                DomainsVisited = new List<string> { "Reading" }
            }
        };
        session2.Problems.Add(new ProblemAttempt { IsCorrect = true });

        context.Sessions.AddRange(session1, session2);
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var metrics = await service.GetAggregateMetricsAsync(student.Id, startDate, endDate, cts.Token);

        // Assert
        metrics.Should().NotBeNull();
        metrics.TotalSessions.Should().Be(2);
        metrics.TotalCorrect.Should().Be(14, "8 + 6 = 14");
        metrics.TotalApprovals.Should().Be(1, "only session1 has approval");
        metrics.AverageFocusScore.Should().BeApproximately(0.85, 0.01, "(0.8 + 0.9) / 2 = 0.85");
        metrics.DomainsVisited.Should().Contain(new[] { "Math", "Logic", "Reading" });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetAggregateMetricsAsync_NoSessions_ReturnsZeroMetrics()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var startDate = DateTime.UtcNow.AddDays(-7);
        var endDate = DateTime.UtcNow;

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var metrics = await service.GetAggregateMetricsAsync("non-existent", startDate, endDate, cts.Token);

        // Assert
        metrics.Should().NotBeNull();
        metrics.TotalSessions.Should().Be(0);
        metrics.TotalProblems.Should().Be(0);
        metrics.OverallAccuracy.Should().Be(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetWeaknessTrendsAsync_ReturnsCorrectTrend()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-7", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        var session = new Session { Id = "session-1", StudentId = student.Id };
        context.Sessions.Add(session);

        // Add problem attempts for Math domain over 3 days
        var attempts = new List<ProblemAttempt>
        {
            new() { SessionId = session.Id, Domain = Domain.Math, IsCorrect = true, TimeSpentSeconds = 30, AttemptTime = DateTime.UtcNow.AddDays(-3) },
            new() { SessionId = session.Id, Domain = Domain.Math, IsCorrect = false, TimeSpentSeconds = 45, AttemptTime = DateTime.UtcNow.AddDays(-3) },
            new() { SessionId = session.Id, Domain = Domain.Math, IsCorrect = true, TimeSpentSeconds = 25, AttemptTime = DateTime.UtcNow.AddDays(-2) },
            new() { SessionId = session.Id, Domain = Domain.Math, IsCorrect = true, TimeSpentSeconds = 20, AttemptTime = DateTime.UtcNow.AddDays(-1) },
            new() { SessionId = session.Id, Domain = Domain.Math, IsCorrect = true, TimeSpentSeconds = 18, AttemptTime = DateTime.UtcNow.AddDays(-1) }
        };

        context.ProblemAttempts.AddRange(attempts);
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var trends = await service.GetWeaknessTrendsAsync(student.Id, Domain.Math, 30, cts.Token);

        // Assert
        trends.Should().NotBeEmpty();
        trends.Should().HaveCount(3, "attempts span 3 different days");
        
        var firstDay = trends.First();
        firstDay.Accuracy.Should().BeApproximately(0.5, 0.01, "1 correct out of 2 = 50%");
        
        var lastDay = trends.Last();
        lastDay.Accuracy.Should().Be(1.0, "2 correct out of 2 = 100%");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task CleanupOldSessionsAsync_DeletesOldSessions()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var service = new SessionService(context);

        var student = new StudentProfile { Id = "test-8", Name = "Test Student" };
        context.StudentProfiles.Add(student);

        // Add old sessions (200 days old) and recent sessions
        var oldSession1 = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-200) };
        var oldSession2 = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-190) };
        var recentSession = new Session { StudentId = student.Id, StartTime = DateTime.UtcNow.AddDays(-10) };

        context.Sessions.AddRange(oldSession1, oldSession2, recentSession);
        await context.SaveChangesAsync();

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var deletedCount = await service.CleanupOldSessionsAsync(daysToKeep: 180, cancellationToken: cts.Token);

        // Assert
        deletedCount.Should().BeGreaterThan(0);
        
        var remaining = await context.Sessions.CountAsync(cts.Token);
        remaining.Should().Be(1, "only the recent session should remain");
    }
}
