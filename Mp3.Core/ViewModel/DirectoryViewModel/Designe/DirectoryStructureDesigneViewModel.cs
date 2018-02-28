namespace Mp3.Core
{
    ///<summary>
    ///
    ///</summary>
    public class DirectoryStructureDesigneViewModel : DirectorySturctureViewModel
    {
        public static DirectoryStructureDesigneViewModel Instance => new DirectoryStructureDesigneViewModel();
        #region Constructor

        ///<summary>
        ///Default constructor
        ///</summary>
        public DirectoryStructureDesigneViewModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<DirectoryItemInofoViewModel>
            {
                new DirectoryItemInofoViewModel
                {
                     FullPath= "C:\\",
                     Type= DirectoryType.Drive
                },
                new DirectoryItemInofoViewModel
                {
                     FullPath= "D:\\",
                     Type= DirectoryType.Drive
                },
                new DirectoryItemInofoViewModel
                {
                     FullPath= "E:\\",
                     Type= DirectoryType.Drive
                }               
            };
        }

        #endregion
    }
}
