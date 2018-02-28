using Mp3.Core;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Interaction logic for MusicPanel.xaml
    /// </summary>
    public partial class MusicPanel
    {
        public MusicPanel()
        {
            InitializeComponent();
            this.DataContext = new MusicPanelViewModel();
        }
    }
}
