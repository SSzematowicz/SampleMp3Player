using System;
using System.Windows;
using System.Windows.Controls;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Logika interakcji dla klasy DirectoryExplorerHoat.xaml
    /// </summary>
    public partial class DirectoryExplorerHost : UserControl
    {
        public UserControl CurrentControl
        {
            get { return (UserControl)GetValue(CurrentControlProperty); }
            set { SetValue(CurrentControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Control.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentControlProperty =
            DependencyProperty.Register("CurrentControl", 
                typeof(UserControl), typeof(DirectoryExplorerHost),
                new PropertyMetadata(CurrentControlPropertyChanged));

        private static void CurrentControlPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e) => ((d as DirectoryExplorerHost).ContentOne).Content = e.NewValue;

        public DirectoryExplorerHost()
        {
            InitializeComponent();
        }
    }
}
