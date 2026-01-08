using System;
using System.Windows;
using Spock.UI.ViewModels;

namespace Spock.UI;

/// <summary>
/// Parent Dashboard window for monitoring student progress.
/// Parent-only interface with real-time analytics.
/// Implements psychological safety: data for support, not judgment.
/// </summary>
public partial class ParentDashboard : Window
{
    public ParentDashboard()
    {
        try
        {
            App.Log("[ParentDashboard] Constructor: Starting...");
            
            App.Log("[ParentDashboard] Calling InitializeComponent()...");
            InitializeComponent();
            App.Log("[ParentDashboard] InitializeComponent() completed");
            
            App.Log("[ParentDashboard] Creating ParentDashboardViewModel...");
            DataContext = new ParentDashboardViewModel();
            App.Log("[ParentDashboard] DataContext set successfully");
            
            App.Log("[ParentDashboard] Constructor completed successfully");
        }
        catch (Exception ex)
        {
            App.Log($"[ParentDashboard] ERROR in Constructor: {ex.GetType().Name}");
            App.Log($"[ParentDashboard] Message: {ex.Message}");
            App.Log($"[ParentDashboard] StackTrace: {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                App.Log($"[ParentDashboard] InnerException: {ex.InnerException.Message}");
                App.Log($"[ParentDashboard] InnerException StackTrace: {ex.InnerException.StackTrace}");
            }
            throw;
        }
    }

    /// <summary>
    /// Shows the dashboard directly without password protection.
    /// Opens parent-only interface with real-time analytics.
    /// </summary>
    public static void ShowDashboard(Window owner)
    {
        try
        {
            App.Log("[ParentDashboard] ShowDashboard: Creating new dashboard...");
            
            // Open dashboard directly
            var dashboard = new ParentDashboard
            {
                Owner = owner
            };
            
            App.Log("[ParentDashboard] ShowDashboard: Calling Show()...");
            dashboard.Show();
            App.Log("[ParentDashboard] ShowDashboard: Show() completed");
        }
        catch (Exception ex)
        {
            App.Log($"[ParentDashboard] ERROR in ShowDashboard: {ex.GetType().Name}");
            App.Log($"[ParentDashboard] Message: {ex.Message}");
            App.Log($"[ParentDashboard] StackTrace: {ex.StackTrace}");
            throw;
        }
    }
}


