# Kanban Board Guide

## Overview
This repository uses a Kanban board to track and manage work items. The board provides a visual representation of work in progress and helps the team stay organized.

## Board Structure

### Columns
The Kanban board is organized into the following columns:

1. **Backlog** - Items that are identified but not yet ready to be worked on
2. **To Do** - Items that are ready to be started
3. **In Progress** - Items currently being worked on
4. **Review** - Items that are complete and awaiting review
5. **Done** - Completed items

## Creating Issues

### Issue Types
The repository supports three types of issues:

#### 1. Task
Use for general work items, improvements, or maintenance tasks.
- Label: `task`
- Template: `.github/ISSUE_TEMPLATE/task.yml`

#### 2. Bug Report
Use for reporting bugs or defects.
- Label: `bug`
- Template: `.github/ISSUE_TEMPLATE/bug.yml`

#### 3. Feature Request
Use for proposing new features or enhancements.
- Label: `enhancement`
- Template: `.github/ISSUE_TEMPLATE/feature.yml`

## Using the Kanban Board

### Adding Items
1. Create a new issue using one of the templates
2. The issue will automatically be added to the Kanban board (via GitHub Actions)
3. Initially, items appear in the **Backlog** column

### Moving Items
1. Drag and drop issues between columns as work progresses
2. Update issue status when moving items:
   - **To Do**: Add assignee(s) and set milestone if applicable
   - **In Progress**: Add "in-progress" label
   - **Review**: Create pull request and link to issue
   - **Done**: Close the issue

### Best Practices
- **Limit Work in Progress (WIP)**: Try to limit the number of items in "In Progress" to maintain focus
- **Update Regularly**: Move items as their status changes
- **Link PRs**: Always link pull requests to related issues
- **Add Details**: Keep issue descriptions clear and up-to-date
- **Use Labels**: Apply appropriate labels for better organization
- **Set Priorities**: Use priority labels to indicate urgency

## Labels

The following labels help organize and prioritize work:

### Priority Labels
- `priority: low` - Low priority items
- `priority: medium` - Medium priority items (default)
- `priority: high` - High priority items
- `priority: critical` - Critical items that need immediate attention

### Type Labels
- `task` - General tasks
- `bug` - Bug reports
- `enhancement` - Feature requests and enhancements
- `documentation` - Documentation updates

### Status Labels
- `in-progress` - Currently being worked on
- `blocked` - Blocked by dependencies or issues
- `needs-review` - Waiting for review

## Automation

The repository includes a GitHub Actions workflow (`.github/workflows/kanban.yml`) that automatically:
- Adds new issues to the project board
- Adds new pull requests to the project board

## Setting Up the Project Board

To set up a GitHub Projects board for this repository:

1. Go to the repository on GitHub
2. Click on the "Projects" tab
3. Click "New project"
4. Choose "Board" as the template
5. Name it "Kanban Board"
6. Customize the columns to match:
   - Backlog
   - To Do
   - In Progress
   - Review
   - Done

## Tips for Success

1. **Keep it visual**: Use the board as your primary view of work
2. **Daily updates**: Review and update the board daily
3. **Team collaboration**: Discuss board status in team meetings
4. **Continuous improvement**: Regularly review and adjust the process
5. **Clear definitions**: Ensure everyone understands what each column means

## Resources

- [GitHub Projects Documentation](https://docs.github.com/en/issues/planning-and-tracking-with-projects)
- [Kanban Methodology](https://www.atlassian.com/agile/kanban)
- [Agile Best Practices](https://www.atlassian.com/agile/project-management/kanban)
