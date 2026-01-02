# Scrum Board Guide

## Overview
This repository supports Scrum methodology for agile project management. Scrum is an iterative and incremental framework that emphasizes collaboration, accountability, and continuous improvement through fixed-length sprints.

## Board Structure

### Columns
The Scrum board is organized into sprint-based columns:

1. **Product Backlog** - All identified work items, prioritized by the Product Owner
2. **Sprint Backlog** - Items selected for the current sprint
3. **In Progress** - Items currently being worked on during the sprint
4. **In Review** - Items awaiting review or testing
5. **Done** - Completed items that meet the Definition of Done

## Scrum Ceremonies

### Sprint Planning
- **When**: Beginning of each sprint (typically every 2 weeks)
- **Duration**: 1-2 hours
- **Purpose**: Select items from Product Backlog for the Sprint Backlog
- **Outcome**: Sprint Goal and committed work items

### Daily Standup
- **When**: Every day at the same time
- **Duration**: 15 minutes maximum
- **Purpose**: Synchronize team activities
- **Questions**:
  - What did I complete yesterday?
  - What will I work on today?
  - Are there any blockers?

### Sprint Review
- **When**: End of each sprint
- **Duration**: 1 hour
- **Purpose**: Demonstrate completed work to stakeholders
- **Outcome**: Feedback and potential backlog updates

### Sprint Retrospective
- **When**: After Sprint Review
- **Duration**: 45 minutes
- **Purpose**: Reflect on the sprint process
- **Questions**:
  - What went well?
  - What could be improved?
  - What will we commit to improve?

## Issue Types

### 1. User Story
Use for feature requests from the user's perspective.
- Label: `user-story`
- Template: `.github/ISSUE_TEMPLATE/user-story.yml`
- Format: "As a [user type], I want [goal] so that [benefit]"

### 2. Sprint Task
Use for specific tasks within a sprint.
- Label: `sprint-task`
- Template: `.github/ISSUE_TEMPLATE/sprint-task.yml`

### 3. Bug
Use for defects or issues found.
- Label: `bug`
- Template: `.github/ISSUE_TEMPLATE/bug.yml`

### 4. Technical Debt
Use for code improvements and refactoring.
- Label: `tech-debt`
- Template: `.github/ISSUE_TEMPLATE/tech-debt.yml`

## Story Points and Estimation

### Story Point Scale (Fibonacci)
- **1 point** - Trivial task (< 1 hour)
- **2 points** - Simple task (1-2 hours)
- **3 points** - Moderate task (half day)
- **5 points** - Complex task (1 day)
- **8 points** - Very complex task (2 days)
- **13 points** - Epic task (needs breakdown)

### Estimation Process
1. Team discusses each story
2. Use Planning Poker for estimation
3. Reach consensus on story points
4. Add estimation to issue labels

## Using the Scrum Board

### Product Backlog Refinement
1. Create issues with clear acceptance criteria
2. Prioritize items based on business value
3. Ensure top items are "ready" for sprint planning
4. Break down large items (> 8 points) into smaller stories

### Sprint Workflow
1. **Sprint Planning**: Move selected items to Sprint Backlog
2. **During Sprint**: 
   - Pick item from Sprint Backlog
   - Move to In Progress
   - Work on the item
   - Move to In Review when complete
   - After review/testing, move to Done
3. **Sprint End**: Review completed items, close sprint

### Best Practices
- **Sprint Commitment**: Only commit to work the team can complete
- **No Scope Changes**: Avoid adding items mid-sprint
- **Definition of Done**: Clear criteria for completion
  - Code complete
  - Tests written and passing
  - Code reviewed
  - Documentation updated
  - Deployed to staging
- **Velocity Tracking**: Track story points completed per sprint
- **Team Capacity**: Consider holidays, PTO, and other commitments

## Labels

### Priority Labels
- `priority: high` - Must have in this sprint
- `priority: medium` - Should have in this sprint
- `priority: low` - Nice to have in this sprint

### Story Point Labels
- `points: 1`
- `points: 2`
- `points: 3`
- `points: 5`
- `points: 8`
- `points: 13`

### Sprint Labels
- `sprint: 1`
- `sprint: 2`
- etc.

### Status Labels
- `in-progress` - Currently being worked on
- `blocked` - Cannot proceed due to dependency
- `ready-for-review` - Awaiting code review
- `ready-for-test` - Awaiting QA testing

## Metrics and Tracking

### Velocity
- Sum of story points completed per sprint
- Use to predict future sprint capacity
- Track over 3-5 sprints for stable velocity

### Burndown Chart
- Track remaining work during sprint
- Daily updates recommended
- Identify trends and potential issues early

### Sprint Health Indicators
- **Green**: On track to complete sprint goal
- **Yellow**: Some items at risk
- **Red**: Sprint goal at risk

## Setting Up the Scrum Board

1. Go to GitHub Projects
2. Create a new project named "Scrum Board"
3. Set up columns:
   - Product Backlog
   - Sprint Backlog
   - In Progress
   - In Review
   - Done
4. Configure automation (see `.github/workflows/scrum.yml`)
5. Create labels for story points and sprints
6. Define your Definition of Done

## Scrum Roles

### Product Owner
- Maintains Product Backlog
- Prioritizes work items
- Defines acceptance criteria
- Available for questions

### Scrum Master
- Facilitates ceremonies
- Removes blockers
- Protects team from interruptions
- Coaches team on Scrum practices

### Development Team
- Self-organizing
- Cross-functional
- Estimates work
- Delivers potentially shippable increment

## Tips for Success

1. **Keep Stories Small**: Aim for multiple stories completed per sprint
2. **Clear Acceptance Criteria**: Every story should have testable criteria
3. **Regular Refinement**: Groom backlog continuously
4. **Transparent Communication**: Make impediments visible immediately
5. **Inspect and Adapt**: Use retrospectives to improve continuously
6. **Maintain Sustainable Pace**: Don't overcommit

## Resources

- [Scrum Guide](https://scrumguides.org/)
- [Agile Manifesto](https://agilemanifesto.org/)
- [User Story Best Practices](https://www.atlassian.com/agile/project-management/user-stories)
- [Scrum vs Kanban](https://www.atlassian.com/agile/kanban/kanban-vs-scrum)
