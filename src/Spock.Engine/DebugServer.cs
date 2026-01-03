using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Spock.Engine;

/// <summary>
/// Embedded HTTP debug server for inspecting application state during development.
/// Runs on http://localhost:5555 by default.
/// </summary>
public class DebugServer : IDisposable
{
    private WebApplication? _app;
    private Task? _runTask;
    private readonly int _port;
    private readonly CancellationTokenSource _cts;

    // Debug state that can be injected and exposed
    public Dictionary<string, object> State { get; } = new();

    public DebugServer(int port = 5555)
    {
        _port = port;
        _cts = new CancellationTokenSource();
    }

    /// <summary>
    /// Start the debug server asynchronously
    /// </summary>
    public async Task StartAsync()
    {
        var builder = WebApplication.CreateBuilder();
        
        // Minimal configuration for debug server
        builder.Services.AddCors();
        builder.Logging.SetMinimumLevel(LogLevel.Warning);
        builder.WebHost.UseUrls($"http://localhost:{_port}");

        _app = builder.Build();

        // Enable CORS for local debugging
        _app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        // Root endpoint
        _app.MapGet("/", () => new
        {
            message = "Vulcan Learning Pit Debug Server",
            endpoints = new[]
            {
                "/health",
                "/state",
                "/state/{key}",
                "/session",
                "/approval",
                "/weaknesses"
            }
        });

        // Health check
        _app.MapGet("/health", () => new
        {
            status = "healthy",
            timestamp = DateTime.UtcNow,
            port = _port
        });

        // Get all state
        _app.MapGet("/state", () => Results.Json(State, new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        // Get specific state key
        _app.MapGet("/state/{key}", (string key) =>
        {
            if (State.TryGetValue(key, out var value))
            {
                return Results.Json(value, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            return Results.NotFound(new { error = $"State key '{key}' not found" });
        });

        // Session info endpoint
        _app.MapGet("/session", () =>
        {
            if (State.TryGetValue("currentSession", out var session))
            {
                return Results.Json(session, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            return Results.Json(new { message = "No active session" });
        });

        // Approval engine state
        _app.MapGet("/approval", () =>
        {
            if (State.TryGetValue("approvalEngine", out var approval))
            {
                return Results.Json(approval, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            return Results.Json(new { message = "No approval engine state" });
        });

        // Weaknesses tracker
        _app.MapGet("/weaknesses", () =>
        {
            if (State.TryGetValue("weaknessTracker", out var weaknesses))
            {
                return Results.Json(weaknesses, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            return Results.Json(new { message = "No weakness data" });
        });

        // Start the server in background
        _runTask = _app.RunAsync(_cts.Token);
        
        // Give it a moment to start
        await Task.Delay(100);
        
        Console.WriteLine($"Debug server started at http://localhost:{_port}");
    }

    /// <summary>
    /// Stop the debug server
    /// </summary>
    public async Task StopAsync()
    {
        if (_app != null)
        {
            _cts.Cancel();
            await (_runTask ?? Task.CompletedTask);
            await _app.DisposeAsync();
            Console.WriteLine("Debug server stopped");
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _app?.DisposeAsync().AsTask().Wait(TimeSpan.FromSeconds(5));
        _cts.Dispose();
    }
}
