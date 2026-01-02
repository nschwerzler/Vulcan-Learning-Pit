# Vulcan-Learning-Pit

A .NET learning platform demonstrating proper software packaging and distribution with SHA checksum validation.

## Overview

Vulcan Learning Pit is a sample .NET console application that showcases best practices for:
- Building cross-platform applications
- Automated release packaging
- SHA256 checksum generation and verification
- Secure software distribution

## Download

### Latest Release

You can download the latest pre-built binaries from the [Releases](../../releases) page. We provide builds for:
- Linux (x64)
- Windows (x64)
- macOS (x64)
- macOS (ARM64)

### Build Artifacts

For development builds, you can download artifacts from the [Actions](../../actions) tab after each successful build.

## Verifying Downloads

Each release package comes with a SHA256 checksum file for security verification. **Always verify the checksum before running the application.**

### Linux/macOS Verification

1. Download both the package and its `.sha256` checksum file
2. Verify the checksum:

```bash
# For Linux
sha256sum -c VulcanLearningPit-linux-x64.tar.gz.sha256

# For macOS
shasum -a 256 -c VulcanLearningPit-osx-x64.tar.gz.sha256
```

If the verification is successful, you'll see:
```
VulcanLearningPit-linux-x64.tar.gz: OK
```

### Windows Verification

1. Download both the package and its `.sha256` checksum file
2. Open PowerShell and verify:

```powershell
# Calculate the checksum of your downloaded file
$hash = (Get-FileHash -Algorithm SHA256 VulcanLearningPit-win-x64.zip).Hash

# Read the expected checksum from the .sha256 file
$expected = (Get-Content VulcanLearningPit-win-x64.zip.sha256).Split()[0]

# Compare
if ($hash -eq $expected) {
    Write-Host "Checksum verification PASSED" -ForegroundColor Green
} else {
    Write-Host "Checksum verification FAILED" -ForegroundColor Red
}
```

## Installation

### Linux/macOS

```bash
# Extract the archive
tar -xzf VulcanLearningPit-linux-x64.tar.gz

# Make executable (if needed)
chmod +x VulcanLearningPit

# Run the application
./VulcanLearningPit
```

### Windows

```powershell
# Extract the archive
Expand-Archive VulcanLearningPit-win-x64.zip -DestinationPath VulcanLearningPit

# Navigate to the directory
cd VulcanLearningPit

# Run the application
.\VulcanLearningPit.exe
```

## Building from Source

If you prefer to build from source:

```bash
# Clone the repository
git clone https://github.com/nschwerzler/Vulcan-Learning-Pit.git
cd Vulcan-Learning-Pit

# Restore dependencies
dotnet restore src/VulcanLearningPit/VulcanLearningPit.csproj

# Build
dotnet build src/VulcanLearningPit/VulcanLearningPit.csproj -c Release

# Run
dotnet run --project src/VulcanLearningPit/VulcanLearningPit.csproj
```

### Creating Self-Contained Releases

To create a self-contained executable for your platform:

```bash
# For Linux
dotnet publish src/VulcanLearningPit/VulcanLearningPit.csproj \
  -c Release \
  -r linux-x64 \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true \
  -o ./publish/linux-x64

# For Windows
dotnet publish src/VulcanLearningPit/VulcanLearningPit.csproj \
  -c Release \
  -r win-x64 \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true \
  -o ./publish/win-x64

# For macOS
dotnet publish src/VulcanLearningPit/VulcanLearningPit.csproj \
  -c Release \
  -r osx-x64 \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true \
  -o ./publish/osx-x64
```

## CI/CD Pipeline

This project uses GitHub Actions for automated building and releasing:

- **Build Workflow** (`build.yml`): Runs on every push/PR, builds the application for multiple platforms, generates checksums, and uploads artifacts
- **Release Workflow** (`release.yml`): Triggers on version tags, creates GitHub releases with all platform builds and their checksums

## Security

We take security seriously:
- All releases include SHA256 checksums for integrity verification
- Self-contained builds reduce dependency conflicts
- Automated builds ensure reproducibility
- No secrets or sensitive data in the codebase

**Always verify checksums before running downloaded binaries!**

## Requirements

- .NET 10.0 SDK (for building from source)
- No runtime required for pre-built releases (self-contained)

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## License

See [LICENSE](LICENSE) file for details.
