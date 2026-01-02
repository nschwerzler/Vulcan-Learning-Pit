using VulcanLearningPit.Models;

namespace VulcanLearningPit.Services;

public class SessionService
{
    private readonly ProblemGeneratorService _problemGenerator;
    private readonly AdaptiveDifficultyService _adaptiveService;
    private ProblemSession? _currentSession;
    private Problem? _currentProblem;
    private DateTime _problemStartTime;

    public SessionService(ProblemGeneratorService problemGenerator, AdaptiveDifficultyService adaptiveService)
    {
        _problemGenerator = problemGenerator;
        _adaptiveService = adaptiveService;
    }

    public void StartSession(StudentProfile student)
    {
        _currentSession = new ProblemSession
        {
            Student = student,
            StartTime = DateTime.Now,
            CurrentSubject = _adaptiveService.IdentifyWeakestSubject(student.SubjectStatistics)
        };
    }

    public Problem GetNextProblem()
    {
        if (_currentSession == null)
            throw new InvalidOperationException("No active session");

        var stats = _currentSession.Student.SubjectStatistics[_currentSession.CurrentSubject];
        var difficulty = stats.CurrentDifficulty;

        _currentProblem = _problemGenerator.GenerateProblem(
            _currentSession.CurrentSubject,
            difficulty,
            _currentSession.Student.Grade);

        _problemStartTime = DateTime.Now;
        return _currentProblem;
    }

    public ProblemAttempt SubmitAnswer(string answer)
    {
        if (_currentSession == null || _currentProblem == null)
            throw new InvalidOperationException("No active problem");

        var endTime = DateTime.Now;
        var isCorrect = answer.Trim().Equals(_currentProblem.CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);

        var attempt = new ProblemAttempt
        {
            Problem = _currentProblem,
            StudentAnswer = answer,
            IsCorrect = isCorrect,
            StartTime = _problemStartTime,
            EndTime = endTime
        };

        // Calculate points and tokens
        if (isCorrect)
        {
            var timeBonus = CalculateTimeBonus(attempt.ResponseTime, _currentProblem.TimeLimit);
            attempt.PointsEarned = _currentProblem.PointValue + timeBonus;
            attempt.TokensEarned = CalculateTokens(_currentProblem.Difficulty, timeBonus);
        }

        // Update session stats
        _currentSession.Attempts.Add(attempt);
        _currentSession.TotalScore += attempt.PointsEarned;
        _currentSession.TokensEarned += attempt.TokensEarned;

        // Update student stats
        UpdateStudentStats(attempt);

        return attempt;
    }

    public void SwitchSubject(SubjectType? newSubject = null)
    {
        if (_currentSession == null)
            throw new InvalidOperationException("No active session");

        if (newSubject.HasValue)
        {
            _currentSession.CurrentSubject = newSubject.Value;
        }
        else
        {
            _currentSession.CurrentSubject = _adaptiveService.SelectNextSubject(
                _currentSession.Student.SubjectStatistics,
                _currentSession.CurrentSubject);
        }
    }

    public void EndSession()
    {
        if (_currentSession == null)
            return;

        _currentSession.EndTime = DateTime.Now;
        
        // Update student profile
        _currentSession.Student.TotalTokens += _currentSession.TokensEarned;
        _currentSession.Student.TotalScore += _currentSession.TotalScore;
        _currentSession.Student.LastSessionDate = DateTime.Now;

        _currentSession = null;
        _currentProblem = null;
    }

    public ProblemSession? GetCurrentSession() => _currentSession;

    public SubjectType GetCurrentSubject() => _currentSession?.CurrentSubject ?? SubjectType.Math;

    private void UpdateStudentStats(ProblemAttempt attempt)
    {
        if (_currentSession == null)
            return;

        var stats = _currentSession.Student.SubjectStatistics[attempt.Problem.Subject];
        
        stats.TotalAttempts++;
        if (attempt.IsCorrect)
        {
            stats.CorrectAnswers++;
            stats.ConsecutiveCorrect++;
            stats.ConsecutiveIncorrect = 0;
        }
        else
        {
            stats.ConsecutiveIncorrect++;
            stats.ConsecutiveCorrect = 0;
        }

        // Update average response time
        var totalTime = stats.AverageResponseTime * (stats.TotalAttempts - 1) + attempt.ResponseTime.TotalSeconds;
        stats.AverageResponseTime = totalTime / stats.TotalAttempts;

        // Adjust difficulty
        stats.CurrentDifficulty = _adaptiveService.AdjustDifficulty(stats);
    }

    private int CalculateTimeBonus(TimeSpan responseTime, int timeLimit)
    {
        var percentageUsed = responseTime.TotalSeconds / timeLimit;
        
        if (percentageUsed <= 0.5) // Answered in half the time
            return 15;
        else if (percentageUsed <= 0.75)
            return 10;
        else if (percentageUsed <= 1.0)
            return 5;
        else
            return 0; // Over time limit
    }

    private int CalculateTokens(DifficultyLevel difficulty, int timeBonus)
    {
        var baseTokens = difficulty switch
        {
            DifficultyLevel.Easy => 1,
            DifficultyLevel.Medium => 2,
            DifficultyLevel.Hard => 3,
            DifficultyLevel.Expert => 5,
            _ => 1
        };

        return baseTokens + (timeBonus > 0 ? 1 : 0);
    }
}
