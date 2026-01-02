using System.Windows;

namespace VulcanLearningPit.Views;

public partial class LeaderboardWindow : Window
{
    public LeaderboardWindow()
    {
        InitializeComponent();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
