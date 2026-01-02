# PowerShell script to build packages and generate SHA256 checksums for Vulcan Learning Pit

# Define platforms
$platforms = @("linux-x64", "win-x64", "osx-x64", "osx-arm64")

Write-Host "Building Vulcan Learning Pit packages..." -ForegroundColor Blue

# Clean previous builds
if (Test-Path "./publish") { Remove-Item -Recurse -Force "./publish" }
Get-ChildItem -Path "." -Filter "VulcanLearningPit-*" | Remove-Item -Force

# Build for each platform
foreach ($platform in $platforms) {
    Write-Host "`nBuilding for ${platform}..." -ForegroundColor Green
    
    dotnet publish src/VulcanLearningPit/VulcanLearningPit.csproj `
        -c Release `
        -r $platform `
        --self-contained true `
        -p:PublishSingleFile=true `
        -p:PublishTrimmed=true `
        -o "./publish/${platform}"
    
    # Create archives
    Set-Location "./publish/${platform}"
    
    if ($platform -like "win-*") {
        # Windows: Create zip
        Compress-Archive -Path * -DestinationPath "../../VulcanLearningPit-${platform}.zip" -Force
        Set-Location "../.."
        
        # Generate checksum
        $hash = (Get-FileHash -Algorithm SHA256 "VulcanLearningPit-${platform}.zip").Hash.ToLower()
        $filename = "VulcanLearningPit-${platform}.zip"
        "$hash  $filename" | Out-File -FilePath "VulcanLearningPit-${platform}.zip.sha256" -Encoding ASCII -NoNewline
        
        Write-Host "Created VulcanLearningPit-${platform}.zip and checksum" -ForegroundColor Green
        Get-Content "VulcanLearningPit-${platform}.zip.sha256"
    } else {
        # Linux/macOS: Create tar.gz (requires tar in PATH on Windows)
        if (Get-Command tar -ErrorAction SilentlyContinue) {
            tar -czf "../../VulcanLearningPit-${platform}.tar.gz" *
            Set-Location "../.."
            
            # Generate checksum
            $hash = (Get-FileHash -Algorithm SHA256 "VulcanLearningPit-${platform}.tar.gz").Hash.ToLower()
            $filename = "VulcanLearningPit-${platform}.tar.gz"
            "$hash  $filename" | Out-File -FilePath "VulcanLearningPit-${platform}.tar.gz.sha256" -Encoding ASCII -NoNewline
            
            Write-Host "Created VulcanLearningPit-${platform}.tar.gz and checksum" -ForegroundColor Green
            Get-Content "VulcanLearningPit-${platform}.tar.gz.sha256"
        } else {
            Write-Warning "tar command not found. Skipping ${platform} archive creation."
            Set-Location "../.."
        }
    }
}

Write-Host "`nAll packages built successfully!" -ForegroundColor Blue
Write-Host "Package files and their checksums are in the current directory." -ForegroundColor Blue
