using System.Windows;
using System.Windows.Input;

namespace Spock.UI;

/// <summary>
/// Password dialog for Parent Dashboard authentication.
/// Implements simple password protection to keep dashboard parent-only.
/// </summary>
public partial class PasswordDialog : Window
{
    // TODO: In production, store hashed password in secure configuration
    // For MVP, using simple hardcoded password
    private const string DEFAULT_PASSWORD = "parent123";

    public bool IsAuthenticated { get; private set; }

    public PasswordDialog()
    {
        InitializeComponent();
        PasswordBox.Focus();
    }

    private void UnlockButton_Click(object sender, RoutedEventArgs e)
    {
        ValidatePassword();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        IsAuthenticated = false;
        DialogResult = false;
        Close();
    }

    private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ValidatePassword();
        }
        else if (e.Key == Key.Escape)
        {
            CancelButton_Click(sender, e);
        }
    }

    private void ValidatePassword()
    {
        var enteredPassword = PasswordBox.Password;

        // TODO: In production, validate against securely stored hash
        if (enteredPassword == DEFAULT_PASSWORD)
        {
            IsAuthenticated = true;
            DialogResult = true;
            Close();
        }
        else
        {
            ErrorMessage.Visibility = Visibility.Visible;
            PasswordBox.Clear();
            PasswordBox.Focus();
        }
    }
}
