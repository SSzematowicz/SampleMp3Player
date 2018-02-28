namespace Mp3.Core
{
    ///<summary>
    ///
    ///</summary>
    public class DirectoryItemInofoDesigneViewModel : DirectoryItemInofoViewModel
    {
        #region Singleton
        public static DirectoryItemInofoDesigneViewModel Instance => new DirectoryItemInofoDesigneViewModel();
        #endregion

        #region Constructors
        public DirectoryItemInofoDesigneViewModel(string fullPath, DirectoryType type) : base(fullPath, type)
        {

        }

        public DirectoryItemInofoDesigneViewModel()
        {
            FullPath = "D:";
            Type = DirectoryType.Drive;
        }    
        #endregion
    }
}
