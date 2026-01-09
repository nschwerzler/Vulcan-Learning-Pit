# Database Management Guide

## Overview

As of January 2026, the Vulcan Learning Pit project uses **SQLite as the single source of truth** for all problem data. Legacy hardcoded problems have been removed from the codebase.

**Key Statistics:**
- **Before:** ProblemBank.cs was ~11,898 lines and ~600KB
- **After:** ProblemBank.cs is ~153 lines and ~6KB
- **Reduction:** 98.7% smaller codebase

## Database Location

The SQLite database file is located at:
- **Development & Production:** `database/spock.db` (workspace root)

The application automatically creates the `database\` folder if it doesn't exist.

## Setting Up a Fresh Database

If you need to set up a fresh database instance, you have several options:

### Option 1: Copy Existing Database (Recommended)
```powershell
# Copy the populated database file to workspace root
Copy-Item "path/to/populated/spock.db" -Destination "database/spock.db"
```

### Option 2: SQL Import
1. Export problems from existing database:
   ```powershell
   sqlite3 spock.db ".dump Problems SolutionGuidances" > problems_export.sql
   ```

2. Import to new database:
   ```powershell
   sqlite3 new_spock.db < problems_export.sql
   ```

### Option 3: EF Core Migrations (Future Enhancement)
Consider creating EF Core migration scripts with seed data for version-controlled database seeding.

## Database Statistics

Use the `DatabaseSeeder.GetDatabaseStatsAsync()` method to check database contents:

```csharp
var context = new SpockDbContext(options);
var stats = await DatabaseSeeder.GetDatabaseStatsAsync(context);
Console.WriteLine(stats);
```

Example output:
```
Total Problems: 652
Problems by Domain:
  Math: 120
  Logic: 80
  Reading: 70
  Science: 90
  WinPants: 60
  WashingtonHistory: 50
  Bitcoin: 82
  Minecraft: 50
  Health: 50
```

## Current Problem Count

As of the latest database:
- **Total Problems:** 652+ (including 100 new health problems added Jan 2026)
- **Grade Range:** Grade 1 through College level
- **Domains:** Math, Logic, Reading, Science, Win Pants, Washington History, Bitcoin, Minecraft, Health

## Why Remove Hardcoded Problems?

1. **Codebase Size:** Reduced from ~11,898 to ~153 lines in ProblemBank.cs
2. **Maintainability:** Database is easier to update than C# code
3. **Performance:** Database queries are more efficient than in-memory lists
4. **Separation of Concerns:** Data storage separate from business logic
5. **Scalability:** Easy to add thousands more problems without code changes

## Legacy Code Removed

The following methods have been removed:
- `GetMathProblems()` - ~2,200 lines
- `GetLogicProblems()` - ~1,500 lines
- `GetReadingProblems()` - ~950 lines
- `GetScienceProblems()` - ~820 lines
- `GetWinPantsProblems()` - ~970 lines
- `GetWashingtonHistoryProblems()` - ~1,130 lines
- `GetBitcoinProblems()` - ~1,000 lines
- `GetMinecraftProblems()` - ~1,340 lines
- `GetHealthProblems()` - ~2,340 lines (including new 100 problems)

The `GetAllProblemsFromCode()` method remains but throws `NotSupportedException` to guide developers to use database-based approaches.

## Database Backup Best Practices

**Important:** Always back up your database before making changes!

```powershell
# Create dated backup
$date = Get-Date -Format "yyyyMMdd_HHmmss"
Copy-Item "database/spock.db" -Destination "database/backups/spock_$date.db"
```

## Future Enhancements

Consider implementing:
1. **Migration scripts** with EF Core for version-controlled seeding
2. **Problem import/export tools** in the admin UI
3. **Database versioning** to track schema and data changes
4. **Cloud backup integration** for parent dashboard
5. **Problem editor UI** for non-technical content creators

## Troubleshooting

### Database Not Found
If the application can't find the database:
1. Check that `database/spock.db` exists in the workspace root
2. Copy from backup or another environment
3. Ensure proper file permissions

### Empty Database
If database has no problems:
1. Check using `GetDatabaseStatsAsync()`
2. Import from SQL export file
3. Copy from backup

### Database Corruption
If database is corrupted:
1. Restore from backup
2. Run SQLite integrity check: `sqlite3 database/spock.db "PRAGMA integrity_check;"`
3. Export and reimport data if recoverable

## Contact

For questions about database management, see:
- [ARCHITECTURE.md](ARCHITECTURE.md) - System architecture overview
- [plan.md](plan.md) - Complete project specification
- GitHub Issues - Bug reports and feature requests
