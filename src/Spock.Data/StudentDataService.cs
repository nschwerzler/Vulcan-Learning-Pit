using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Service for managing student data persistence with SQLite.
/// Handles session saving, loading, and querying for adaptive engine and parent dashboard.
/// </summary>
public class StudentDataService : IDisposable
{
    private readonly SpockDbContext _context;
    private readonly string _databasePath;

    public StudentDataService(string databasePath = "spock_learning.db")
    {
        _databasePath = databasePath;
        
        var connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();

        var options = new DbContextOptionsBuilder<SpockDbContext>()
            .UseSqlite(connectionString)
            .Options;

        _context = new SpockDbContext(options);
        
        // Ensure database is created
        _context.Database.EnsureCreated();
    }

    #region Student Profile Operations

    /// <summary>
    /// Get or create a student profile by name.
    /// </summary>
    public async Task<StudentProfile> GetOrCreateStudentAsync(string name, int age, CancellationToken cancellationToken = default)
    {
        var student = await _context.StudentProfiles
            .Include(s => s.SessionHistory)
            .Include(s => s.Weaknesses)
            .FirstOrDefaultAsync(s => s.Name == name, cancellationToken);

        if (student == null)
        {
            student = new StudentProfile
            {
                Name = name,
                Age = age,
                GameTokenSeconds = 0
            };
            _context.StudentProfiles.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return student;
    }

    /// <summary>
    /// Update student profile with current state.
    /// </summary>
    public async Task UpdateStudentAsync(StudentProfile student, CancellationToken cancellationToken = default)
    {
        _context.StudentProfiles.Update(student);
        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Session Operations

    /// <summary>
    /// Save a completed session with all attempts and approvals.
    /// </summary>
    public async Task SaveSessionAsync(Session session, CancellationToken cancellationToken = default)
    {
        // Ensure FK relationships are set
        foreach (var attempt in session.Problems)
        {
            attempt.SessionId = session.Id;
        }
        
        foreach (var approval in session.Approvals)
        {
            approval.SessionId = session.Id;
        }

        _context.Sessions.Add(session);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Get recent sessions for a student (for trend analysis).
    /// </summary>
    public async Task<List<Session>> GetRecentSessionsAsync(string studentId, int count = 10, CancellationToken cancellationToken = default)
    {
        return await _context.Sessions
            .Include(s => s.Problems)
            .Include(s => s.Approvals)
            .Where(s => s.StudentId == studentId)
            .OrderByDescending(s => s.StartTime)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Get all sessions for a student within a date range.
    /// </summary>
    public async Task<List<Session>> GetSessionsByDateRangeAsync(
        string studentId, 
        DateTime startDate, 
        DateTime endDate, 
        CancellationToken cancellationToken = default)
    {
        return await _context.Sessions
            .Include(s => s.Problems)
            .Include(s => s.Approvals)
            .Where(s => s.StudentId == studentId && s.StartTime >= startDate && s.StartTime <= endDate)
            .OrderByDescending(s => s.StartTime)
            .ToListAsync(cancellationToken);
    }

    #endregion

    #region Weakness Operations

    /// <summary>
    /// Get all active (unresolved) weaknesses for a student.
    /// </summary>
    public async Task<List<WeaknessRecord>> GetActiveWeaknessesAsync(string studentId, CancellationToken cancellationToken = default)
    {
        return await _context.WeaknessRecords
            .Where(w => w.StudentId == studentId && !w.IsResolved)
            .OrderBy(w => w.FirstDetected)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Get recently resolved weaknesses (for "conquest" feedback).
    /// </summary>
    public async Task<List<WeaknessRecord>> GetRecentConquestsAsync(
        string studentId, 
        int daysSince = 30, 
        CancellationToken cancellationToken = default)
    {
        var cutoff = DateTime.UtcNow.AddDays(-daysSince);
        return await _context.WeaknessRecords
            .Where(w => w.StudentId == studentId && w.IsResolved && w.ResolvedDate >= cutoff)
            .OrderByDescending(w => w.ResolvedDate)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Save or update a weakness record.
    /// </summary>
    public async Task SaveWeaknessAsync(WeaknessRecord weakness, CancellationToken cancellationToken = default)
    {
        var existing = await _context.WeaknessRecords
            .FirstOrDefaultAsync(w => w.StudentId == weakness.StudentId && w.SkillId == weakness.SkillId, cancellationToken);

        if (existing != null)
        {
            existing.LastAttempt = weakness.LastAttempt;
            existing.Accuracy = weakness.Accuracy;
            existing.IsResolved = weakness.IsResolved;
            existing.ResolvedDate = weakness.ResolvedDate;
            _context.WeaknessRecords.Update(existing);
        }
        else
        {
            _context.WeaknessRecords.Add(weakness);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Analytics & Reporting

    /// <summary>
    /// Get performance summary statistics for parent dashboard.
    /// </summary>
    public async Task<SessionStatistics> GetSessionStatisticsAsync(
        string studentId, 
        DateTime? since = null, 
        CancellationToken cancellationToken = default)
    {
        var cutoff = since ?? DateTime.MinValue;
        var sessions = await _context.Sessions
            .Include(s => s.Problems)
            .Where(s => s.StudentId == studentId && s.StartTime >= cutoff)
            .ToListAsync(cancellationToken);

        var stats = new SessionStatistics
        {
            TotalSessions = sessions.Count,
            TotalProblems = sessions.Sum(s => s.Problems.Count),
            TotalCorrect = sessions.Sum(s => s.Metrics.TotalCorrect),
            AverageAccuracy = sessions.Any() ? sessions.Average(s => s.Metrics.TotalCorrect / (double)Math.Max(1, s.Problems.Count)) : 0,
            TotalMinutes = sessions.Sum(s => (s.EndTime - s.StartTime)?.TotalMinutes ?? 0),
            TokensEarned = sessions.Sum(s => s.Metrics.TokensEarned)
        };

        return stats;
    }

    /// <summary>
    /// Get problem attempt history for a specific skill (for trend analysis).
    /// </summary>
    public async Task<List<ProblemAttempt>> GetSkillAttemptsAsync(
        string studentId,
        string skillId,
        int limit = 20,
        CancellationToken cancellationToken = default)
    {
        return await _context.ProblemAttempts
            .Join(_context.Sessions,
                attempt => attempt.SessionId,
                session => session.Id,
                (attempt, session) => new { Attempt = attempt, Session = session })
            .Where(x => x.Session.StudentId == studentId && x.Attempt.ProblemId.Contains(skillId))
            .OrderByDescending(x => x.Attempt.AttemptTime)
            .Take(limit)
            .Select(x => x.Attempt)
            .ToListAsync(cancellationToken);
    }

    #endregion

    public void Dispose()
    {
        _context?.Dispose();
    }
}

/// <summary>
/// Summary statistics for parent dashboard and analytics.
/// </summary>
public class SessionStatistics
{
    public int TotalSessions { get; set; }
    public int TotalProblems { get; set; }
    public int TotalCorrect { get; set; }
    public double AverageAccuracy { get; set; }
    public double TotalMinutes { get; set; }
    public int TokensEarned { get; set; }
}
