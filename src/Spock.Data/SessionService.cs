using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Service for persisting and retrieving session data.
/// Handles session history, metrics tracking, and analysis for Parent Dashboard.
/// </summary>
public class SessionService
{
    private readonly SpockDbContext _context;

    public SessionService(SpockDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Saves a completed session to the database.
    /// Updates student profile with latest metrics and weaknesses.
    /// </summary>
    public async Task<Session> SaveSessionAsync(Session session, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (session == null) throw new ArgumentNullException(nameof(session));
        if (string.IsNullOrEmpty(session.StudentId)) throw new ArgumentException("Session must have a StudentId");

        // Verify student exists
        var student = await _context.StudentProfiles
            .Include(s => s.SessionHistory)
            .FirstOrDefaultAsync(s => s.Id == session.StudentId, cancellationToken);

        if (student == null)
            throw new InvalidOperationException($"Student with ID {session.StudentId} not found");

        // Add session to database
        _context.Sessions.Add(session);

        // Update student profile session history
        student.SessionHistory.Add(session);

        await _context.SaveChangesAsync(cancellationToken);
        return session;
    }

    /// <summary>
    /// Gets all sessions for a student, ordered by most recent first.
    /// </summary>
    public async Task<List<Session>> GetSessionHistoryAsync(
        string studentId,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = _context.Sessions
            .Where(s => s.StudentId == studentId)
            .OrderByDescending(s => s.StartTime)
            .Include(s => s.Problems)
            .Include(s => s.Approvals)
            .AsQueryable();

        if (limit.HasValue)
            query = query.Take(limit.Value);

        return await query.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Gets the most recent session for a student.
    /// </summary>
    public async Task<Session?> GetLastSessionAsync(string studentId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context.Sessions
            .Where(s => s.StudentId == studentId)
            .OrderByDescending(s => s.StartTime)
            .Include(s => s.Problems)
            .Include(s => s.Approvals)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Gets session count for a student within a date range.
    /// </summary>
    public async Task<int> GetSessionCountAsync(
        string studentId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context.Sessions
            .Where(s => s.StudentId == studentId &&
                       s.StartTime >= startDate &&
                       s.StartTime <= endDate)
            .CountAsync(cancellationToken);
    }

    /// <summary>
    /// Gets aggregate metrics across multiple sessions for Parent Dashboard.
    /// </summary>
    public async Task<AggregateMetrics> GetAggregateMetricsAsync(
        string studentId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var sessions = await _context.Sessions
            .Where(s => s.StudentId == studentId &&
                       s.StartTime >= startDate &&
                       s.StartTime <= endDate)
            .Include(s => s.Problems)
            .Include(s => s.Approvals)
            .ToListAsync(cancellationToken);

        if (!sessions.Any())
        {
            return new AggregateMetrics
            {
                StudentId = studentId,
                StartDate = startDate,
                EndDate = endDate,
                TotalSessions = 0
            };
        }

        var totalProblems = sessions.Sum(s => s.Problems.Count);
        var totalCorrect = sessions.Sum(s => s.Metrics.TotalCorrect);
        var totalTime = sessions.Sum(s => s.Metrics.AverageTime * s.Problems.Count);
        var totalApprovals = sessions.Sum(s => s.Approvals.Count);

        return new AggregateMetrics
        {
            StudentId = studentId,
            StartDate = startDate,
            EndDate = endDate,
            TotalSessions = sessions.Count,
            TotalProblems = totalProblems,
            TotalCorrect = totalCorrect,
            OverallAccuracy = totalProblems > 0 ? (double)totalCorrect / totalProblems : 0,
            AverageSessionLength = sessions.Any() ? sessions.Average(s => 
            {
                var endTime = s.EndTime ?? s.StartTime;
                return (endTime - s.StartTime).TotalMinutes;
            }) : 0,
            TotalApprovals = totalApprovals,
            ApprovalFrequency = totalProblems > 0 ? (double)totalApprovals / totalProblems : 0,
            AverageFocusScore = sessions.Average(s => s.Metrics.FocusScore),
            DomainsVisited = sessions.SelectMany(s => s.Metrics.DomainsVisited).Distinct().ToList(),
            WeaknessesResolved = sessions.SelectMany(s => s.Metrics.WeaknessesResolved).Distinct().ToList()
        };
    }

    /// <summary>
    /// Gets weakness performance over time for trend analysis.
    /// Note: Since ProblemAttempt doesn't store MicroTopic, this method
    /// returns aggregate trend data for all problems in a given domain.
    /// For skill-specific trends, filter by Domain instead.
    /// </summary>
    public async Task<List<WeaknessPerformanceTrend>> GetWeaknessTrendsAsync(
        string studentId,
        Domain domain,
        int daysBack = 30,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var startDate = DateTime.UtcNow.AddDays(-daysBack);

        var attempts = await _context.ProblemAttempts
            .Where(a => a.SessionId != null &&
                       a.Domain == domain &&
                       a.AttemptTime >= startDate)
            .Join(_context.Sessions,
                attempt => attempt.SessionId,
                session => session.Id,
                (attempt, session) => new { Attempt = attempt, Session = session })
            .Where(x => x.Session.StudentId == studentId)
            .Select(x => x.Attempt)
            .OrderBy(a => a.AttemptTime)
            .ToListAsync(cancellationToken);

        // Group by day and calculate daily accuracy
        var trends = attempts
            .GroupBy(a => a.AttemptTime.Date)
            .Select(g => new WeaknessPerformanceTrend
            {
                Date = g.Key,
                Domain = domain,
                AttemptsCount = g.Count(),
                CorrectCount = g.Count(a => a.IsCorrect),
                Accuracy = g.Count() > 0 ? (double)g.Count(a => a.IsCorrect) / g.Count() : 0,
                AverageTime = g.Average(a => a.TimeSpentSeconds)
            })
            .OrderBy(t => t.Date)
            .ToList();

        return trends;
    }

    /// <summary>
    /// Deletes old sessions to manage database size.
    /// Keeps sessions from the last N days.
    /// </summary>
    public async Task<int> CleanupOldSessionsAsync(
        int daysToKeep = 180,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var cutoffDate = DateTime.UtcNow.AddDays(-daysToKeep);

        var oldSessions = await _context.Sessions
            .Where(s => s.StartTime < cutoffDate)
            .ToListAsync(cancellationToken);

        _context.Sessions.RemoveRange(oldSessions);
        var deletedCount = await _context.SaveChangesAsync(cancellationToken);

        return deletedCount;
    }
}

/// <summary>
/// Aggregated metrics across multiple sessions for dashboard display.
/// </summary>
public class AggregateMetrics
{
    public string StudentId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalSessions { get; set; }
    public int TotalProblems { get; set; }
    public int TotalCorrect { get; set; }
    public double OverallAccuracy { get; set; }
    public double AverageSessionLength { get; set; }  // minutes
    public int TotalApprovals { get; set; }
    public double ApprovalFrequency { get; set; }      // approvals per problem
    public double AverageFocusScore { get; set; }
    public List<string> DomainsVisited { get; set; } = new();
    public List<string> WeaknessesResolved { get; set; } = new();
}

/// <summary>
/// Performance trend data for a domain over time.
/// Used for Parent Dashboard visualization.
/// </summary>
public class WeaknessPerformanceTrend
{
    public DateTime Date { get; set; }
    public Domain Domain { get; set; }
    public int AttemptsCount { get; set; }
    public int CorrectCount { get; set; }
    public double Accuracy { get; set; }
    public double AverageTime { get; set; }
}
