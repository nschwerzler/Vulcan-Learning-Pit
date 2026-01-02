# Project Tracker Guide

## Overview
The Project Tracker is a simple, flexible project management board suitable for projects that don't require the formal ceremonies of Scrum or the continuous flow of Kanban. It provides a straightforward way to organize work by project phases or milestones.

## Board Structure

### Columns
The Project Tracker board is organized into these columns:

1. **Ideas** - Potential features or improvements being considered
2. **Planned** - Approved work items scheduled for implementation
3. **Active** - Work currently in progress
4. **Testing/Review** - Items being verified or reviewed
5. **Completed** - Finished work items
6. **On Hold** - Paused items waiting for decisions or dependencies

## When to Use Project Tracker

This board style works well for:
- **Small teams** (1-5 people) with less formal processes
- **Research projects** with exploratory work
- **Long-term initiatives** spanning multiple months
- **Mixed work types** (features, research, documentation, etc.)
- **Projects with external dependencies** requiring flexible pausing
- **Teams new to project management** seeking simplicity

## Issue Types

### 1. Milestone
Use for major project phases or releases.
- Label: `milestone`
- Template: `.github/ISSUE_TEMPLATE/milestone.yml`
- Represents a significant checkpoint

### 2. Initiative
Use for large bodies of work (epics).
- Label: `initiative`
- Template: `.github/ISSUE_TEMPLATE/initiative.yml`
- Can contain multiple tasks

### 3. Task
Use for specific work items.
- Label: `task`
- Template: `.github/ISSUE_TEMPLATE/task.yml`

### 4. Research
Use for investigation and spike work.
- Label: `research`
- Template: `.github/ISSUE_TEMPLATE/research.yml`

### 5. Bug
Use for defects and issues.
- Label: `bug`
- Template: `.github/ISSUE_TEMPLATE/bug.yml`

## Using the Project Tracker

### Planning Workflow
1. **Capture Ideas**: Create issues for all ideas in the Ideas column
2. **Review Regularly**: Weekly review of Ideas to promote to Planned
3. **Prioritize**: Order items in Planned column by priority
4. **Set Milestones**: Group related items under milestones
5. **Estimate Complexity**: Use size labels (S/M/L/XL) for rough estimates

### Execution Workflow
1. Pick highest priority item from Planned
2. Move to Active and assign to team member
3. Work on the item
4. Move to Testing/Review when complete
5. After validation, move to Completed
6. If blocked, move to On Hold with clear blocker note

### Review Cycles
- **Daily Quick Check**: Update item status (5 minutes)
- **Weekly Planning**: Review Ideas and Planned columns (30 minutes)
- **Milestone Reviews**: Assess progress toward milestones (1 hour)
- **Monthly Retrospective**: Review completed work and process improvements

## Best Practices

### Item Management
- **Keep Active Items Limited**: Maximum 2-3 items per person
- **Clear Descriptions**: Include context, requirements, and expected outcomes
- **Link Related Items**: Connect dependencies using GitHub issue links
- **Update Progress**: Add comments to show progress and decisions
- **Document Blockers**: Clearly state why items are On Hold

### Prioritization
- **Business Value**: Impact on users or business goals
- **Dependencies**: Items blocking other work
- **Risk**: Technical or business risks to address
- **Effort**: Balance quick wins with complex work

### Milestone Planning
- **Time-boxed**: Set realistic completion dates
- **Focused**: Limit scope to achievable goals
- **Measurable**: Include specific deliverables
- **Flexible**: Allow adjustments based on learning

## Labels

### Size Labels (T-shirt sizing)
- `size: XS` - Extra small (< 2 hours)
- `size: S` - Small (half day)
- `size: M` - Medium (1-2 days)
- `size: L` - Large (3-5 days)
- `size: XL` - Extra large (1+ weeks, consider breaking down)

### Priority Labels
- `priority: critical` - Drop everything
- `priority: high` - Next to work on
- `priority: medium` - Normal priority
- `priority: low` - Nice to have

