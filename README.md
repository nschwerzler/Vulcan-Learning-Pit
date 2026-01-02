# Spock Learning

Adaptive learning platform for grades 4-college with a Spock mentor motif. Desktop WPF application built with .NET 9 C#.

✅ **Core Engine Complete** - Phases 1-3 implemented with 127 passing tests

## Status

**Phase 1: Foundation** ✅
- MSTest framework with mandatory timeout attributes
- Core data models (StudentProfile, Problem, Session, WeaknessRecord)
- ApprovalEngine with variable-ratio reinforcement (3-7 correct)
- SessionStateMachine using Stateless library (9 states, 13 triggers)

**Phase 2: Adaptive Engine** ✅
- BayesianKnowledgeTracer - BKT algorithm for skill mastery estimation
- WeaknessTracker - Intelligent detection with disguise rotation
- TopicScheduler - ADD-optimized domain switching (10-15 min)

**Phase 3: Spock Mentor System** ✅
- SpockDialogueEngine - Complete dialogue with narrative echoes
- Variable-ratio approval triggers (rare, data-based)
- Vulcan insight fragments (collectible wisdom)
- Approval frequency monitoring (target: 1 per 15-20 problems)

## Structure

- [docs/plan.md](docs/plan.md): Complete specification
- src/Spock.Core/: Domain models and enums
- src/Spock.Engine/: Adaptive algorithms (ApprovalEngine, BKT, WeaknessTracker, TopicScheduler, SpockDialogueEngine)
- src/Spock.Data/: Entity Framework persistence layer
- src/Spock.UI/: WPF application (planned)
- tests/Spock.Tests/: 127 passing tests with timeout enforcement

## Tech Stack

- **UI**: WPF + Prism MVVM + Extended.Wpf.Toolkit (planned)
- **Backend**: .NET 9 C# class libraries
- **Database**: Entity Framework Core with SQLite
- **Testing**: MSTest + Moq + FluentAssertions
- **State Management**: Stateless 5.20.0
- **Distribution**: MSIX packaging or ClickOnce (planned)

## Key Features

**Psychological Motivation**
- Variable-ratio reinforcement (3-7 correct sequence for approval)
- Rare, data-based approval maintains motivation without pressure
- Narrative echoes link current success to prior breakthroughs
- Calm, precise corrective feedback (never shaming)

**Adaptive Learning**
- Bayesian Knowledge Tracing for skill mastery estimation
- Weakness detection across accuracy (<75%), time (>130% target), confidence (<70%)
- Disguised repetition - weaknesses reintroduced in different contexts
- Rapid acceleration when mastery demonstrated (90%+ accuracy)

**ADD-Friendly Design**
- Topic switching every 10-15 minutes to prevent fatigue
- Never more than 2 consecutive problems in same micro-topic
- Interleaving with least-recently-used domain selection
- 40% priority for weakness domains (spiral-back remediation)

## Next Steps

**Phase 4**: Content & Problem Bank
- Import/create math problems (Grade 4-College)
- Logic puzzles, reading passages, science scenarios
- Format variation (visual/verbal/interactive)

**Phase 5**: Parent Dashboard
- Real-time session monitoring
- Weakness trend visualization
- Ethical benchmarking (opt-in)

**Phase 6**: WPF UI Implementation
- Prism MVVM architecture
- Session flow integration
- Safety controls (session caps, forced breaks)

## Development

```powershell
# Build solution
dotnet build

# Run tests
dotnet test

# Run application (once scaffolded)
dotnet run --project src/Spock.UI
```
