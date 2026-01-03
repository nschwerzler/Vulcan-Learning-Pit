using System.Configuration;
using System.Data;
using System.Windows;
using Spock.Engine;

namespace Spock.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private DebugServer? _debugServer;

    // Public property so MainWindow can access it
    public static DebugServer? DebugServerInstance { get; private set; }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

#if DEBUG
        // Start debug server in debug builds only
        try
        {
            _debugServer = new DebugServer(port: 5555);
            await _debugServer.StartAsync();
            DebugServerInstance = _debugServer;
            
            // Add some initial debug state
            _debugServer.State["appStartTime"] = DateTime.UtcNow;
            _debugServer.State["version"] = "1.0.0-dev";
            _debugServer.State["environment"] = "Debug";
            
            System.Diagnostics.Debug.WriteLine("Debug server running at http://localhost:5555");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to start debug server: {ex.Message}");
        }
#endif
    }

    protected override async void OnExit(ExitEventArgs e)
    {
#if DEBUG
        if (_debugServer != null)
        {
            await _debugServer.StopAsync();
            _debugServer.Dispose();
            DebugServerInstance = null;
        }
#endif
        base.OnExit(e);
    }
}

