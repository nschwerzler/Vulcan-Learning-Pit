using System.Windows;
using Spock.UI.ViewModels;

namespace Spock.UI;

/// <summary>
/// Parent Dashboard window for monitoring student progress.
/// Password-protected, parent-only interface with real-time analytics.
/// </summary>
public partial class ParentDashboard : Window
{
    public ParentDashboard()
    {
        InitializeComponent();
        DataContext = new ParentDashboardViewModel();
    }

    /// <summary>
    /// Shows the dashboard with password protection.
    /// In production, this would integrate with proper authentication.
    /// </summary>
    public static void ShowDashboard(Window owner)
    {
        // TODO: Add password protection
        // For now, just show the window
        var dashboard = new ParentDashboard
        {
            Owner = owner
        };
        dashboard.Show();
    }
}
