using Mp3.Core;
using System;
using System.Windows;

namespace Mp3MusicPlater
{
    public class BollToVisableConverter : BaseValueConverter<BollToVisableConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            else
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
