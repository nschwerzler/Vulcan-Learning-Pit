using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Spock.Data;
using Spock.Engine;

namespace Spock.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private DebugServer? _debugServer;
    private static string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "spock-debug.log");
    private static SpockDbContext? _dbContext;

    // Public property so MainWindow can access it
    public static DebugServer? DebugServerInstance { get; private set; }
    public static SpockDbContext? DbContext => _dbContext;

    public static void Log(string message)
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var logMessage = $"[{timestamp}] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            System.Diagnostics.Debug.WriteLine(logMessage);
        }
        catch { /* Ignore logging errors */ }
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Set up global exception handlers
        DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        
        Log("========== APPLICATION STARTING ==========");
        Log($"Log file: {_logFilePath}");
        
        base.OnStartup(e);

        // Initialize database
        try
        {
            Log("Initializing SQLite database...");
            
            // Database in workspace root database\ folder
            var workspaceRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\"));
            var databaseFolder = Path.Combine(workspaceRoot, "database");
            Directory.CreateDirectory(databaseFolder); // Ensure folder exists
            var dbPath = Path.Combine(databaseFolder, "spock.db");
            
            var optionsBuilder = new DbContextOptionsBuilder<SpockDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            
            _dbContext = new SpockDbContext(optionsBuilder.Options);
            
            // Seed database if needed
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext);
            
            // Initialize ProblemBank with the context
            ProblemBank.Initialize(_dbContext);
            
            Log($"Database initialized at {dbPath}");
        }
        catch (Exception ex)
        {
            Log($"FATAL: Failed to initialize database: {ex.Message}");
            Log($"StackTrace: {ex.StackTrace}");
            MessageBox.Show(
                $"Failed to initialize database:\n\n{ex.Message}\n\nApplication will now exit.",
                "Database Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            Shutdown(1);
            return;
        }

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
        Log("========== APPLICATION EXITING ==========");
        
        // Dispose database context
        _dbContext?.Dispose();
        
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

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Log($"UNHANDLED DISPATCHER EXCEPTION: {e.Exception.GetType().Name}");
        Log($"Message: {e.Exception.Message}");
        Log($"StackTrace: {e.Exception.StackTrace}");
        if (e.Exception.InnerException != null)
        {
            Log($"InnerException: {e.Exception.InnerException.Message}");
            Log($"InnerException StackTrace: {e.Exception.InnerException.StackTrace}");
        }
        
        MessageBox.Show(
            $"Application Error:\n\n{e.Exception.Message}\n\nSee {_logFilePath} for details.",
            "Error",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
        
        e.Handled = true;
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception;
        Log($"UNHANDLED EXCEPTION: {exception?.GetType().Name ?? "Unknown"}");
        Log($"Message: {exception?.Message ?? "Unknown"}");
        Log($"StackTrace: {exception?.StackTrace ?? "Unknown"}");
        Log($"IsTerminating: {e.IsTerminating}");
    }
}
