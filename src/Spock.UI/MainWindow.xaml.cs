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
        // Show parent dashboard in a new window
        ParentDashboard.ShowDashboard(this);
    }
}