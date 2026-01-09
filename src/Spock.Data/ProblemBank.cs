using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Comprehensive problem bank for adaptive learning across domains.
/// Problems are stored in SQLite database - database is the source of truth.
/// Total: 652+ problems covering Grade 1 through College level.
/// Includes: Math, Logic, Reading, Science, Win Pants (Dale Carnegie + Sun Tzu), 
/// Washington History, Bitcoin (including Mises principles), Minecraft, and Health.
/// </summary>
public static class ProblemBank
{
    private static SpockDbContext? _context;

    /// <summary>
    /// Initializes the problem bank with a database context.
    /// Must be called before using GetAllProblems() or other query methods.
    /// </summary>
    public static void Initialize(SpockDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets all available problems from the database.
    /// Problems are shuffled randomly to prevent repetition.
    /// </summary>
    public static async Task<List<Problem>> GetAllProblemsAsync(CancellationToken cancellationToken = default)
    {
        if (_context == null)
            throw new InvalidOperationException("ProblemBank must be initialized with Initialize() before use.");

        var entities = await _context.Problems
            .Include(p => p.Guidance)
            .ToListAsync(cancellationToken);

        var problems = entities.Select(e => e.ToProblem()).ToList();

        // Shuffle to prevent seeing same questions in same order
        var random = new Random();
        return problems.OrderBy(p => random.Next()).ToList();
    }

    /// <summary>
    /// Gets problems filtered by domain.
    /// </summary>
    public static async Task<List<Problem>> GetProblemsByDomainAsync(Domain domain, CancellationToken cancellationToken = default)
    {
        if (_context == null)
            throw new InvalidOperationException("ProblemBank must be initialized with Initialize() before use.");

        var entities = await _context.Problems
            .Include(p => p.Guidance)
            .Where(p => p.Domain == domain)
            .ToListAsync(cancellationToken);

        var problems = entities.Select(e => e.ToProblem()).ToList();

        // Shuffle to prevent seeing same questions in same order
        var random = new Random();
        return problems.OrderBy(p => random.Next()).ToList();
    }

    /// <summary>
    /// Gets problems filtered by difficulty level (1-10).
    /// </summary>
    public static async Task<List<Problem>> GetProblemsByDifficultyAsync(int minDifficulty, int maxDifficulty, CancellationToken cancellationToken = default)
    {
        if (_context == null)
            throw new InvalidOperationException("ProblemBank must be initialized with Initialize() before use.");

        var entities = await _context.Problems
            .Include(p => p.Guidance)
            .Where(p => p.Difficulty >= minDifficulty && p.Difficulty <= maxDifficulty)
            .ToListAsync(cancellationToken);

        var problems = entities.Select(e => e.ToProblem()).ToList();

        // Shuffle to prevent seeing same questions in same order
        var random = new Random();
        return problems.OrderBy(p => random.Next()).ToList();
    }

    /// <summary>
    /// Gets problems filtered by domain and difficulty range.
    /// </summary>
    public static async Task<List<Problem>> GetProblemsByDomainAndDifficultyAsync(
        Domain domain, 
        int minDifficulty, 
        int maxDifficulty, 
        CancellationToken cancellationToken = default)
    {
        if (_context == null)
            throw new InvalidOperationException("ProblemBank must be initialized with Initialize() before use.");

        var entities = await _context.Problems
            .Include(p => p.Guidance)
            .Where(p => p.Domain == domain && p.Difficulty >= minDifficulty && p.Difficulty <= maxDifficulty)
            .ToListAsync(cancellationToken);

        var problems = entities.Select(e => e.ToProblem()).ToList();

        // Shuffle to prevent seeing same questions in same order
        var random = new Random();
        return problems.OrderBy(p => random.Next()).ToList();
    }

    /// <summary>
    /// Gets problems filtered by micro-topic (e.g., "fractions-addition", "deductive-chains").
    /// </summary>
    public static async Task<List<Problem>> GetProblemsByMicroTopicAsync(string microTopic, CancellationToken cancellationToken = default)
    {
        if (_context == null)
            throw new InvalidOperationException("ProblemBank must be initialized with Initialize() before use.");

        var entities = await _context.Problems
            .Include(p => p.Guidance)
            .Where(p => p.MicroTopic == microTopic)
            .ToListAsync(cancellationToken);

        var problems = entities.Select(e => e.ToProblem()).ToList();

        // Shuffle to prevent seeing same questions in same order
        var random = new Random();
        return problems.OrderBy(p => random.Next()).ToList();
    }

    #region Legacy Seeding (Removed)

    /// <summary>
    /// LEGACY: This method previously returned 552+ hardcoded problems for database seeding.
    /// All hardcoded problem definitions have been removed to reduce codebase from ~11,800 to ~130 lines.
    /// 
    /// For fresh database setup:
    /// 1. Copy an existing populated spock.db file
    /// 2. Use SQL export/import scripts
    /// 3. Use EF Core migrations with seed data
    /// 
    /// The SQLite database is now the authoritative source of truth for all problems.
    /// </summary>
    [Obsolete("Hardcoded problems removed. Use database file copies, SQL scripts, or migrations for seeding.", true)]
    internal static List<Problem> GetAllProblemsFromCode()
    {
        throw new NotSupportedException(
            "Legacy hardcoded problems have been removed to reduce codebase size. " +
            "Database seeding should use SQL scripts, migrations, or database file copies. " +
            "The codebase now relies on SQLite as the source of truth for all problems.");
    }

    #endregion
}
