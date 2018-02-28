using System.Windows.Controls;
using Mp3.Core;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Logika interakcji dla klasy NewSongExplorerControl.xaml
    /// </summary>
    public partial class NewSongExplorerControl : UserControl
    {
        public NewSongExplorerControl()
        {
            InitializeComponent();

            this.DataContext = new DirectorySturctureViewModel();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
