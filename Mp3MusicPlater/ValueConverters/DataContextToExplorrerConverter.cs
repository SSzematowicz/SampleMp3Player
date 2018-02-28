using Mp3.Core;
using System;
using System.Windows;

namespace Mp3MusicPlater
{
    public class DataContextToExplorrerConverter : BaseValueConverter<DataContextToExplorrerConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ListViewControl control = new ListViewControl();
            if (value is DirectoryItemInofoViewModel vm)
                control.DataContext = vm;
            return control;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
