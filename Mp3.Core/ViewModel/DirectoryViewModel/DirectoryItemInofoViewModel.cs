using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Mp3.Core
{
    ///<summary>
    /// View modtel class for all directory item
    ///</summary>
    public class DirectoryItemInofoViewModel : BaseViewModel
    {
        #region Public property
        /// <summary>
        /// the type of the item
        /// </summary>
        public DirectoryType Type { get; set; }

        /// <summary>
        /// full path of the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The Name of the item
        /// </summary>
        public string Name => Type == DirectoryType.Drive ? FullPath : DirectoryStructure.GetFolderFileName(FullPath);

        /// <summary>
        /// a list of the all Folder conteined inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemInofoViewModel> Children { get; set; }

        /// <summary>
        /// a list of the all Files conteined inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemInofoViewModel> Files { get; set; }

        /// <summary>
        /// Show if this item can be expanded
        /// </summary>
        public bool CanExpand => Type != DirectoryType.File;

        public bool IsExpanded
        {
            get => Children?.Count(f => f != null) > 0;
            set
            {
                if (value == true)
                {
                    Expand();
                }
                else
                    ClearChildren();
            }
        }

        /// <summary>
        /// Get or set information about that the item is selected 
        /// </summary>
        public bool IsSelected { get; set; } = false;

        #endregion

        #region Command

        /// <summary>
        /// the command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; private set; }

        /// <summary>
        /// the command to select this item
        /// </summary>
        public ICommand SelectCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constuctor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">the Type of this constructor</param>
        public DirectoryItemInofoViewModel(string fullPath, DirectoryType type)
        {
            ExpandCommand = new ReleyCommand(Expand);
            SelectCommand = new ReleyCommand(Select);

            FullPath = fullPath;
            Type = type;

            ClearChildren();

        }


        public DirectoryItemInofoViewModel()
        {
           
        }
        
        #endregion

        #region Private Helpers

        /// <summary>
        /// Remove all children form thiss item
        /// </summary>
        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemInofoViewModel>();
            Files = new ObservableCollection<DirectoryItemInofoViewModel>();

            if (Type != DirectoryType.File)
                Children.Add(null);
            
        }

        /// <summary>
        /// Expand this item and find all children
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryType.File)
                return;

           // Find all Folders
            var children = DirectoryStructure.GetDirectoryContentFolders(FullPath);
            Children = new ObservableCollection<DirectoryItemInofoViewModel>(
                                children.Select(content => new DirectoryItemInofoViewModel(content.FullPath, content.Type)));

            var list = DirectoryStructure.GetDirectoryContentFiles(FullPath);
            Files = new ObservableCollection<DirectoryItemInofoViewModel>(
                    list.Select(fil => new DirectoryItemInofoViewModel(fil.FullPath, DirectoryType.File))
                );

            IoC.Get<ApplicationViewModel>().ListViewViewModel = this;
        }

        /// <summary>
        /// Logic for selected and unselected item
        /// </summary>
        private void Select()
        {
            var selectedItems = Files.Where(sel => sel.IsSelected == true);

            if (selectedItems.Count() > 0)
            {
                IoC.Get<ApplicationViewModel>().PlaingList.Items = new System.Collections.Generic.List<PlayListitemControlViewModel>
                    (
                        selectedItems.Select(item => Mp3Data.GetData(item.FullPath))
                    );

                IoC.Get<ApplicationViewModel>().RessetAll();
            }
        }
        #endregion
    }
}
