
namespace Mp3.Core
{
    /// <summary>
    /// The object conteint information about directory on the computer
    /// </summary>
    public class DirectoryItemInfo
    {
        /// <summary>
        /// the type of this directory item
        /// </summary>
        public DirectoryType Type { get; set; }

        /// <summary>
        /// the absolute path of this directory item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of this directory item
        /// </summary>
        public string Name { get; set; }
    }
}
