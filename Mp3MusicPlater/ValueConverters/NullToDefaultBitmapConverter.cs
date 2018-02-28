using Mp3.Core;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mp3MusicPlater
{
    public class NullToDefaultBitmapConverter : BaseValueConverter<NullToDefaultBitmapConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (BitmapImage)value ?? new BitmapImage(new Uri("pack://application:,,,/Icon/compact-disc.png"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
