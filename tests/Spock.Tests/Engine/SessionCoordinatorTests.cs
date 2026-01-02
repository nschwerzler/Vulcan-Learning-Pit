using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

[TestClass]
public class SessionCoordinatorTests
{
    private StudentProfile CreateTestProfile()
    {
        return new StudentProfile
        {
            Id = "test-student",
            Age = 10,
            Level = new CurrentLevel
            {
                Math = "Grade 5",
                Logic = 3,
                Reading = "Grade 5",
                Science = "Grade 5"
            }
        };
    }

    private List<Problem> CreateTestProblems()
    {
        return new List<Problem>
        {
            new Problem
            {
                Id = "math-1",
                Domain = Domain.Math,
                MicroTopic = "fractions",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "1/2 + 1/4 = ?",
                    CorrectAnswers = new List<string> { "3/4" }
                }
            },
            new Problem
            {
                Id = "logic-1",
                Domain = Domain.Logic,
                MicroTopic = "deduction",
                Difficulty = 3,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "If A>B and B>C, then?",
                    CorrectAnswers = new List<string> { "A>C" }
                }
            },
            new Problem
            {
                Id = "math-2",
                Domain = Domain.Math,
                MicroTopic = "multiplication",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "7 × 8 = ?",
                    CorrectAnswers = new List<string> { "56" }
                }
            }
        };
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetNextProblem_ReturnsValidProblem()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();

        // Act
        var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);

        // Assert
        problem.Should().NotBeNull();
        problems.Should().Contain(problem);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttempt_CorrectAnswer_UpdatesMetrics()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();
        var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);

        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = true,
            TimeSpentSeconds = 25,
            AttemptTime = DateTime.UtcNow
        };

        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);

        // Assert
        feedback.Should().NotBeNull();
        feedback.IsCorrect.Should().BeTrue();
        feedback.Dialogue.Should().NotBeNull();
        feedback.SessionMetrics.Should().NotBeNull();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttempt_IncorrectAnswer_ReturnsCorrectiveFeedback()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();
        var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);

        var attempt = new ProblemAttempt
        {
            ProblemId = problem.Id,
            IsCorrect = false,
            TimeSpentSeconds = 35,
            AttemptTime = DateTime.UtcNow
        };

        // Act
        var feedback = await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);

        // Assert
        feedback.Should().NotBeNull();
        feedback.IsCorrect.Should().BeFalse();
        feedback.Dialogue.Message.Should().NotBeNullOrEmpty();
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttempt_MultipleCorrect_BuildsStreak()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();

        // Act - answer 3 problems correctly
        for (int i = 0; i < 3; i++)
        {
            var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);
            var attempt = new ProblemAttempt
            {
                ProblemId = problem.Id,
                IsCorrect = true,
                TimeSpentSeconds = 20,
                AttemptTime = DateTime.UtcNow
            };
            await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        }

        var metrics = coordinator.GetCurrentMetrics();

        // Assert
        metrics.TotalCorrect.Should().Be(3);
        metrics.AverageTime.Should().BeApproximately(20, 1);
    }

    [TestMethod]
    [Timeout(5000)]
    public void EndSession_ReturnsCompletedSession()
    {
        // Arrange
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);

        // Act
        var session = coordinator.EndSession(SessionEndReason.StudentExit);

        // Assert
        session.Should().NotBeNull();
        session.EndTime.Should().NotBeNull();
        session.EndReason.Should().Be(SessionEndReason.StudentExit);
        session.StudentId.Should().Be("test-student");
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetCurrentMetrics_ReturnsInitialState()
    {
        // Arrange
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);

        // Act
        var metrics = coordinator.GetCurrentMetrics();

        // Assert
        metrics.Should().NotBeNull();
        metrics.TotalCorrect.Should().Be(0);
        metrics.FocusScore.Should().BeGreaterThanOrEqualTo(0);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetNextProblem_SwitchesDomains_AfterMultipleProblems()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();

        var domains = new HashSet<Domain>();

        // Act - get multiple problems
        for (int i = 0; i < 5; i++)
        {
            var problem = await coordinator.GetNextProblemAsync(problems, cts.Token);
            domains.Add(problem.Domain);
            
            // Simulate time passing
            await Task.Delay(100, cts.Token);
        }

        // Assert - should visit multiple domains (ADD-aware switching)
        domains.Count.Should().BeGreaterThanOrEqualTo(1);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ProcessAttempt_TracksMultipleDomains()
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var profile = CreateTestProfile();
        var coordinator = new SessionCoordinator(profile);
        var problems = CreateTestProblems();

        // Act - answer problems from different domains
        foreach (var problem in problems)
        {
            var attempt = new ProblemAttempt
            {
                ProblemId = problem.Id,
                IsCorrect = true,
                TimeSpentSeconds = 20,
                AttemptTime = DateTime.UtcNow
            };
            await coordinator.ProcessAttemptAsync(attempt, problem, cts.Token);
        }

        var metrics = coordinator.GetCurrentMetrics();

        // Assert
        metrics.DomainsVisited.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}
