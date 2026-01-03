# GitHub Copilot Instructions for Vulcan Learning Pit

## Meta-Instructions (How to Update This File)

When the user says:
- **"put in instructions"** or **"add to brain"** → Add to existing instructions or create new sections
- **"lazy instructions"** → Content that loads on-demand (detailed patterns/examples) - remove from always-load
- **"always load instructions"** → Core context that should always be present
- **"brain"** or **"instructions"** → Refers to this file (.github/copilot-instructions.md)

**Goal**: Minimize context load by splitting always-load (core identity/principles) from on-demand (detailed patterns/examples).

---

## Project Identity (Always Load)

**Vulcan Learning Pit** is an adaptive learning platform for grades 4-college that uses a Spock mentor motif to provide motivation through earned approval rather than coercion. The system rapidly adapts difficulty based on student performance and can accelerate learners from elementary to college-level material when mastery is demonstrated.

**Repository**: https://github.com/nschwerzler/Vulcan-Learning-Pit

## Core Philosophy

- **Motivation via Competence Recognition**: Spock gives rare, data-based approval only when earned
- **Adaptive Difficulty**: System continuously adjusts up/down by concept, not grade level
- **ADD-Friendly Design**: Varied formats, short bursts, clear progress markers
- **Psychologically Sound**: Variable-ratio reinforcement, calm corrective feedback, no shaming
- **Parent Transparency**: Dashboard showing real-time progress, weakness tracking, and session history

## Architecture Principles

1. **.NET 10 C# WPF Only**: All implementation uses .NET 10 C# with WPF for desktop UI
2. **Data-Driven**: All decisions based on performance metrics and mastery thresholds
3. **Rapid Spiral Learning**: Master → Unlock → Advance cycle with automatic level progression
4. **Weakness Tracking**: Persistent identification and targeted remediation of struggling concepts
5. **Session State Management**: Track multi-problem sequences, approvals, and narrative echoes
6. **MSTest with Timeouts**: All tests use MSTest framework with mandatory [Timeout] attributes
7. **CancellationToken Pattern**: All async/wait operations must use CancellationToken with timeouts

## Code Generation Guidelines

### When Writing Code

- **Prioritize simplicity** over premature optimization
- **Add comments** explaining psychological/pedagogical reasoning behind features
- **Use clear variable names** that reflect learning concepts (e.g., `masteryThreshold`, `approvalTrigger`)
- **Implement state machines** for complex approval/progression logic
- **Include data validation** for all student input and performance tracking
- **Design for extensibility** - new subjects, problem types, and difficulty levels should be easy to add

### Critical Coding Standards (ALWAYS ENFORCE)

- **Every test method MUST have [Timeout(milliseconds)] attribute** - default 5000ms (5 seconds)
- **All async operations MUST accept CancellationToken parameter**
- **All waits/delays MUST use CancellationTokenSource with timeout**: `cts.CancelAfter(timeout)`
- **Never create infinite loops or unbounded waits** - always have exit conditions
- **Use MSTest framework** for all testing (not xUnit or NUnit)
- **Test example pattern:**
  ```csharp
  [TestMethod]
  [Timeout(5000)]
  public async Task MethodName_Scenario_ExpectedResult()
  {
      using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
      var result = await SomeMethodAsync(cts.Token);
      result.Should().NotBeNull();
  }
  ```

### When Adding Features

- **Question motivation impact**: How does this feature affect earning Spock's approval?
- **Consider ADD-friendliness**: Does this maintain engagement without overwhelming?
- **Validate against plan**: Check alignment with docs/plan.md specifications
- **Track performance data**: Ensure metrics collection for adaptive adjustments
- **Parent visibility**: Consider how this appears in the parent dashboard

### Domain-Specific Guidance

#### Adaptive Engine
- Implement 3-7 correct sequence tracking for variable-ratio approval
- Track concept weaknesses across multiple sessions
- Auto-detect mastery (90%+ under time limits) for level unlocking
- Support spiral-back to remediate persistent weaknesses

#### Spock Mentor Logic
- Never use phrases like "good job" - use data-based statements
- Approval messages must reference specific improvements or concept mastery
- Occasionally link current approval to prior successes for narrative continuity
- Corrective feedback should be calm, precise, and actionable

#### UI/UX Components
- Short problem bursts (5-10 min sessions recommended)
- Clear visual progress indicators without gamification pressure
- Multiple problem formats (multiple choice, free response, visual, verbal)
- Minimal distractions, maximum clarity

#### Parent Dashboard
- Real-time session monitoring
- Weakness pattern visualization
- Long-term trajectory tracking
- Approval history and frequency metrics
- Optional notifications for significant milestones

## What NOT to Do (Always Load)

- ❌ Don't add gamification elements that create unhealthy pressure
- ❌ Don't use emotionally manipulative language
- ❌ Don't lock features behind arbitrary grade levels
- ❌ Don't implement features without considering ADD-friendly design
- ❌ Don't ignore the psychological principles in docs/plan.md
- ❌ Don't create approval systems that feel predictable or automatic

## Key Files & Documentation

- **docs/plan.md**: Complete motivation model and curriculum specification
- **README.md**: Project overview and next steps
- **src/**: Implementation code (structure TBD)
- **.github/copilot-instructions.md**: This file - your working context

## Questions to Ask Before Implementing

1. Does this align with the Spock mentor motivation model?
2. Is this ADD-friendly and non-coercive?
3. Does this support rapid adaptive learning?
4. Can parents see this in the dashboard?
5. Does this track data for adaptive adjustments?
6. Is this psychologically sound based on the plan?

---

**Remember**: The goal is to create a system where students *want* to earn Spock's approval through genuine competence growth, not through manipulation or pressure. Every feature should serve that mission.
