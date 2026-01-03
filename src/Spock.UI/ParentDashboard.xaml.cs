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
        InitializeComponent();
        DataContext = new ParentDashboardViewModel();
    }

    /// <summary>
    /// Shows the dashboard directly without password protection.
    /// Opens parent-only interface with real-time analytics.
    /// </summary>
    public static void ShowDashboard(Window owner)
    {
        // Open dashboard directly
        var dashboard = new ParentDashboard
        {
            Owner = owner
        };
        dashboard.Show();
    }
}


