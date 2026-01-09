using Microsoft.EntityFrameworkCore;
using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Entity Framework Core database context for Vulcan Learning Pit.
/// Manages session persistence, student profiles, and problem history.
/// </summary>
public class SpockDbContext : DbContext
{
    public SpockDbContext(DbContextOptions<SpockDbContext> options) : base(options)
    {
    }

    public DbSet<StudentProfile> StudentProfiles { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<ProblemAttempt> ProblemAttempts { get; set; } = null!;
    public DbSet<WeaknessRecord> WeaknessRecords { get; set; } = null!;
    public DbSet<ApprovalEvent> ApprovalEvents { get; set; } = null!;
    public DbSet<ProblemEntity> Problems { get; set; } = null!;
    public DbSet<SolutionGuidanceEntity> SolutionGuidances { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure StudentProfile
        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.GameTokenSeconds).HasDefaultValue(0);
            entity.Property(e => e.CurrentDomain).HasConversion<string>();
            
            // Configure owned entities (stored as JSON in single column)
            entity.OwnsOne(e => e.Level, level =>
            {
                level.Property(l => l.Math).IsRequired().HasMaxLength(50);
                level.Property(l => l.Logic).IsRequired();
                level.Property(l => l.Reading).IsRequired().HasMaxLength(50);
                level.Property(l => l.Science).IsRequired().HasMaxLength(50);
            });
            
            entity.OwnsOne(e => e.Preferences, prefs =>
            {
                prefs.Property(p => p.FocusDuration).IsRequired();
            });
            
            entity.OwnsOne(e => e.ParentSettings, settings =>
            {
                settings.Property(s => s.SessionLengthCap).IsRequired();
                settings.Property(s => s.MaxSessionsPerDay).IsRequired();
                settings.Property(s => s.AccelerationAllowed).IsRequired();
                settings.Property(s => s.DashboardNotifications).IsRequired();
            });
            
            // One-to-many relationship with sessions
            entity.HasMany(e => e.SessionHistory)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            
            // One-to-many relationship with weakness records
            entity.HasMany(e => e.Weaknesses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Session
        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StudentId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndReason).HasConversion<string>();
            
            // Session metrics stored as owned entity (JSON column)
            entity.OwnsOne(e => e.Metrics, metrics =>
            {
                metrics.Property(m => m.TotalCorrect).IsRequired();
                metrics.Property(m => m.TotalAttempts).IsRequired();
                metrics.Property(m => m.AverageTime).IsRequired();
                metrics.Property(m => m.FocusScore).IsRequired();
                metrics.Property(m => m.TokensEarned).IsRequired();
            });
            
            // One-to-many relationship with problem attempts
            entity.HasMany(e => e.Problems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure ProblemAttempt
        modelBuilder.Entity<ProblemAttempt>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SessionId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ProblemId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Domain).HasConversion<string>();
            entity.Property(e => e.AttemptTime).IsRequired();
            entity.Property(e => e.IsCorrect).IsRequired();
            entity.Property(e => e.Difficulty).IsRequired();
            
            // Index for performance
            entity.HasIndex(e => new { e.SessionId, e.AttemptTime });
            entity.HasIndex(e => e.ProblemId);
        });

        // Configure WeaknessRecord
        modelBuilder.Entity<WeaknessRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StudentId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SkillId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Domain).HasConversion<string>();
            entity.Property(e => e.FirstDetected).IsRequired();
            entity.Property(e => e.Accuracy).IsRequired();
            entity.Property(e => e.IsResolved).IsRequired();
            
            // Index for querying active weaknesses
            entity.HasIndex(e => new { e.StudentId, e.IsResolved });
            entity.HasIndex(e => e.SkillId);
        });

        // Configure ApprovalEvent
        modelBuilder.Entity<ApprovalEvent>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SessionId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Timestamp).IsRequired();
            entity.Property(e => e.Type).HasConversion<string>();
            entity.Property(e => e.Message).HasMaxLength(500);
            
            // Index for timeline queries
            entity.HasIndex(e => new { e.SessionId, e.Timestamp });
        });

        // Configure ProblemEntity
        modelBuilder.Entity<ProblemEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Domain).IsRequired().HasConversion<string>();
            entity.Property(e => e.MicroTopic).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Difficulty).IsRequired();
            entity.Property(e => e.TargetTime).IsRequired();
            entity.Property(e => e.Question).IsRequired();
            entity.Property(e => e.Format).IsRequired().HasConversion<string>();
            entity.Property(e => e.CorrectAnswers).IsRequired().HasConversion(
                v => string.Join("|||", v),
                v => v.Split("|||", StringSplitOptions.RemoveEmptyEntries).ToList());
            entity.Property(e => e.Options).HasConversion(
                v => v == null || v.Count == 0 ? null : string.Join("|||", v),
                v => string.IsNullOrEmpty(v) ? new List<string>() : v.Split("|||", StringSplitOptions.RemoveEmptyEntries).ToList());

            // One-to-one relationship with SolutionGuidance
            entity.HasOne(e => e.Guidance)
                .WithOne()
                .HasForeignKey<SolutionGuidanceEntity>(g => g.ProblemId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes for efficient querying
            entity.HasIndex(e => e.Domain);
            entity.HasIndex(e => e.MicroTopic);
            entity.HasIndex(e => e.Difficulty);
            entity.HasIndex(e => new { e.Domain, e.Difficulty });
        });

        // Configure SolutionGuidanceEntity
        modelBuilder.Entity<SolutionGuidanceEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProblemId).IsRequired();
            entity.Property(e => e.HintMinimal).HasMaxLength(500);
            entity.Property(e => e.StepsDetailed).HasConversion(
                v => v == null || v.Count == 0 ? null : string.Join("|||", v),
                v => string.IsNullOrEmpty(v) ? new List<string>() : v.Split("|||", StringSplitOptions.RemoveEmptyEntries).ToList());
            entity.Property(e => e.WorkedExample).HasMaxLength(2000);
            entity.Property(e => e.KeyPrinciple).HasMaxLength(1000);
            entity.Property(e => e.CommonMistake).HasMaxLength(1000);
        });
    }
}

