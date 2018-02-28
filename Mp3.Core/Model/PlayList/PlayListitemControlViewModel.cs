using System.Windows.Media.Imaging;

namespace Mp3.Core
{
    public class PlayListitemControlViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public string  Band { get; set; }

        public string  Album { get; set; }

        public double Dauration { get; set; }

        public string FilePath { get; set; }

        public string PicturePath { get; set; }

        public BitmapImage Cover { get; set; }
    }
}
