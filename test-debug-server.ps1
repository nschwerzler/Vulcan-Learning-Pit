# Spock Learning - Debug Server Test Script
# This script demonstrates how to use the HTTP debug server

Write-Host "=== Spock Learning Debug Server Test ===" -ForegroundColor Cyan
Write-Host ""

$baseUrl = "http://localhost:5555"

# Function to display JSON nicely
function Show-DebugEndpoint {
    param(
        [string]$Endpoint,
        [string]$Description
    )
    
    Write-Host "▶ $Description" -ForegroundColor Green
    Write-Host "  GET $baseUrl$Endpoint" -ForegroundColor DarkGray
    try {
        $result = Invoke-RestMethod "$baseUrl$Endpoint" -ErrorAction Stop
        $json = $result | ConvertTo-Json -Depth 5
        Write-Host $json -ForegroundColor White
    }
    catch {
        Write-Host "  ❌ Error: $($_.Exception.Message)" -ForegroundColor Red
    }
    Write-Host ""
}

# Test endpoints
Write-Host "Testing debug server endpoints..." -ForegroundColor Yellow
Write-Host ""

Show-DebugEndpoint "/" "Available Endpoints"
Show-DebugEndpoint "/health" "Health Check"
Show-DebugEndpoint "/state" "All Application State"
Show-DebugEndpoint "/session" "Current Session Info"
Show-DebugEndpoint "/approval" "Approval Engine State"
Show-DebugEndpoint "/weaknesses" "Weakness Tracker"

Write-Host "=== Test Complete ===" -ForegroundColor Cyan
Write-Host ""
Write-Host "💡 Tip: Open your browser to http://localhost:5555 to explore the API" -ForegroundColor Magenta
Write-Host "💡 Or use: curl http://localhost:5555/session" -ForegroundColor Magenta
