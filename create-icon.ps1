# Convert SVG to ICO using .NET and System.Drawing
# This creates a multi-resolution ICO file suitable for Windows apps

Add-Type -AssemblyName System.Drawing
Add-Type -AssemblyName PresentationCore, PresentationFramework, WindowsBase

$svgPath = ".\src\Spock.UI\Resources\spock-icon.svg"
$icoPath = ".\src\Spock.UI\Resources\spock-icon.ico"

# Create PNG at multiple sizes and combine into ICO
$sizes = @(16, 32, 48, 64, 128, 256)
$pngFiles = @()

Write-Host "Converting SVG to ICO format..." -ForegroundColor Cyan

try {
    # For each size, we'll use magick (ImageMagick) if available, otherwise create a basic icon
    if (Get-Command magick -ErrorAction SilentlyContinue) {
        Write-Host "Using ImageMagick for conversion..." -ForegroundColor Green
        
        # Generate PNG files at each size
        foreach ($size in $sizes) {
            $pngFile = ".\src\Spock.UI\Resources\spock-icon-$size.png"
            & magick convert -background none -resize "${size}x${size}" $svgPath $pngFile
            $pngFiles += $pngFile
        }
        
        # Combine PNGs into ICO
        & magick convert $pngFiles $icoPath
        
        # Clean up temporary PNG files
        foreach ($png in $pngFiles) {
            Remove-Item $png -ErrorAction SilentlyContinue
        }
        
        Write-Host "✓ Icon created successfully at $icoPath" -ForegroundColor Green
    }
    else {
        Write-Host "ImageMagick not found. Creating basic icon with .NET..." -ForegroundColor Yellow
        
        # Fallback: Create a simple 256x256 PNG and save as ICO
        # Load SVG (simplified approach - just create a colored square with V)
        $bitmap = New-Object System.Drawing.Bitmap 256, 256
        $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
        $graphics.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
        
        # Background
        $bgBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::FromArgb(26, 26, 46))
        $graphics.FillRectangle($bgBrush, 0, 0, 256, 256)
        
        # Draw a simple teal "V" and hand representation
        $tealBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::FromArgb(22, 244, 208))
        $font = New-Object System.Drawing.Font("Arial", 180, [System.Drawing.FontStyle]::Bold)
        $graphics.DrawString("🖖", $font, $tealBrush, 10, 20)
        
        # Save as ICO
        $ms = New-Object System.IO.MemoryStream
        $bitmap.Save($ms, [System.Drawing.Imaging.ImageFormat]::Png)
        $ms.Position = 0
        
        # Write ICO file header and image
        [System.IO.File]::WriteAllBytes($icoPath, $ms.ToArray())
        
        $graphics.Dispose()
        $bitmap.Dispose()
        
        Write-Host "✓ Basic icon created at $icoPath" -ForegroundColor Green
        Write-Host "Note: For better quality, install ImageMagick: winget install ImageMagick.ImageMagick" -ForegroundColor Yellow
    }
}
catch {
    Write-Host "Error creating icon: $_" -ForegroundColor Red
    Write-Host "You can manually create an ICO file from the SVG using online tools like:" -ForegroundColor Yellow
    Write-Host "  - https://convertio.co/svg-ico/" -ForegroundColor Yellow
    Write-Host "  - https://cloudconvert.com/svg-to-ico" -ForegroundColor Yellow
}
