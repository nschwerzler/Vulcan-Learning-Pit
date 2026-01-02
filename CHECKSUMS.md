# Checksum Verification Guide

This document provides detailed instructions on how to verify the integrity of downloaded Vulcan Learning Pit packages using SHA256 checksums.

## Why Verify Checksums?

Verifying checksums ensures that:
- The file was not corrupted during download
- The file has not been tampered with
- You're running the exact software that was built and released by the maintainers

**Always verify checksums before running downloaded binaries!**

## Understanding SHA256 Checksums

SHA256 is a cryptographic hash function that generates a unique 256-bit (64-character hexadecimal) fingerprint for any file. Even a single bit change in the file will result in a completely different hash.

## Quick Start

### Using the Verification Script (Linux/macOS)

The easiest way to verify a package is using the provided script:

```bash
./verify-checksum.sh VulcanLearningPit-linux-x64.tar.gz
```

If verification passes, you'll see:
```
✓ Checksum verification PASSED
The package is authentic and has not been tampered with.
```

### Manual Verification

#### Linux

```bash
# Verify the checksum
sha256sum -c VulcanLearningPit-linux-x64.tar.gz.sha256

# Expected output:
# VulcanLearningPit-linux-x64.tar.gz: OK
```

#### macOS

```bash
# Verify the checksum
shasum -a 256 -c VulcanLearningPit-osx-x64.tar.gz.sha256

# Expected output:
# VulcanLearningPit-osx-x64.tar.gz: OK
```

#### Windows (PowerShell)

```powershell
# Calculate the checksum of your downloaded file
$hash = (Get-FileHash -Algorithm SHA256 .\VulcanLearningPit-win-x64.zip).Hash.ToLower()

# Read the expected checksum from the .sha256 file
$expected = (Get-Content .\VulcanLearningPit-win-x64.zip.sha256).Split()[0]

# Compare
if ($hash -eq $expected) {
    Write-Host "✓ Checksum verification PASSED" -ForegroundColor Green
    Write-Host "The package is authentic and has not been tampered with." -ForegroundColor Green
} else {
    Write-Host "✗ Checksum verification FAILED" -ForegroundColor Red
    Write-Host "WARNING: The package may have been corrupted or tampered with!" -ForegroundColor Red
}
```

## Checksum File Format

Each `.sha256` file contains the hash and filename in the format:
```
<64-character-hex-hash>  <filename>
```

Example:
```
c66de3f389025409112f3d1f316f8e99697d166f8a13d7a5240d762b64b56314  VulcanLearningPit-linux-x64.tar.gz
```

## What to Do If Verification Fails

If checksum verification fails:

1. **Re-download the package** - The file may have been corrupted during download
2. **Re-download the checksum file** - Make sure you have the correct checksum file
3. **Check the source** - Ensure you're downloading from the official GitHub releases page
4. **Report the issue** - If re-downloading doesn't help, report it as a security concern

**Never use a package that fails checksum verification!**

## Advanced: Generating Your Own Checksums

If you build packages yourself using the `build-packages.sh` script, checksums are automatically generated. You can also generate them manually:

### Linux/macOS
```bash
sha256sum VulcanLearningPit-linux-x64.tar.gz > VulcanLearningPit-linux-x64.tar.gz.sha256
```

### Windows (PowerShell)
```powershell
$hash = (Get-FileHash -Algorithm SHA256 .\VulcanLearningPit-win-x64.zip).Hash.ToLower()
$filename = "VulcanLearningPit-win-x64.zip"
"$hash  $filename" | Out-File -FilePath "VulcanLearningPit-win-x64.zip.sha256" -Encoding ASCII
```

## Automated Verification in CI/CD

The GitHub Actions workflows automatically generate and upload checksums with every build and release. You can verify this by:

1. Going to the [Actions](../../actions) tab
2. Selecting a workflow run
3. Viewing the logs where checksums are displayed
4. Downloading artifacts and their checksums

## Security Best Practices

1. **Always download from official sources** - Use the GitHub releases page or official distribution channels
2. **Verify before running** - Make it a habit to verify checksums before executing any downloaded binary
3. **Use HTTPS** - Always download over HTTPS to prevent man-in-the-middle attacks
4. **Keep tools updated** - Use up-to-date checksum verification tools
5. **Report issues** - If you find any security concerns, report them immediately

## Additional Resources

- [SHA-2 on Wikipedia](https://en.wikipedia.org/wiki/SHA-2)
- [NIST on Hash Functions](https://csrc.nist.gov/projects/hash-functions)
- [GitHub Security Best Practices](https://docs.github.com/en/code-security)

## Questions?

If you have questions about checksum verification, please open an issue in the repository.
