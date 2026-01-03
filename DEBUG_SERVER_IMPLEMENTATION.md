# HTTP Debug Server - Implementation Summary

## What Was Added

### 1. DebugServer Class (`src/Spock.Engine/DebugServer.cs`)
- Embedded ASP.NET Core Kestrel server running on port 5555
- Thread-safe state dictionary exposed via HTTP endpoints
- 6 RESTful endpoints for inspecting application state
- Only runs in DEBUG builds (automatically disabled in RELEASE)
- Clean startup/shutdown lifecycle management

### 2. Application Integration
- **App.xaml.cs**: Starts debug server on application startup
- **MainWindow.xaml.cs**: Passes debug server reference to ViewModel
- **MainViewModel.cs**: Updates debug state after each problem and session change

### 3. Available Debug Endpoints
- `GET /` - List all available endpoints
- `GET /health` - Server health check with timestamp
- `GET /state` - All application state
- `GET /state/{key}` - Specific state value
- `GET /session` - Current session info (streak, accuracy, problem details)
- `GET /approval` - Approval engine state (threshold, history)
- `GET /weaknesses` - Weakness tracker data

### 4. Documentation & Tools
- **debug-dashboard.html**: Real-time web dashboard with auto-refresh
- **test-debug-server.ps1**: PowerShell script to test all endpoints
- **DEBUG_SERVER.md**: Complete API documentation
- **README.md**: Updated with debug server section

## How to Use

### Option 1: Web Dashboard (Easiest)
```powershell
# Start the app
dotnet run --project src/Spock.UI/Spock.UI.csproj

# Open debug-dashboard.html in your browser
# Auto-refreshes every 5 seconds
```

### Option 2: PowerShell
```powershell
# Start the app
dotnet run --project src/Spock.UI/Spock.UI.csproj

# Query endpoints
Invoke-RestMethod http://localhost:5555/session | ConvertTo-Json -Depth 5
Invoke-RestMethod http://localhost:5555/approval

# Or run the test script
.\test-debug-server.ps1
```

### Option 3: Browser
Navigate directly to: `http://localhost:5555/session`

## What Can You Debug?

### Session Metrics
- Current correct streak
- Total attempts and accuracy
- Current problem details (domain, difficulty, microtopic)
- Problem bank position

### Approval Engine
- Current streak toward next approval
- Approval threshold (variable 3-7)
- Recent approval history (last 5)
- Approval types and intensities

### Application State
- App start time
- Environment info
- All custom state values

## Technical Details

### Architecture
- **Server**: ASP.NET Core Kestrel (minimal API)
- **Port**: 5555 (configurable)
- **CORS**: Enabled for local development
- **Threading**: Thread-safe dictionary for state
- **Lifecycle**: Starts with app, stops on exit

### Performance Impact
- Minimal overhead (only in DEBUG builds)
- Async operations don't block UI thread
- State updates are fire-and-forget
- No impact on RELEASE builds (compiled out)

### Files Modified
1. `src/Spock.Engine/Spock.Engine.csproj` - Added FrameworkReference
2. `src/Spock.Engine/DebugServer.cs` - New file
3. `src/Spock.UI/App.xaml.cs` - Startup/shutdown logic
4. `src/Spock.UI/MainWindow.xaml.cs` - Pass debug server to ViewModel
5. `src/Spock.UI/ViewModels/MainViewModel.cs` - State update method

### Files Created
1. `debug-dashboard.html` - Web dashboard
2. `test-debug-server.ps1` - Test script
3. `src/Spock.UI/DEBUG_SERVER.md` - API documentation

## Benefits

### For Debugging
- Real-time visibility into application state
- No need to attach debugger for simple inspection
- Monitor state changes as you interact with UI
- Quickly verify adaptive engine behavior

### For Development
- Test approval thresholds without UI
- Verify session coordination logic
- Monitor weakness tracking in real-time
- Debug state machine transitions

### For Testing
- Automated testing via HTTP endpoints
- Integration test verification
- Performance monitoring
- State inspection for test assertions

## Security Note

The debug server:
- Only runs in DEBUG configuration
- Only binds to localhost (not accessible remotely)
- Automatically disabled in production/release builds
- No authentication needed (development only)

## Next Steps

You can now:
1. Run the app: `dotnet run --project src/Spock.UI/Spock.UI.csproj`
2. Open `debug-dashboard.html` in your browser
3. Interact with the app and watch the state update in real-time
4. Use the API endpoints to automate testing or monitoring

---

**Debug server is ready to use! 🚀**
