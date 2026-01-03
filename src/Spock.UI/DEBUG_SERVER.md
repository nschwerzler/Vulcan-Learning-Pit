# Spock Learning - Debug Server

## HTTP Debug Server Integration

The Spock Learning application now includes an embedded HTTP debug server that runs during development (DEBUG builds only). This allows you to inspect the application state in real-time through HTTP endpoints.

### Quick Start

1. **Run the application in Debug mode:**
   ```powershell
   dotnet run --project src/Spock.UI/Spock.UI.csproj
   ```

2. **Access the debug server:** 
   - **Web Dashboard**: Open `debug-dashboard.html` in your browser (auto-refreshes every 5 seconds)
   - **Direct API**: Use `http://localhost:5555` endpoints

### Web Dashboard (Recommended)

Open [debug-dashboard.html](../../debug-dashboard.html) in any browser for a real-time visual dashboard:
- Health status monitoring
- Current session metrics (streak, accuracy, problem details)
- Approval engine state with history
- Weakness tracking visualization
- Full state JSON viewer
- Auto-refresh every 5 seconds

### Available Endpoints

#### Root - List all endpoints
```
GET http://localhost:5555/
```
Returns a list of all available debug endpoints.

#### Health Check
```
GET http://localhost:5555/health
```
Returns server status and timestamp.

#### Application State
```
GET http://localhost:5555/state
```
Returns all debug state data (session info, approval engine, etc.).

#### Specific State Key
```
GET http://localhost:5555/state/{key}
```
Get a specific piece of state (e.g., `/state/currentSession`, `/state/appStartTime`).

#### Current Session Info
```
GET http://localhost:5555/session
```
Returns detailed information about the current learning session:
- Correct streak
- Total attempts
- Accuracy percentage
- Current problem details (domain, difficulty, etc.)
- Last update timestamp

#### Approval Engine State
```
GET http://localhost:5555/approval
```
Returns the approval engine's internal state:
- Current correct streak
- Approval threshold (variable-ratio 3-7)
- Recent approval history

#### Weakness Tracker
```
GET http://localhost:5555/weaknesses
```
Returns tracked weaknesses and targeted skills.

### Example Usage

Using PowerShell:
```powershell
# Check if server is healthy
Invoke-RestMethod http://localhost:5555/health

# Get current session info
Invoke-RestMethod http://localhost:5555/session | ConvertTo-Json -Depth 5

# Monitor approval engine
Invoke-RestMethod http://localhost:5555/approval
```

Using curl:
```bash
curl http://localhost:5555/session
```

Using a browser:
Just navigate to `http://localhost:5555/session` to see the JSON output.

### How It Works

1. **Automatic Startup**: The debug server starts automatically when the WPF application launches (DEBUG mode only)
2. **Real-Time Updates**: The `MainViewModel` updates the debug state after each problem submission
3. **No Impact on Release**: The debug server is compiled out of RELEASE builds
4. **Clean Shutdown**: The server automatically stops when the application closes

### Implementation Details

- **Server**: ASP.NET Core Kestrel embedded in WPF app
- **Port**: 5555 (configurable in `App.xaml.cs`)
- **CORS**: Enabled for local development
- **State**: Thread-safe dictionary exposed through HTTP endpoints

### Troubleshooting

If the server fails to start:
- Check if port 5555 is already in use
- Look for error messages in the Debug output window
- Ensure you're running in DEBUG configuration

To kill the running process before rebuilding:
```powershell
Get-Process Spock.UI -ErrorAction SilentlyContinue | Stop-Process -Force
```

---

*The debug server is part of the Spock Learning adaptive education system. See [docs/plan.md](../docs/plan.md) for full project details.*
