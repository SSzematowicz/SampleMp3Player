using Mp3.Core;
using System;
using System.Windows;

namespace Mp3MusicPlater
{
    public class PlayListItemToTimeConverter : BaseValueConverter<PlayListItemToTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

                TimeSpan time = TimeSpan.FromSeconds((double)value);
                return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
