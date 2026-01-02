# Scrum Board Setup Guide

## Prerequisites
- GitHub repository with admin access
- GitHub Projects (Beta) enabled

## Step 1: Create the Scrum Project Board

1. Navigate to your repository on GitHub
2. Click the **Projects** tab
3. Click **New project**
4. Select **Board** view
5. Name it **"Scrum Board"**
6. Click **Create**

## Step 2: Configure Board Columns

Set up the following columns in order:

1. **Product Backlog**
   - Description: "All work items not yet committed to a sprint"
   
2. **Sprint Backlog**
   - Description: "Items committed to the current sprint"
   
3. **In Progress**
   - Description: "Work actively being done"
   
4. **In Review**
   - Description: "Awaiting code review or testing"
   
5. **Done**
   - Description: "Completed and meets Definition of Done"

## Step 3: Configure Automation

1. In your project settings, enable these automations:
   - Auto-add new issues with label `user-story`, `sprint-task`, or `bug`
   - Auto-add new pull requests
   - Auto-move to "Done" when issues are closed

2. Verify the workflow file exists at `.github/workflows/scrum.yml`

## Step 4: Create Labels

Create the following labels in your repository:

### Issue Type Labels
- `user-story` - User stories (blue)
- `sprint-task` - Sprint tasks (green)
- `bug` - Bugs (red)
- `tech-debt` - Technical debt (yellow)

### Story Point Labels
- `points: 1` - 1 story point (light gray)
- `points: 2` - 2 story points (gray)
- `points: 3` - 3 story points (gray)
- `points: 5` - 5 story points (dark gray)
- `points: 8` - 8 story points (darker gray)
- `points: 13` - 13 story points (darkest gray)

### Sprint Labels
- `sprint: 1` - Sprint 1 (purple)
- `sprint: 2` - Sprint 2 (purple)
- (Create more as needed)

### Priority Labels
- `priority: high` - High priority (red)
- `priority: medium` - Medium priority (orange)
- `priority: low` - Low priority (yellow)

### Status Labels
- `in-sprint` - Currently in a sprint (green)
- `blocked` - Blocked by dependency (red)
- `ready-for-review` - Awaiting review (blue)

## Step 5: Set Up Milestones

1. Go to **Issues** → **Milestones**
2. Create milestones for each sprint:
   - Title: "Sprint 1"
   - Due date: End of sprint
   - Description: Sprint goals and objectives

## Step 6: Configure Project Settings

1. In project settings, enable:
   - **Status** field (map to columns)
   - **Story Points** field (number)
   - **Sprint** field (single select)
   - **Priority** field (single select)

2. Set up field values:
   - Story Points: 1, 2, 3, 5, 8, 13
   - Sprint: Sprint 1, Sprint 2, etc.
   - Priority: High, Medium, Low

## Step 7: Define Your Team's Standards

Document these in your project wiki or README:

### Definition of Done
Example:
- [ ] Code complete
- [ ] Unit tests written and passing
- [ ] Code reviewed and approved
- [ ] Integration tests passing
- [ ] Documentation updated
- [ ] Deployed to staging environment
- [ ] Accepted by Product Owner

### Sprint Duration
- Typical: 2 weeks
- Sprint Planning: First day
- Daily Standups: Every morning
- Sprint Review: Last day
- Sprint Retrospective: After review

### Estimation Guidelines
- Use Planning Poker
- Fibonacci sequence (1, 2, 3, 5, 8, 13)
- Team consensus required
- Re-estimate if needed during sprint

## Step 8: Create Initial Backlog

1. Use the issue templates to create user stories
2. Add acceptance criteria to each story
3. Prioritize by business value
4. Refine top items in backlog

## Step 9: Configure Team Permissions

1. Add team members to repository
2. Assign roles:
   - Product Owner (maintains backlog)
   - Scrum Master (facilitates process)
   - Development Team (implements work)

## Step 10: First Sprint Planning

1. Set sprint goal
2. Review top backlog items
3. Team commits to stories
4. Move committed items to Sprint Backlog
5. Break down stories into tasks
6. Assign work

## Maintaining the Board

### Daily
- Update issue status
- Move cards between columns
- Add blockers as comments
- Update daily standup notes

### Weekly
- Backlog refinement (1 hour)
- Groom upcoming stories
- Estimate new items
- Break down large stories

### Per Sprint
- Sprint Planning (2 hours)
- Daily Standups (15 min)
- Sprint Review (1 hour)
- Sprint Retrospective (1 hour)

## Tips for Success

1. **Keep the board updated** - Real-time status is crucial
2. **Limit work in progress** - Focus on completing items
3. **Respect the sprint commitment** - Avoid mid-sprint changes
4. **Use metrics** - Track velocity and burndown
5. **Improve continuously** - Act on retrospective items

## Common Issues and Solutions

### Problem: Stories too large
**Solution**: Break into smaller stories (< 8 points)

### Problem: Velocity varies widely
**Solution**: More consistent estimation, better sprint planning

### Problem: Items frequently blocked
**Solution**: Identify blockers earlier, improve dependencies

### Problem: Sprint goals not met
**Solution**: Review capacity, improve estimation, reduce distractions

## Resources

- [SCRUM.md](../SCRUM.md) - Full Scrum methodology guide
- [Scrum Guide](https://scrumguides.org/)
- [Issue Templates](../ISSUE_TEMPLATE/) - Templates for creating issues

## Support

For questions or issues with the board setup:
1. Check the [SCRUM.md](../SCRUM.md) guide
2. Review GitHub Projects documentation
3. Ask the team in discussions
