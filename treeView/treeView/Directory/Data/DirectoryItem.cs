
namespace treeView
{
    /// <summary>
    /// Information about a directory item such as a drive, file or folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// the type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        // for the name we can use the helper function
        /// <summary>
        /// The name of this Directory item
        /// </summary>
        // what we do here is to check if the directory item is a drive and if it is a drive we want to set it's name to 
        // the full path because the GetFilrFolderName Function returns blank when the path is a directory
        public string Name { get { return this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
        

    }
}
