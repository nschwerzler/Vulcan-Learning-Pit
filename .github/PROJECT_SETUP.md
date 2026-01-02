# Project Board Configuration

This file contains instructions for setting up the GitHub Projects Kanban board for this repository.

## Automated Setup (Recommended)

### Step 1: Create a New Project
1. Navigate to your repository on GitHub
2. Click the "Projects" tab
3. Click "Link a project" → "New project"
4. Select "Board" template
5. Name it "Kanban Board"

### Step 2: Customize Columns
The board should have these columns (rename or add as needed):
- **Backlog** (default: "Todo")
- **To Do** 
- **In Progress** (default: "In Progress")
- **Review**
- **Done** (default: "Done")

### Step 3: Configure Automation (Optional)
GitHub Projects v2 includes built-in automation. Configure these workflows:
1. **Item opened**: When issues/PRs are opened → Add to Backlog
2. **Item closed**: When issues/PRs are closed → Move to Done
3. **Pull request merged**: When PRs are merged → Move to Done

### Step 4: Update GitHub Actions Workflow
Edit `.github/workflows/kanban.yml` to include your project number:
```yaml
with:
  project-url: https://github.com/users/USERNAME/projects/PROJECT_NUMBER
  github-token: ${{ secrets.GITHUB_TOKEN }}
```

## Manual Setup

If you prefer manual setup:

1. Create issues using the templates in `.github/ISSUE_TEMPLATE/`
2. Manually add them to your project board
3. Drag and drop issues between columns as work progresses

## Column Definitions

### Backlog
- Items identified but not prioritized
- No assignees yet
- May need more details or discussion

### To Do
- Items ready to start
- Fully defined and understood
- May have assignees

### In Progress
- Currently being worked on
- Should have assignees
- Should have "in-progress" label

### Review
- Work completed, awaiting review
- Pull request created and linked
- Should have "needs-review" label

### Done
- Completed and merged
- Issue closed
- No further action needed

## Customization

Feel free to customize:
- Column names to match your workflow
- Add/remove columns as needed
- Adjust automation rules
- Create custom fields (priority, size, etc.)
- Add views (by assignee, milestone, etc.)

## Integration with Issue Templates

The repository includes three issue templates:
- **Task** (`.github/ISSUE_TEMPLATE/task.yml`)
- **Bug Report** (`.github/ISSUE_TEMPLATE/bug.yml`)
- **Feature Request** (`.github/ISSUE_TEMPLATE/feature.yml`)

These templates automatically apply labels that can be used for board filtering and organization.

## Troubleshooting

### Issues not appearing on board
- Ensure the project is linked to the repository
- Check that the GitHub Actions workflow has proper permissions
- Manually add items if automation isn't working

### Workflow not triggering
- Verify the workflow file syntax
- Check repository Actions permissions
- Ensure the project URL is correct in the workflow

### Need help?
- See [GitHub Projects Documentation](https://docs.github.com/en/issues/planning-and-tracking-with-projects)
- Review [KANBAN.md](KANBAN.md) for usage guidelines
