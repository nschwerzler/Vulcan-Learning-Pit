# Repository Security Configuration

This repository has the following security configurations in place:

## Branch Protection Rules

The `main` branch is protected with the following rules:

### Required Reviews
- **At least 1 approving review required** before merging PRs
- **Code owner review required** (nschwerzler must review all PRs)
- Pull requests are required for all changes to main

### Additional Protections
- Force pushes are blocked
- Branch deletions are prevented
- Non-fast-forward pushes are blocked

## CODEOWNERS

The `.github/CODEOWNERS` file specifies that:
- **@nschwerzler** must review all changes to the repository
- This ensures nschwerzler reviews all PRs before they can be merged

## Administrator Bypass

- Repository administrators (including nschwerzler) have the ability to bypass branch protection rules
- This allows nschwerzler to directly push to main when necessary for emergency fixes
- However, the general workflow should use PRs for all changes

## Setting Up Branch Protection (Manual Steps)

To apply these settings to your GitHub repository:

### Option 1: Using GitHub Web UI

1. Go to **Settings** → **Branches** → **Branch protection rules**
2. Click **Add rule** or **Add branch ruleset**
3. For branch name pattern, enter: `main`
4. Enable the following settings:
   - ✅ Require a pull request before merging
   - ✅ Require approvals (set to 1)
   - ✅ Require review from Code Owners
   - ✅ Do not allow bypassing the above settings (uncheck this to allow admins to bypass)
   - ✅ Restrict who can push to matching branches
   - ✅ Block force pushes
   - ✅ Do not allow deletions

5. Under "Allow specified actors to bypass required pull requests":
   - Add nschwerzler or repository administrators

### Option 2: Using Rulesets (Recommended)

1. Go to **Settings** → **Rules** → **Rulesets**
2. Click **New ruleset** → **New branch ruleset**
3. Name it "Main Branch Protection"
4. Set target branches to `main`
5. Add the following rules:
   - Require a pull request before merging (1 approval required)
   - Require code owner review
   - Block force pushes
   - Restrict deletions
6. Under "Bypass list", add repository administrators or nschwerzler specifically

**Note:** The `branch-protection-ruleset.json` file is provided as a template reference. The `actor_id` field (currently set to 1) is a placeholder and must be replaced with the actual GitHub user ID or role ID for nschwerzler when importing via API. When using the web UI, you can select users/roles directly without needing these IDs.

## Testing the Configuration

1. Try to push directly to main (should be blocked for non-admins)
2. Create a PR and verify that nschwerzler is automatically requested as a reviewer
3. Verify that the PR cannot be merged without nschwerzler's approval
4. Verify that nschwerzler (as admin) can bypass rules if needed

## Notes

- The CODEOWNERS file works with branch protection to ensure nschwerzler's review is required
- Repository administrators always have the ability to bypass branch protection rules
- These settings help maintain code quality while allowing flexibility for emergency situations
