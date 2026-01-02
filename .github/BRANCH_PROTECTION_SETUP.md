# Branch Protection Setup Instructions

## Automatic Configuration (CODEOWNERS)
The `.github/CODEOWNERS` file is already configured to require your approval on all PRs.

## Manual GitHub Settings Configuration

To complete the setup, configure branch protection rules on GitHub:

### Steps:

1. Go to your repository on GitHub: `https://github.com/nschw/Spock`

2. Navigate to **Settings** → **Branches**

3. Click **Add branch protection rule**

4. Configure the following:

   **Branch name pattern:** `main` (or `master` if that's your default branch)

   **Protect matching branches - Check these boxes:**
   - ☑️ **Require a pull request before merging**
     - ☑️ Require approvals: **1**
     - ☑️ Require review from Code Owners
   - ☑️ **Do not allow bypassing the above settings**
   - ❌ **UNCHECK "Include administrators"** (this allows you to push directly)

5. Click **Create** or **Save changes**

### What This Achieves:

✅ **You (repo owner)** can:
- Push directly to main
- Merge PRs without approval
- Bypass branch protection rules

✅ **Other collaborators** must:
- Create pull requests
- Get your approval before merging (via CODEOWNERS)
- Cannot push directly to main

### Alternative: Stricter Protection (Optional)

If you want to use PRs yourself but skip approval:
- Check "Include administrators" 
- Your PRs will still require the approval requirement, but you can self-approve

### Verification:

After setup, test by:
1. Creating a test branch and PR from a collaborator account
2. Confirming that PR cannot be merged without your approval
3. Confirming you can still push directly to main

---

**Note**: These settings apply per branch. If you use other branches like `develop` or `staging`, create additional protection rules for them.
