using System.Windows;
using Spock.UI.ViewModels;

namespace Spock.UI;

/// <summary>
/// Parent Dashboard window for monitoring student progress.
/// Password-protected, parent-only interface with real-time analytics.
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
    /// Shows the dashboard with password protection.
    /// Prompts for parent authentication before displaying data.
    /// </summary>
    public static void ShowDashboard(Window owner)
    {
        // Show password dialog first
        var passwordDialog = new PasswordDialog
        {
            Owner = owner
        };

        var result = passwordDialog.ShowDialog();

        if (result == true && passwordDialog.IsAuthenticated)
        {
            // Password correct - show dashboard
            var dashboard = new ParentDashboard
            {
                Owner = owner
            };
            dashboard.Show();
        }
        // If password incorrect or cancelled, do nothing (dashboard won't open)
    }
}


