using Mp3.Core;
using System;
using System.Windows;

namespace Mp3MusicPlater
{
    public class BollToBackgroundConverter : BaseValueConverter<BollToBackgroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => (bool)value ? Application.Current.FindResource("ForegroundLightBrush") : null;

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
