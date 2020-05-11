using System.Collections.ObjectModel;
using System.ComponentModel;

namespace treeView
{
    /// <summary>
    /// a view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel 
    {
        /// <summary>
        /// the type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// the full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of the directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        // a self occuring list. this is kind of a view model kind of list because the observable collection inherits the two 
        // INotifyCollectionChanged, INotifyPropertyChanged interfaces which fire the property changed events when a property changes
        // or when an item is added or removed from the collection
        /// <summary>
        /// a list of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// indicates if this item can be expanded 
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }


    }
}
