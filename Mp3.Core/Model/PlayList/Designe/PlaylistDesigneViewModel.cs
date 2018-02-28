using System.Collections.Generic;

namespace Mp3.Core
{
    public class PlaylistDesigneViewModel : PlayListViewModel
    {
        public static PlaylistDesigneViewModel Instance => new PlaylistDesigneViewModel();

        public PlaylistDesigneViewModel()
        {
            Items = new List<PlayListitemControlViewModel>
            {
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "Fear of the Dark",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"

                },               
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "Be quiek",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"
                },              
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "666 the number",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"
                },                
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "Love",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"
                },               
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "The Troper",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"
                },
                new PlayListitemControlViewModel
                {
                    Band = "Iron Maiden",
                    Title = "Two minutes to midnaight",
                    Album = "Fear of the Dark",
                    PicturePath = @"D:\Programowanie\WPF-New\Moje\Mp3MusicPlater\Mp3.Core\Model\PlayList\Designe\Iron_Maiden_-_Fear_Of_The_Dark.jpg"
                },
            };
        }
    }
}
