using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Spock.Core.Models;

namespace Spock.UI.Converters;

/// <summary>
/// Converts Domain enum to color brush for left border visual indicator
/// </summary>
public class DomainToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Domain domain)
        {
            return domain switch
            {
                Domain.Math => new SolidColorBrush(Color.FromRgb(74, 158, 255)),     // Blue #4A9EFF
                Domain.Logic => new SolidColorBrush(Color.FromRgb(186, 85, 211)),    // Purple #BA55D3
                Domain.Reading => new SolidColorBrush(Color.FromRgb(255, 184, 74)),  // Orange #FFB84A
                Domain.Science => new SolidColorBrush(Color.FromRgb(74, 255, 136)),  // Green #4AFF88
                Domain.WinPants => new SolidColorBrush(Color.FromRgb(255, 105, 180)), // Pink #FF69B4
                Domain.WashingtonHistory => new SolidColorBrush(Color.FromRgb(139, 69, 19)), // Brown #8B4513
                Domain.Bitcoin => new SolidColorBrush(Color.FromRgb(247, 147, 26)),  // Bitcoin Orange #F7931A
                _ => new SolidColorBrush(Color.FromRgb(136, 136, 136))              // Gray #888
            };
        }
        return new SolidColorBrush(Color.FromRgb(136, 136, 136));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
