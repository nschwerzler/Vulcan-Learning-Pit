# Vulcan Learning Pit

Adaptive learning platform for grades 4-college with a Spock mentor motif. Desktop WPF application built with .NET 10 C#.

✅ **Core Engine Complete** - All adaptive engines integrated
🎨 **UI Functional** - Full MVVM interface with session coordination
✅ **178 Tests Passing** - All integration tests successful
🐛 **Debug Server Active** - HTTP API for real-time state inspection
🔧 **Production Ready** - Recent bug fixes eliminate deadlock risks

## Quick Start

```powershell
# Build and run
dotnet run --project src/Spock.UI/Spock.UI.csproj

# Debug server automatically starts at http://localhost:5555
# Test it:
Invoke-RestMethod http://localhost:5555/health
```

## Current Status

**✅ Phase 1: Foundation** (Complete - 51 tests)
- MSTest framework with mandatory timeout attributes
- Core data models (StudentProfile, Problem, Session, WeaknessRecord)
- **ApprovalEngine** with variable-ratio reinforcement (3-7 correct)
- **SessionStateMachine** using Stateless library (9 states, 13 triggers)

**✅ Phase 2: Adaptive Engine** (Complete - 53 tests)
- **BayesianKnowledgeTracer** - BKT algorithm for skill mastery estimation
- **WeaknessTracker** - Intelligent detection with disguise rotation
- **TopicScheduler** - ADD-optimized domain switching (10-15 min)

**✅ Phase 3: Spock Mentor System** (Complete - 23 tests)
- **SpockDialogueEngine** - Complete dialogue with narrative echoes
- Variable-ratio approval triggers (rare, data-based)
- Vulcan insight fragments (collectible wisdom)
- Approval frequency monitoring (target: 1 per 15-20 problems)

**✅ Phase 3.5: UI Implementation** (Complete - Functional)
- WPF MVVM architecture with MainViewModel
- Dark-themed interface with real-time metrics
- Problem presentation with multiple formats
- Spock dialogue display system
- Streak tracking and accuracy calculation
- Sample problem bank (6 problems across domains)

**✅ Phase 4: Session Coordination** (Complete - 8 tests)
- **SessionCoordinator** - Unified engine integration layer
- ADD-aware topic switching with weakness prioritization
- Automatic mastery detection and acceleration
- Session metrics tracking (accuracy, time, focus score)
- Zone of Proximal Development problem selection
- **Game Token System** - Difficulty-based reward system (16 tests)

**✅ Phase 4.5: Data Persistence** (Complete - 18 tests)
- Entity Framework Core with SQLite
- StudentDataService for profile and session management
- Session history and aggregate metrics
- Weakness trend tracking
- **ProblemBank in SQLite**: 552+ problems migrated from 11,400-line file to indexed database

**🚧 Phase 5: Enhancement & Content** (Next)
- Visual enhancements and animations
- Session persistence with Entity Framework
- Expanded problem content bank
- Parent Dashboard window

**📋 Future: Phases 6-8** - Testing, refinement, deployment

## Quick Start

```bash
# Clone the repository
git clone https://github.com/nschwerzler/Vulcan-Learning-Pit.git
cd Spock

# Run tests (178 passing)
dotnet test

# Run the UI
dotnet run --project src/Spock.UI/Spock.UI.csproj
```

## UI Features

The working interface includes:
- **Header Dashboard**: Real-time streak, accuracy %, problem count
- **Spock Dialogue Box**: Dynamic feedback based on performance
- **Problem Display**: Clear presentation with multi-format support
- **Answer Input**: Type answers, press Enter to submit
- **Feedback System**: Immediate correct/incorrect indicators
- **Adaptive Response**: Spock's dialogue varies from neutral to approving

Try answering multiple problems correctly to trigger Spock's rare approval!

## Architecture

### Engine Components (src/Spock.Engine/)
- `ApprovalEngine.cs` - Variable-ratio reinforcement (12 tests)
- `SessionStateMachine.cs` - Session flow management (17 tests)
- `WeaknessTracker.cs` - Intelligent weakness detection (20 tests)
- `TopicScheduler.cs` - ADD-aware domain switching (17 tests)
- `BayesianKnowledgeTracer.cs` - BKT mastery estimation (20 tests)
- `SpockDialogueEngine.cs` - Mentor dialogue system (23 tests)
- `SessionCoordinator.cs` - Unified session management (8 tests)

### UI Layer (src/Spock.UI/)
- `MainViewModel.cs` - MVVM pattern with engine integration
- `MainWindow.xaml` - Dark-themed WPF interface
- `App.xaml.cs` - Database initialization on startup

### Data Layer (src/Spock.Data/)
- `SpockDbContext.cs` - EF Core context with student data and problem bank
- `ProblemBank.cs` - Async problem queries (552+ problems indexed by domain/difficulty/micro-topic)
- `DatabaseSeeder.cs` - Auto-seeds problems on first run
- `StudentDataService.cs` - Student profile and session persistence

