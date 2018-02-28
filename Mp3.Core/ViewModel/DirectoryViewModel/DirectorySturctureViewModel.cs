using System.Collections.ObjectModel;
using System.Linq; 


namespace Mp3.Core
{
    ///<summary>
    ///
    ///</summary>
    public class DirectorySturctureViewModel : BaseViewModel
    {
        #region Public property

        /// <summary>
        /// A list of all directories on this machine 
        /// </summary>
        public ObservableCollection<DirectoryItemInofoViewModel> Items { get; set; }

        #endregion

        #region Constructor

        ///<summary>
        ///Default constructor
        ///</summary>
        public DirectorySturctureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrivers();

            Items = new ObservableCollection<DirectoryItemInofoViewModel>
            (
                children.Select(drive => new DirectoryItemInofoViewModel(drive.FullPath, drive.Type))
            );
        }

        //public DirectorySturctureViewModel(string path)
        //{
        //    var children = DirectoryStructure.GetDirectoryContent(path);

        //    Items = new ObservableCollection<DirectoryItemInofoViewModel>
        //    (
        //        children.Select(it => new DirectoryItemInofoViewModel(it.FullPath, it.Type))
        //    );
        //}

        #endregion
    }
}
