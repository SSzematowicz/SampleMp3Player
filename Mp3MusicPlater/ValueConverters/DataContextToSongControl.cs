using Mp3.Core;
using System;

namespace Mp3MusicPlater
{
    class DataContextToSongControl : BaseValueConverter<DataContextToSongControl>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var data = (PlayListitemControlViewModel)value;
            
            if (data == null)
            {
                return null;
            }

            SongItemControl control = new SongItemControl
            {
                DataContext = data
            };

            return control;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }
}
