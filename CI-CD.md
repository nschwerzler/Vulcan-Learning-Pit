# CI/CD Documentation

This document describes the Continuous Integration and Continuous Deployment (CI/CD) setup for Vulcan Learning Pit.

## Overview

The project uses GitHub Actions for automated building, testing, and releasing. Two main workflows handle the CI/CD pipeline:

1. **Build and Package** (`build.yml`) - Continuous Integration
2. **Release with Checksums** (`release.yml`) - Release Automation

## Build and Package Workflow

**Trigger:** Automatically runs on every push or pull request to `main`, `master`, or `develop` branches.

**Purpose:** Ensures code quality and creates build artifacts for testing.

### Jobs

#### 1. Build Job
- Restores dependencies
- Builds the project in Release configuration
- Runs tests (if available)

#### 2. Package Job
- Builds self-contained executables for:
  - Linux (x64)
  - Windows (x64)
- Creates compressed archives (tar.gz for Linux, zip for Windows)
- Generates SHA256 checksums for each archive
- Displays checksums in the build log
- Uploads artifacts with 30-day retention

### Accessing Build Artifacts

1. Go to the repository's [Actions](../../actions) tab
2. Click on a workflow run
3. Scroll down to the "Artifacts" section
4. Download the desired platform package (includes both the archive and checksum file)

## Release Workflow

**Trigger:** Automatically runs when a version tag (e.g., `v1.0.0`) is pushed, or can be manually triggered via workflow_dispatch.

**Purpose:** Creates official releases with all platform builds and checksums.

### Jobs

#### Build and Release Job (Matrix Strategy)
- Builds self-contained executables for:
  - Linux (x64)
  - Windows (x64)
  - macOS (x64)
  - macOS (ARM64/Apple Silicon)
- Creates compressed archives
- Generates SHA256 checksums
- Uploads artifacts with 90-day retention
- Creates GitHub Release with all artifacts (when triggered by a tag)

### Creating a Release

To create a new release:

```bash
# Ensure you're on the main branch
git checkout main

# Create and push a version tag
git tag -a v1.0.0 -m "Release version 1.0.0"
git push origin v1.0.0
```

The workflow will automatically:
1. Build packages for all platforms
2. Generate checksums
3. Create a GitHub Release
4. Attach all packages and checksums to the release

## Security Considerations

### SHA256 Checksums

Every package includes a SHA256 checksum file that:
- Ensures download integrity
- Detects file corruption
- Prevents tampering
- Is automatically generated during the build process

### Self-Contained Builds

All releases are self-contained, meaning:
- No .NET runtime installation required
- Reduced dependency conflicts
- Better security through isolation
- Larger file sizes, but better user experience

### Build Reproducibility

- All builds use the same .NET SDK version (10.0.x)
- Builds are automated via GitHub Actions
- No manual intervention in the build process
- Source code and build scripts are version controlled

## Workflow Configuration

### .NET SDK Version

Both workflows use .NET 10.0.x:
```yaml
- name: Setup .NET
  uses: actions/setup-dotnet@v4
  with:
    dotnet-version: '10.0.x'
```

### Build Options

Self-contained single-file builds with trimming:
```bash
dotnet publish \
  -c Release \
  -r <runtime> \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true
```

### Supported Runtimes

- `linux-x64` - Linux on x64 architecture
- `win-x64` - Windows on x64 architecture
- `osx-x64` - macOS on Intel processors
- `osx-arm64` - macOS on Apple Silicon (M1/M2/M3)

## Monitoring Builds

### Build Status

Check the [Actions](../../actions) tab to see:
- Build status (success/failure)
- Build logs
- Test results
- Generated checksums
- Downloadable artifacts

### Build Failures

If a build fails:
1. Click on the failed workflow run
2. Expand the failed job
3. Review the error messages
4. Fix the issue and push a new commit

## Local Development

You can replicate the CI/CD process locally using the provided scripts:

### Linux/macOS
```bash
./build-packages.sh
```

### Windows (PowerShell)
```powershell
.\build-packages.ps1
```

These scripts create the same packages and checksums as the CI/CD pipeline.

## Artifact Retention

- **Build Artifacts**: Retained for 30 days
- **Release Artifacts**: Retained for 90 days
- **GitHub Releases**: Permanent (until manually deleted)

## Future Enhancements

Potential improvements to the CI/CD pipeline:

- [ ] Add automated testing
- [ ] Add code coverage reporting
- [ ] Add security scanning (CodeQL, Dependabot)
- [ ] Add performance benchmarking
- [ ] Add Docker image builds
- [ ] Add changelog generation
- [ ] Add release notes automation
- [ ] Add notification on release
- [ ] Add GPG signing of releases

## Troubleshooting

### Build Fails on Restore
**Problem:** `dotnet restore` fails
**Solution:** Check that all NuGet package sources are accessible

### Package Creation Fails
**Problem:** Archive creation fails
**Solution:** Ensure `zip` and `tar` commands are available in the runner

### Checksum Mismatch
**Problem:** Downloaded package fails checksum verification
**Solution:** Re-download both the package and checksum file

### Release Not Created
**Problem:** GitHub Release not created after tag push
**Solution:** Ensure the tag starts with 'v' (e.g., v1.0.0, not 1.0.0)

## Contact

For questions or issues with the CI/CD pipeline, please open an issue in the repository.
