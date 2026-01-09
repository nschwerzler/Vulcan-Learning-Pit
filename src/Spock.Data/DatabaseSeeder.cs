using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Seeds the database with problem bank data on first run.
/// Loads problems from ProblemBank.cs and populates SQLite database.
/// </summary>
public static class DatabaseSeeder
{
    /// <summary>
    /// Ensures database is created and seeded with initial problem data.
    /// Call this on application startup before using ProblemBank.
    /// </summary>
    public static async Task SeedDatabaseAsync(SpockDbContext context, CancellationToken cancellationToken = default)
    {
        // Ensure database is created
        await context.Database.EnsureCreatedAsync(cancellationToken);

        // Check if problems already exist
        var problemCount = await context.Problems.CountAsync(cancellationToken);
        if (problemCount > 0)
        {
            // Database already seeded
            return;
        }

        // Get all problems from the static problem bank
        var problems = ProblemBank.GetAllProblemsFromCode();

        // Convert to entities and add to database
        var entities = problems.Select(ProblemEntity.FromProblem).ToList();
        
        await context.Problems.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        Console.WriteLine($"Database seeded with {entities.Count} problems.");
    }

    /// <summary>
    /// Re-seeds the database by clearing all problems and re-adding from code.
    /// Use this when ProblemBank.cs has been updated with new content.
    /// </summary>
    public static async Task ReseedDatabaseAsync(SpockDbContext context, CancellationToken cancellationToken = default)
    {
        // Clear existing problems
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Problems", cancellationToken);
        await context.Database.ExecuteSqlRawAsync("DELETE FROM SolutionGuidances", cancellationToken);

        // Re-seed
        await SeedDatabaseAsync(context, cancellationToken);
    }
}
