using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Mp3MusicPlater
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new ()
    {
        private static T mConverter = null;

        public abstract object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        public  abstract object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider) => mConverter ?? (mConverter = new T());
    }
}
