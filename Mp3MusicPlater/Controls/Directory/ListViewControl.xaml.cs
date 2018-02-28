using Mp3.Core;
using System.Windows.Controls;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Logika interakcji dla klasy ListViewControl.xaml
    /// </summary>
    public partial class ListViewControl : UserControl
    {
        public ListViewControl()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
