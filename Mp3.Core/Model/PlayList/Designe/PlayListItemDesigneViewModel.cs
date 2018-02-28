namespace Mp3.Core
{
    public class PlayListItemDesigneViewModel : PlayListitemControlViewModel
    {
        public static PlayListItemDesigneViewModel Instance => new PlayListItemDesigneViewModel();

        public PlayListItemDesigneViewModel()
        {
           Title = "Fear of the Dark";
           Band = "Iron Maiden";
           Album = "Fear of the Dark";
           PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg";
        }
    }
}
