using PropertyChanged;
using System;
using System.ComponentModel;

namespace treeView
{
    /// <summary>
    /// A base View Model that fires the property changed events as needed
    /// </summary>
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged 
    {
        /// <summary>
        /// the event that is fired when any child property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (Object sender, PropertyChangedEventArgs e ) => { };

        
    }
}
