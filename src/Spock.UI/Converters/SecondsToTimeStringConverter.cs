using System;
using System.Globalization;
using System.Windows.Data;

namespace Spock.UI.Converters;

/// <summary>
/// Converts seconds (int) to human-readable time format without emoji.
/// Examples: "15s", "2m 15s", "1h 3m", "2h 15m 30s"
/// Used for Game Token display as specified in plan.md.
/// </summary>
public class SecondsToTimeStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int totalSeconds || totalSeconds < 0)
            return "0s";
        
        // Calculate hours, minutes, and seconds
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;
        
        // Build format string based on magnitude
        if (hours > 0)
        {
            // Show hours and minutes only for 1+ hour
            if (minutes > 0)
                return $"{hours}h {minutes}m";
            return $"{hours}h";
        }
        
        if (minutes > 0)
        {
            // Show minutes and seconds for less than 1 hour
            if (seconds > 0)
                return $"{minutes}m {seconds}s";
            return $"{minutes}m";
        }
        
        // Show seconds only for less than 1 minute
        return $"{seconds}s";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException("ConvertBack not supported for SecondsToTimeStringConverter");
    }
}
