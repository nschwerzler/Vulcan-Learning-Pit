# PowerShell script to verify SHA256 checksums for Vulcan Learning Pit packages

param(
    [Parameter(Mandatory=$true)]
    [string]$PackageFile
)

$ChecksumFile = "${PackageFile}.sha256"

# Check if files exist
if (-not (Test-Path $PackageFile)) {
    Write-Host "Error: Package file '$PackageFile' not found!" -ForegroundColor Red
    exit 1
}

if (-not (Test-Path $ChecksumFile)) {
    Write-Host "Error: Checksum file '$ChecksumFile' not found!" -ForegroundColor Red
    exit 1
}

Write-Host "Verifying checksum for ${PackageFile}..." -ForegroundColor Blue

# Calculate the actual checksum
$actualHash = (Get-FileHash -Algorithm SHA256 $PackageFile).Hash.ToLower()

# Read the expected checksum
$expectedHash = (Get-Content $ChecksumFile).Split()[0].Trim()

# Compare
if ($actualHash -eq $expectedHash) {
    Write-Host "✓ Checksum verification PASSED" -ForegroundColor Green
    Write-Host "The package is authentic and has not been tampered with." -ForegroundColor Green
    exit 0
} else {
    Write-Host "✗ Checksum verification FAILED" -ForegroundColor Red
    Write-Host "WARNING: The package may have been corrupted or tampered with!" -ForegroundColor Red
    Write-Host "Do NOT use this package." -ForegroundColor Red
    Write-Host "`nExpected: $expectedHash" -ForegroundColor Yellow
    Write-Host "Actual:   $actualHash" -ForegroundColor Yellow
    exit 1
}