### Data Models (src/Spock.Core/Models/)
- `StudentProfile.cs` - Student state and preferences
- `Problem.cs` - Question content and metadata
- `Session.cs` - Session records and metrics
- `WeaknessRecord.cs` - Weakness tracking
- `Domain.cs` - Subject area enums

## Testing

All tests use MSTest with mandatory `[Timeout]` attributes and `CancellationToken` support:

```bash
# Run all tests
dotnet test

# Run specific engine tests
dotnet test --filter "FullyQualifiedName~ApprovalEngineTests"
dotnet test --filter "FullyQualifiedName~SpockDialogueEngineTests"

# Check test count
dotnet test --list-tests
```

**178 passing tests** covering:
- Core models (15 tests)
- Approval system (12 tests)
- Session state machine (17 tests)
- Weakness tracking (20 tests)  
- Topic scheduling (17 tests)
- BKT algorithms (20 tests)
- Dialogue generation (23 tests)
- Session coordination (8 tests)
- Game token system (16 tests)
- Data persistence (18 tests)
- Integration scenarios (11 tests)

## Documentation

- **[README.md](README.md)** - This file (quick start guide)
- **[docs/SUMMARY.md](docs/SUMMARY.md)** - Project overview and current status
- **[docs/ARCHITECTURE.md](docs/ARCHITECTURE.md)** - Complete system architecture
- **[docs/BUGFIXES.md](docs/BUGFIXES.md)** - Bug fix history and solutions
- **[docs/plan.md](docs/plan.md)** - Full specification and feature details

## Structure

- **docs/** - All documentation (see above)
- **src/Spock.Core/** - Domain models and enums
- **src/Spock.Engine/** - Adaptive algorithms (all 6 engines)
- **src/Spock.Data/** - Entity Framework persistence layer
- **src/Spock.UI/** - WPF application with MVVM
- **tests/Spock.Tests/** - 178 passing tests with timeout enforcement

## Tech Stack

- **UI**: WPF with MVVM pattern
- **Backend**: .NET 10 C# class libraries
- **Database**: Entity Framework Core 10.0.1 with SQLite
  - Student profiles, sessions, weaknesses
  - **Problem bank**: 552+ problems with indexed queries
- **Testing**: MSTest + Moq + FluentAssertions (in-memory database for tests)
- **State Management**: Stateless 5.20.0
- **Distribution**: MSIX packaging or ClickOnce (planned)

## Key Features Implemented

**Psychological Motivation**
- ✅ Variable-ratio reinforcement (3-7 correct sequence for approval)
- ✅ Rare, data-based approval maintains motivation without pressure
- ✅ Narrative echoes link current success to prior breakthroughs
- ✅ Calm, precise corrective feedback (never shaming)

**Adaptive Learning**
- ✅ Bayesian Knowledge Tracing for skill mastery estimation
- ✅ Weakness detection across accuracy (<75%), time (>130% target), confidence (<70%)
- ✅ Disguised repetition - weaknesses reintroduced in different contexts
- ✅ Rapid acceleration when mastery demonstrated (90%+ accuracy)

**ADD-Friendly Design**
- ✅ Topic switching every 10-15 minutes to prevent fatigue
- ✅ Never more than 2 consecutive problems in same micro-topic
- ✅ Interleaving with least-recently-used domain selection
- ✅ 40% priority for weakness domains (spiral-back remediation)

**Spock Dialogue System**
- ✅ Neutral responses 90% of time ("Proceed.", "Continue.")
- ✅ Subtle approval after correct streaks
- ✅ Strong approval for conquered weaknesses
- ✅ Narrative echoes (20% chance after approvals)
- ✅ Vulcan insight fragments for major breakthroughs

## Debug Server 🐛

The application includes an embedded HTTP debug server for development:

```powershell
# Start the app (debug server auto-starts on port 5555)
dotnet run --project src/Spock.UI/Spock.UI.csproj

# Test endpoints
Invoke-RestMethod http://localhost:5555/health
Invoke-RestMethod http://localhost:5555/session
Invoke-RestMethod http://localhost:5555/approval

# Or run the test script
.\test-debug-server.ps1
```

**Available Endpoints:**
- `/health` - Server status
- `/session` - Current session state (streak, accuracy, problem info)
- `/approval` - Approval engine state (threshold, history)
- `/state` - All debug state
- `/weaknesses` - Tracked weakness data

See [src/Spock.UI/DEBUG_SERVER.md](src/Spock.UI/DEBUG_SERVER.md) for full documentation.

## Next Steps

**Phase 4**: Content & Problem Bank
- Import/create math problems (Grade 4-College)
- Logic puzzles, reading passages, science scenarios
- Format variation (visual/verbal/interactive)

**Phase 5**: Parent Dashboard
- Real-time session monitoring
- Weakness trend visualization
- Ethical benchmarking (opt-in)

**Phase 6**: WPF UI Enhancement
- Animations and transitions
- Visual progress indicators
- Session timing and breaks
- Safety controls

## Development

```powershell
# Build solution
dotnet build

# Run tests
dotnet test

# Run application (once scaffolded)
dotnet run --project src/Spock.UI
```
