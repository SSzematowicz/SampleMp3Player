using Mp3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Mp3MusicPlater
{
    public class StringToRGBConverter : BaseValueConverter<StringToRGBConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Color = (string)value;
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#" + Color));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
