using System;
using System.Windows;

namespace Mp3MusicPlater
{
    public class ListPosisionToBuckgroundConverter : BaseValueConverter<ListPosisionToBuckgroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var lp = int.Parse((string)value);

            return (lp % 2 == 0) ? Application.Current.FindResource("ForegroundLightBrush") : Application.Current.FindResource("ForegroundSmokeBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
