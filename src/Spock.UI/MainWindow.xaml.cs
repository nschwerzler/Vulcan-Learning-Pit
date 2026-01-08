using System;
using System.Windows;
using Spock.UI.ViewModels;

namespace Spock.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize ViewModel
        DataContext = new MainViewModel();
    }

    private void OpenDashboard_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            App.Log("[MainWindow] OpenDashboard_Click: Starting...");
            
            // Show parent dashboard in a new window
            App.Log("[MainWindow] Calling ParentDashboard.ShowDashboard...");
            ParentDashboard.ShowDashboard(this);
            
            App.Log("[MainWindow] ParentDashboard.ShowDashboard completed successfully");
        }
        catch (Exception ex)
        {
            App.Log($"[MainWindow] ERROR in OpenDashboard_Click: {ex.GetType().Name}");
            App.Log($"[MainWindow] Message: {ex.Message}");
            App.Log($"[MainWindow] StackTrace: {ex.StackTrace}");
            
            MessageBox.Show(
                $"Failed to open Parent Dashboard:\n\n{ex.Message}\n\nSee log file for details.",
                "Dashboard Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            throw;
        }
    }
}