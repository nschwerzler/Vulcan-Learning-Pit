using System;
using System.Globalization;
using System.Windows.Data;
using Spock.Core.Models;

namespace Spock.UI.Converters;

/// <summary>
/// Converts Domain enum to colorful emoji prefix for visual categorization
/// </summary>
public class DomainToEmojiConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Domain domain)
        {
            return domain switch
            {
                Domain.Math => "🔢",
                Domain.Logic => "🧩",
                Domain.Reading => "📖",
                Domain.Science => "🔬",
                Domain.WinPants => "🤝",
                Domain.WashingtonHistory => "🏔️",
                Domain.Bitcoin => "₿",
                _ => "❓"
            };
        }
        return "❓";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