### Category Labels
- `type: feature` - New functionality
- `type: improvement` - Enhancement to existing feature
- `type: bug` - Defect or issue
- `type: research` - Investigation or spike
- `type: documentation` - Documentation work
- `type: infrastructure` - DevOps, tools, setup

### Status Labels
- `status: blocked` - Cannot proceed
- `status: needs-decision` - Waiting for decision
- `status: needs-review` - Awaiting review
- `status: on-hold` - Paused temporarily

## Metrics and Reporting

### Lead Time
- Time from Planned to Completed
- Helps predict delivery timelines
- Track trends over time

### Throughput
- Number of items completed per week/month
- Indicates team capacity
- Use for future planning

### Work Distribution
- Percentage of work by type (feature/bug/research)
- Balance maintenance vs new development
- Identify focus areas

### Blocker Analysis
- Frequency and duration of blocked items
- Common blocker patterns
- Process improvements needed

## Setting Up the Project Tracker

1. Create a new GitHub Project
2. Name it "Project Tracker"
3. Set up columns:
   - Ideas
   - Planned
   - Active
   - Testing/Review
   - Completed
   - On Hold
4. Create issue templates (see `.github/ISSUE_TEMPLATE/`)
5. Configure labels for size, priority, and type
6. Set up milestones for major releases or phases
7. Enable automation (see `.github/workflows/project-tracker.yml`)

## Communication

### Status Updates
- **Daily**: Brief comment on active items
- **Weekly**: Summary of completed work
- **Milestone**: Detailed review of progress

### Meeting Cadence
- **Planning**: Weekly, 30-45 minutes
- **Retrospective**: Monthly, 1 hour
- **Ad-hoc**: As needed for unblocking or decisions

### Documentation
- Keep README updated with project status
- Document key decisions in issues
- Maintain changelog for releases

## Comparison with Other Methods

### vs. Kanban
- **Project Tracker**: More flexible with On Hold column, milestone-focused
- **Kanban**: Continuous flow, WIP limits, faster iterations

### vs. Scrum
- **Project Tracker**: No fixed sprints, less formal ceremonies, more flexible
- **Scrum**: Sprint-based, defined roles, regular cadence

### When to Switch
- **To Kanban**: If work becomes more continuous and predictable
- **To Scrum**: If team grows or needs more structure and predictability

## Tips for Success

1. **Start Simple**: Don't over-complicate with too many labels or columns
2. **Be Consistent**: Update the board regularly
3. **Stay Flexible**: Adapt the process to your team's needs
4. **Limit WIP**: Don't take on too much active work
5. **Review Often**: Regular reviews keep the backlog healthy
6. **Celebrate Wins**: Acknowledge completed milestones
7. **Learn and Adjust**: Improve the process based on what works

## Example Workflow

### Small Feature Development
1. Idea captured in Ideas column
2. Discussed in weekly planning, moved to Planned
3. Developer picks it up, moves to Active
4. Code completed, moved to Testing/Review
5. QA verifies, moves to Completed
6. Included in next release

### Research Spike
1. Research task created in Ideas
2. Prioritized and moved to Planned
3. Researcher investigates, moves to Active
4. Findings documented in issue
5. Recommendations reviewed, moved to Completed
6. Follow-up tasks created based on findings

### Blocked Work
1. Task in Active encounters dependency
2. Moved to On Hold with blocker documented
3. Dependency tracked separately
4. When unblocked, moved back to Active
5. Work resumed and completed

## Resources

- [Project Management Basics](https://www.atlassian.com/project-management)
- [Issue Tracking Best Practices](https://docs.github.com/en/issues/tracking-your-work-with-issues)
- [Milestone Planning](https://docs.github.com/en/issues/using-labels-and-milestones-to-track-work/about-milestones)
- [GitHub Projects Guide](https://docs.github.com/en/issues/planning-and-tracking-with-projects)
