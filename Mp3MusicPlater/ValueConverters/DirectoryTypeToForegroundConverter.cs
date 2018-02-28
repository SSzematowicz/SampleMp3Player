using Mp3.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mp3MusicPlater
{
    ///<summary>
    ///Convert Directory Type to Icon
    ///</summary>
    public class DirectoryTypeToForegroundConverter : BaseValueConverter<DirectoryTypeToForegroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((DirectoryType)value)
            {
                case DirectoryType.Drive:
                    return Application.Current.FindResource("ForegroundHardDriveBrush");
                case DirectoryType.Folder:
                    return Application.Current.FindResource("ForegroundFolderBrush");
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
