using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace treeView
{
    // what it says under here is why we put the helper functions in here
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    // this is where the real data logic is gonna happen
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns>returns a List of directory items </returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // the Select method projects each element of a sequence into a new form and what it does here is that it takes each of
            // the logical drives which are strings and creates an instance of the DirectoryItem class out of them and then sets the 
            // full path property of the DirectoryItem to the string that we get from the GetLogicalDrives method and sets the Type 
            // as a drive
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem {FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">the full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            #region Get Directories
            // Create empty list 
            var items = new List<DirectoryItem>();
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem {Type = DirectoryItemType.Folder, FullPath = dir}));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            #endregion

            #region Get Files

            // Try and get Files from the folder
            // ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(f => new DirectoryItem {FullPath = f, Type = DirectoryItemType.File}));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
            return items;

        }

        #region Get File or Folder Name
        /// <summary>
        /// Gets directory name from a full path string 
        /// </summary>
        /// <param name="path"> the full path </param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // if we have no path , return empty
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            // turn all slashes into backslashes
            var normalizedPath = path.Replace('/', '\\');
            // find the last back slash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');
            // if we don't have a back-slash, return the path itself
            if (lastIndex <= 0) // when there is no backslash in the path the last index is going to be  -1 ==> i think so at least
            {
                return path;
            }
            // return after the last backslash
            return String.Format(path.Substring(lastIndex + 1));
        }
        #endregion
    }
}
