# Test script to run Spock.UI and capture output
$exePath = ".\src\Spock.UI\bin\Debug\net10.0-windows\Spock.UI.exe"

Write-Host "Starting Spock.UI with console output capture..." -ForegroundColor Green
Write-Host "Click the Parent Dashboard button in the app" -ForegroundColor Yellow
Write-Host "Console output will appear below:" -ForegroundColor Cyan
Write-Host "=" * 80

# Run with console attached
& $exePath

Write-Host ""
Write-Host "=" * 80
Write-Host "App closed. Press any key to exit..." -ForegroundColor Green
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