/// <summary>
/// Database entity for Problem model.
/// Flattened structure optimized for SQLite storage.
/// </summary>
public class ProblemEntity
{
    public int Id { get; set; }
    public Domain Domain { get; set; }
    public string MicroTopic { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    public int TargetTime { get; set; }
    
    // Flattened ProblemContent
    public string Question { get; set; } = string.Empty;
    public ProblemFormat Format { get; set; }
    public List<string> CorrectAnswers { get; set; } = new();
    public List<string>? Options { get; set; }
    
    // Navigation property
    public SolutionGuidanceEntity? Guidance { get; set; }

    /// <summary>
    /// Converts database entity to domain model.
    /// </summary>
    public Problem ToProblem()
    {
        return new Problem
        {
            Domain = this.Domain,
            MicroTopic = this.MicroTopic,
            Difficulty = this.Difficulty,
            TargetTime = this.TargetTime,
            Content = new ProblemContent
            {
                Question = this.Question,
                Format = this.Format,
                CorrectAnswers = this.CorrectAnswers,
                Options = this.Options ?? new List<string>(),
                Guidance = this.Guidance?.ToSolutionGuidance() ?? new SolutionGuidance()
            }
        };
    }

    /// <summary>
    /// Converts domain model to database entity.
    /// </summary>
    public static ProblemEntity FromProblem(Problem problem)
    {
        var entity = new ProblemEntity
        {
            Domain = problem.Domain,
            MicroTopic = problem.MicroTopic,
            Difficulty = problem.Difficulty,
            TargetTime = problem.TargetTime,
            Question = problem.Content.Question,
            Format = problem.Content.Format,
            CorrectAnswers = problem.Content.CorrectAnswers,
            Options = problem.Content.Options
        };

        if (problem.Content.Guidance != null)
        {
            entity.Guidance = SolutionGuidanceEntity.FromSolutionGuidance(problem.Content.Guidance);
        }

        return entity;
    }
}

/// <summary>
/// Database entity for SolutionGuidance model.
/// </summary>
public class SolutionGuidanceEntity
{
    public int Id { get; set; }
    public int ProblemId { get; set; }
    public string? HintMinimal { get; set; }
    public List<string>? StepsDetailed { get; set; }
    public string? WorkedExample { get; set; }
    public string? KeyPrinciple { get; set; }
    public string? CommonMistake { get; set; }

    public SolutionGuidance ToSolutionGuidance()
    {
        return new SolutionGuidance
        {
            HintMinimal = this.HintMinimal ?? string.Empty,
            StepsDetailed = this.StepsDetailed ?? new List<string>(),
            WorkedExample = this.WorkedExample ?? string.Empty,
            KeyPrinciple = this.KeyPrinciple ?? string.Empty,
            CommonMistake = this.CommonMistake ?? string.Empty
        };
    }

    public static SolutionGuidanceEntity FromSolutionGuidance(SolutionGuidance guidance)
    {
        return new SolutionGuidanceEntity
        {
            HintMinimal = guidance.HintMinimal,
            StepsDetailed = guidance.StepsDetailed,
            WorkedExample = guidance.WorkedExample,
            KeyPrinciple = guidance.KeyPrinciple,
            CommonMistake = guidance.CommonMistake
        };
    }
}
