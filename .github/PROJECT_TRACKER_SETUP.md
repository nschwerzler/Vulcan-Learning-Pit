# Project Tracker Setup Guide

## Prerequisites
- GitHub repository with admin access
- GitHub Projects enabled

## Step 1: Create the Project Tracker Board

1. Navigate to your repository on GitHub
2. Click the **Projects** tab
3. Click **New project**
4. Select **Board** view
5. Name it **"Project Tracker"**
6. Click **Create**

## Step 2: Configure Board Columns

Set up the following columns in order:

1. **Ideas**
   - Description: "Potential features or improvements being considered"
   
2. **Planned**
   - Description: "Approved work items scheduled for implementation"
   
3. **Active**
   - Description: "Work currently in progress"
   
4. **Testing/Review**
   - Description: "Items being verified or reviewed"
   
5. **Completed**
   - Description: "Finished work items"
   
6. **On Hold**
   - Description: "Paused items waiting for decisions or dependencies"

## Step 3: Configure Automation

1. In your project settings, enable these automations:
   - Auto-add new issues with relevant labels
   - Auto-add new pull requests
   - Auto-move to "Completed" when issues are closed

2. Verify the workflow file exists at `.github/workflows/project-tracker.yml`

## Step 4: Create Labels

Create the following labels in your repository:

### Issue Type Labels
- `milestone` - Project milestones (purple)
- `initiative` - Large initiatives/epics (blue)
- `task` - General tasks (green)
- `research` - Research work (cyan)
- `bug` - Bugs (red)

### Size Labels (T-shirt sizing)
- `size: XS` - Extra small (light blue)
- `size: S` - Small (blue)
- `size: M` - Medium (yellow)
- `size: L` - Large (orange)
- `size: XL` - Extra large (red)

### Priority Labels
- `priority: critical` - Critical priority (dark red)
- `priority: high` - High priority (red)
- `priority: medium` - Medium priority (orange)
- `priority: low` - Low priority (yellow)

### Category Labels
- `type: feature` - New features (green)
- `type: improvement` - Improvements (blue)
- `type: bug` - Bug fixes (red)
- `type: research` - Research work (purple)
- `type: documentation` - Documentation (gray)
- `type: infrastructure` - Infrastructure (brown)

### Status Labels
- `status: blocked` - Blocked (red)
- `status: needs-decision` - Needs decision (yellow)
- `status: needs-review` - Needs review (blue)
- `status: on-hold` - On hold (gray)

## Step 5: Set Up Milestones

1. Go to **Issues** → **Milestones**
2. Create milestones for major releases or phases:
   - Title: "Version 1.0"
   - Due date: Target release date
   - Description: Milestone goals and objectives

## Step 6: Configure Project Fields

1. In project settings, add custom fields:
   - **Size** (single select): XS, S, M, L, XL
   - **Priority** (single select): Critical, High, Medium, Low
   - **Category** (single select): Feature, Bug, Research, etc.
   - **Milestone** (milestone field)
   - **Lead Time** (number, days)

## Step 7: Define Workflow Guidelines

Document these in your project documentation:

### Column Definitions

**Ideas**
- Unvetted proposals
- No commitment yet
- Reviewed weekly

**Planned**
- Approved for work
- Prioritized order
- Ready to start

**Active**
- Currently being worked on
- Limit: 2-3 items per person
- Daily updates expected

**Testing/Review**
- Code complete
- Under verification
- Awaiting feedback

**Completed**
- Finished and verified
- Meets acceptance criteria
- Closed

**On Hold**
- Temporarily paused
- Document blocker
- Review regularly

## Step 8: Create Initial Content

1. Add existing work items as issues
2. Categorize with appropriate labels
3. Size each item (S/M/L/XL)
4. Prioritize items
5. Assign to appropriate column

## Step 9: Configure Team Access

1. Add team members to repository
2. Define responsibilities:
   - Project lead (maintains priorities)
   - Contributors (implement work)
   - Reviewers (verify completion)

## Step 10: First Planning Session

1. Review Ideas column
2. Promote items to Planned
3. Set priorities
4. Assign owners to top items
5. Move ready items to Active
6. Set milestone targets

## Maintaining the Board

### Daily
- Update status of active items
- Move items between columns
- Document any blockers
- Add new ideas as they arise

### Weekly Planning (30-45 min)
- Review Ideas column
- Promote items to Planned
- Re-prioritize as needed
- Check On Hold items
- Review progress toward milestones

### Monthly Review (1 hour)
- Review completed work
- Assess milestone progress
- Update long-term plans
- Retrospective discussion
- Process improvements

## Workflow Best Practices

### Adding New Work
1. Create issue with appropriate template
2. Starts in Ideas column
3. Discussed in weekly planning
4. Moved to Planned when approved

### Working on Items
1. Pick from top of Planned
2. Move to Active
3. Assign yourself
4. Add comments on progress
5. Link related PRs

### Completing Work
1. Move to Testing/Review
2. Get approval/testing
3. Move to Completed
4. Close the issue

### Handling Blockers
1. Move to On Hold
2. Add comment explaining blocker
3. Link blocking issue/dependency
4. Set reminder to check back
5. Move back to Active when unblocked

## Metrics to Track

### Lead Time
- Time from Planned to Completed
- Helps predict delivery
- Track by size category

### Throughput
- Items completed per week/month
- Indicates capacity
- Use for planning

### Work Distribution
- Percentage by type/category
- Balance feature vs maintenance
- Identify patterns

## Tips for Success

1. **Keep it simple** - Start with basics, add complexity as needed
2. **Be consistent** - Regular updates and reviews
3. **Stay flexible** - Adapt to your team's needs
4. **Limit WIP** - Don't overload Active column
5. **Document decisions** - Use issue comments
6. **Review regularly** - Weekly planning is key
7. **Celebrate progress** - Acknowledge completed milestones

## Common Issues and Solutions

### Problem: Too many items in Active
**Solution**: Limit WIP, focus on completion

### Problem: Items stuck On Hold
**Solution**: Regular blocker review, escalate issues

### Problem: Ideas column overflowing
**Solution**: Regular grooming, reject/defer non-priorities

### Problem: Unclear priorities
**Solution**: Explicit prioritization, clear criteria

## Migration from Other Systems

### From Kanban
- Kanban's Backlog → Ideas and Planned
- Keep work-in-progress limits
- Add On Hold for blocked items

### From Scrum
- Product Backlog → Ideas and Planned
- Remove sprint constraints
- More flexible item movement

### From Ad-hoc
- Document existing work as issues
- Categorize and prioritize
- Start with current state

## Customization Ideas

### Additional Columns
- **Under Review** (split Testing/Review)
- **Deployed** (before Completed)
- **Needs Information** (for items awaiting input)

### Additional Labels
- Team-specific categories
- Technology tags
- Customer impact levels
- Business unit labels

## Resources

- [PROJECT-TRACKER.md](../PROJECT-TRACKER.md) - Full methodology guide
- [Issue Templates](../ISSUE_TEMPLATE/) - Templates for creating issues
- [GitHub Projects Documentation](https://docs.github.com/en/issues/planning-and-tracking-with-projects)

## Support

For questions or issues with the board setup:
1. Check the [PROJECT-TRACKER.md](../PROJECT-TRACKER.md) guide
2. Review GitHub Projects documentation
3. Discuss with the team
