using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

/// <summary>
/// TDD tests for bugs discovered in SessionCoordinator.
/// These tests MUST fail before fixes are applied.
/// </summary>
[TestClass]
public class SessionCoordinatorBugTests
{
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_CorrectAnswer_ShouldUpdateGameTokensInProfile()
    {
        // BUG: SessionCoordinator.ProcessAttemptAsync doesn't update StudentProfile.GameTokenSeconds
        // Expected: StudentProfile.GameTokenSeconds should increase by difficulty level
        // Actual: GameTokenSeconds remains unchanged (1 second)
        
        // Arrange
        var profile = new StudentProfile { Id = "test-1", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        var problem = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 5);
        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = true,
            TimeSpentSeconds = 10
        };
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        
        // Assert
        profile.GameTokenSeconds.Should().Be(5, "0 initial + 5 seconds for difficulty 5 problem = 5 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_IncorrectAnswer_ShouldDeductOneSecondFromProfile()
    {
        // BUG: SessionCoordinator.ProcessAttemptAsync doesn't update StudentProfile.GameTokenSeconds on incorrect
        
        // Arrange
        var profile = new StudentProfile { Id = "test-2", GameTokenSeconds = 10 };
        var coordinator = new SessionCoordinator(profile);
        var problem = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 5);
        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = false,
            TimeSpentSeconds = 15
        };
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        
        // Assert
        profile.GameTokenSeconds.Should().Be(9, "10 initial - 1 second penalty = 9 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_IncorrectAtMinimumBalance_ShouldNotGoBelowZero()
    {
        // BUG: SessionCoordinator doesn't enforce minimum balance of 0 seconds
        
        // Arrange
        var profile = new StudentProfile { Id = "test-3", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        var problem = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 5);
        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = false,
            TimeSpentSeconds = 12
        };
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        
        // Assert
        profile.GameTokenSeconds.Should().Be(0, "balance should never go below 0 seconds");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_ShouldTrackTokensEarnedInSessionMetrics()
    {
        // BUG: SessionCoordinator doesn't update SessionMetrics.TokensEarned
        
        // Arrange
        var profile = new StudentProfile { Id = "test-4", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        var problem = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 7);
        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = true,
            TimeSpentSeconds = 10
        };
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        
        // Assert
        feedback.SessionMetrics.TokensEarned.Should().Be(7, "difficulty 7 problem should earn 7 tokens");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_MultipleProblems_ShouldAccumulateTokensInSessionMetrics()
    {
        // BUG: SessionMetrics.TokensEarned doesn't accumulate across multiple problems
        
        // Arrange
        var profile = new StudentProfile { Id = "test-5", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act - Answer 3 problems correctly
        var problem1 = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 5);
        var attempt1 = new ProblemAttempt { ProblemId = problem1.Id, IsCorrect = true, TimeSpentSeconds = 10 };
        await coordinator.ProcessAttemptAsync(attempt1, problem1, cts.Token);
        
        var problem2 = CreateTestProblem(Domain.Logic, "deduction", difficulty: 3);
        var attempt2 = new ProblemAttempt { ProblemId = problem2.Id, IsCorrect = true, TimeSpentSeconds = 8 };
        await coordinator.ProcessAttemptAsync(attempt2, problem2, cts.Token);
        
        var problem3 = CreateTestProblem(Domain.Reading, "inference", difficulty: 4);
        var attempt3 = new ProblemAttempt { ProblemId = problem3.Id, IsCorrect = false, TimeSpentSeconds = 12 };
        var feedback3 = await coordinator.ProcessAttemptAsync(attempt3, problem3, cts.Token);
        
        // Assert
        feedback3.SessionMetrics.TokensEarned.Should().Be(7, "5 + 3 - 1 = 7 tokens earned in session");
        profile.GameTokenSeconds.Should().Be(7, "0 initial + 5 + 3 - 1 = 7 seconds total");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_ShouldIncrementTotalAttempts()
    {
        // BUG: SessionMetrics.TotalAttempts is never incremented
        // Expected: TotalAttempts should increment with each problem
        // Actual: TotalAttempts remains 0
        
        // Arrange
        var profile = new StudentProfile { Id = "test-6", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act - Process 3 attempts
        var problem1 = CreateTestProblem(Domain.Math, "fractions-addition", difficulty: 5);
        var attempt1 = new ProblemAttempt { ProblemId = problem1.Id, IsCorrect = true, TimeSpentSeconds = 10 };
        await coordinator.ProcessAttemptAsync(attempt1, problem1, cts.Token);
        
        var problem2 = CreateTestProblem(Domain.Logic, "deduction", difficulty: 3);
        var attempt2 = new ProblemAttempt { ProblemId = problem2.Id, IsCorrect = false, TimeSpentSeconds = 8 };
        await coordinator.ProcessAttemptAsync(attempt2, problem2, cts.Token);
        
        var problem3 = CreateTestProblem(Domain.Reading, "inference", difficulty: 4);
        var attempt3 = new ProblemAttempt { ProblemId = problem3.Id, IsCorrect = true, TimeSpentSeconds = 12 };
        var feedback3 = await coordinator.ProcessAttemptAsync(attempt3, problem3, cts.Token);
        
        // Assert
        feedback3.SessionMetrics.TotalAttempts.Should().Be(3, "3 problems attempted");
        feedback3.SessionMetrics.TotalCorrect.Should().Be(2, "2 correct answers");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttemptAsync_CalculateAccuracy_ShouldUseCorrectDenominator()
    {
        // BUG: Without TotalAttempts, calculating accuracy percentage is impossible
        // Expected: Accuracy = TotalCorrect / TotalAttempts
        
        // Arrange
        var profile = new StudentProfile { Id = "test-7", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act - 3 correct, 2 incorrect = 60% accuracy
        for (int i = 0; i < 3; i++)
        {
            var problem = CreateTestProblem(Domain.Math, "test-skill", difficulty: 5);
            var attempt = new ProblemAttempt { ProblemId = problem.Id, IsCorrect = true, TimeSpentSeconds = 10 };
            await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        }
        
        for (int i = 0; i < 2; i++)
        {
            var problem = CreateTestProblem(Domain.Math, "test-skill", difficulty: 5);
            var attempt = new ProblemAttempt { ProblemId = problem.Id, IsCorrect = false, TimeSpentSeconds = 10 };
            await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        }
        
        var metrics = coordinator.GetCurrentMetrics();
        
        // Assert
        metrics.TotalAttempts.Should().Be(5, "5 total attempts");
        metrics.TotalCorrect.Should().Be(3, "3 correct");
        var accuracy = metrics.TotalAttempts > 0 ? (double)metrics.TotalCorrect / metrics.TotalAttempts : 0;
        accuracy.Should().BeApproximately(0.6, 0.01, "60% accuracy");
    }
    
    [TestMethod]
    [Timeout(5000)]
    public async Task GetNextProblemAsync_ShouldNotDeadlock_WhenCalledMultipleTimes()
    {
        // BUG: SessionCoordinator uses lock + .Wait()/.Result which can cause deadlocks
        // This test verifies the system doesn't hang
        
        // Arrange
        var profile = new StudentProfile { Id = "test-8", GameTokenSeconds = 0 };
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        
        // Act & Assert - Should complete without deadlock
        for (int i = 0; i < 5; i++)
        {
            var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);
            problem.Should().NotBeNull();
        }
    }
    
    // Helper methods
    private static Problem CreateTestProblem(Domain domain, string microTopic, int difficulty)
    {
        return new Problem
        {
            Id = Guid.NewGuid().ToString(),
            Domain = domain,
            MicroTopic = microTopic,
            Difficulty = difficulty,
            TargetTime = 30,
            Content = new ProblemContent
            {
                Question = "Test question",
                Format = ProblemFormat.MultipleChoice,
                Options = new List<string> { "A", "B", "C", "D" },
                CorrectAnswers = new List<string> { "A" }
            },
            Metadata = new ProblemMetadata()
        };
    }
    
    private static List<Problem> CreateTestProblems()
    {
        return new List<Problem>
        {
            CreateTestProblem(Domain.Math, "fractions-addition", 5),
            CreateTestProblem(Domain.Math, "algebra-linear", 7),
            CreateTestProblem(Domain.Logic, "deduction", 4),
            CreateTestProblem(Domain.Reading, "inference", 6),
            CreateTestProblem(Domain.Science, "hypothesis", 5)
        };
    }
}
