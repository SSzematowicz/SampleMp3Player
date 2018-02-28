using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mp3.Core
{
    ///<summary>
    ///the class wich get and contein information abaut file structure on this machine
    ///</summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Get all logical drivers on the machine
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItemInfo> GetLogicalDrivers()
        {
            return Directory.GetLogicalDrives().Select
                (drive => new DirectoryItemInfo { FullPath = drive, Type = DirectoryType.Drive }).ToList();
        }

        /// <summary>
        /// Get all folder and file form directory 
        /// </summary>
        /// <param name="fullPath">Ful Path of the directory</param>
        /// <returns></returns>
        public static List<DirectoryItemInfo> GetDirectoryContentFolders(string fullPath)
        {
            var Items = new List<DirectoryItemInfo>();

            #region Folders
            try
            {
                var folders = Directory.GetDirectories(fullPath);
                if (folders.Length > 0)
                {
                    Items.AddRange(folders.Select(dir => new DirectoryItemInfo { FullPath = dir, Type = DirectoryType.Folder }));
                }
            }
            catch { }
            #endregion



            return Items;
        }

        public static List<DirectoryItemInfo> GetDirectoryContentFiles(string fullPath)
        {
            var Items = new List<DirectoryItemInfo>();
            #region Files
            try
            {
                var files = Directory.GetFiles(fullPath);
                if (files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.EndsWith(".mp3", System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            Items.Add(new DirectoryItemInfo { FullPath = file, Type = DirectoryType.File });
                        }
                    }
                }
            }
            catch { }
            #endregion
            return Items;
        }

        /// <summary>
        /// Get Name of the file or folder
        /// </summary>
        /// <param name="path">path of the file or folder</param>
        /// <returns>short name of the folder or file</returns>
        public static string GetFolderFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizePath = path.Replace('/', '\\');

            var lastIndex = normalizePath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            return path.Substring(++lastIndex);
        }
    }
}
