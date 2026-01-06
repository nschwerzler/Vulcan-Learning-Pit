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
    }
}
