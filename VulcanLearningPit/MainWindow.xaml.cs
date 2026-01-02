using System.Windows;
using System.Windows.Controls;
using VulcanLearningPit.ViewModels;

namespace VulcanLearningPit;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();

        // Handle radio button selection
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Find all radio buttons and attach event handlers
        AddRadioButtonHandlers(this);
    }

    private void AddRadioButtonHandlers(DependencyObject parent)
    {
        int childCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childCount; i++)
        {
            var child = System.Windows.Media.VisualTreeHelper.GetChild(parent, i);
            if (child is RadioButton radioButton)
            {
                radioButton.Checked += RadioButton_Checked;
            }
            AddRadioButtonHandlers(child);
        }
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton rb && DataContext is MainViewModel vm)
        {
            vm.SelectedAnswer = rb.Content.ToString() ?? string.Empty;
        }
    }
}