# Vulcan-Learning-Pit

## Repository Security

This repository has security configurations in place to protect the `main` branch and ensure proper code review processes.

### Key Security Features

1. **CODEOWNERS**: All pull requests require review and approval from @nschwerzler
2. **Branch Protection**: The main branch is protected with rules that:
   - Require pull requests for all changes
   - Require at least 1 approving review
   - Require code owner review (nschwerzler)
   - Block force pushes and deletions
   - Prevent non-fast-forward pushes

3. **Administrator Bypass**: nschwerzler (as repository administrator) can bypass branch protection rules when necessary for emergency fixes

### Setup Instructions

See [.github/SECURITY_SETUP.md](.github/SECURITY_SETUP.md) for detailed instructions on how to apply these security settings to the GitHub repository.

### Automated Validation

The repository includes a GitHub Actions workflow that validates:
- Pull requests have required reviews before merging
- Security configuration files are present and valid

For more information, see the [branch protection workflow](.github/workflows/branch-protection.yml).