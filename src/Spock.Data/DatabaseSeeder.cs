using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Database seeding and management utilities.
/// NOTE: Legacy hardcoded problem seeding has been removed.
/// Database should be populated from existing VulcanKnowledge.db file or SQL import scripts.
/// </summary>
public static class DatabaseSeeder
{
    /// <summary>
    /// Ensures database is created. Does NOT seed problems from code (legacy method removed).
    /// For fresh database setup:
    /// 1. Copy an existing populated VulcanKnowledge.db file to the application directory
    /// 2. Import problems from SQL export file
    /// 3. Use EF Core migrations with seed data
    /// 
    /// Call this on application startup to ensure database schema exists.
    /// </summary>
    public static async Task SeedDatabaseAsync(SpockDbContext context, CancellationToken cancellationToken = default)
    {
        // Ensure database is created
        await context.Database.EnsureCreatedAsync(cancellationToken);

        // Check if problems already exist
        var problemCount = await context.Problems.CountAsync(cancellationToken);
        if (problemCount > 0)
        {
            Console.WriteLine($"Database already contains {problemCount} problems.");
            return;
        }

        // No problems in database - user needs to populate it
        Console.WriteLine("WARNING: Database is empty. No problems found.");
        Console.WriteLine("To populate the database:");
        Console.WriteLine("  1. Copy an existing VulcanKnowledge.db file to the application directory");
        Console.WriteLine("  2. Import problems from SQL export file");
        Console.WriteLine("  3. Use EF Core migrations with seed data");
        Console.WriteLine();
        Console.WriteLine("Legacy hardcoded problem seeding has been removed to reduce codebase size.");
    }

    /// <summary>
    /// Clears all problems and solution guidances from the database.
    /// WARNING: This will delete all problem data. Ensure you have a backup!
    /// </summary>
    public static async Task ClearDatabaseAsync(SpockDbContext context, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("WARNING: Clearing all problems from database...");
        
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Problems", cancellationToken);
        await context.Database.ExecuteSqlRawAsync("DELETE FROM SolutionGuidances", cancellationToken);
        
        Console.WriteLine("Database cleared. Import new data or copy a populated database file.");
    }

    /// <summary>
    /// Gets database statistics for monitoring and debugging.
    /// </summary>
    public static async Task<DatabaseStats> GetDatabaseStatsAsync(SpockDbContext context, CancellationToken cancellationToken = default)
    {
        var stats = new DatabaseStats
        {
            TotalProblems = await context.Problems.CountAsync(cancellationToken),
            ProblemsByDomain = new Dictionary<Domain, int>()
        };

        foreach (Domain domain in Enum.GetValues(typeof(Domain)))
        {
            var count = await context.Problems.CountAsync(p => p.Domain == domain, cancellationToken);
            if (count > 0)
            {
                stats.ProblemsByDomain[domain] = count;
            }
        }

        return stats;
    }
}

/// <summary>
/// Database statistics for monitoring problem counts.
/// </summary>
public class DatabaseStats
{
    public int TotalProblems { get; set; }
    public Dictionary<Domain, int> ProblemsByDomain { get; set; } = new();

    public override string ToString()
    {
        var lines = new List<string>
        {
            $"Total Problems: {TotalProblems}",
            "Problems by Domain:"
        };
        
        foreach (var kvp in ProblemsByDomain.OrderBy(x => x.Key))
        {
            lines.Add($"  {kvp.Key}: {kvp.Value}");
        }
        
        return string.Join(Environment.NewLine, lines);
    }
}
