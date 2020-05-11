using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace treeView
{
    // a view model is essentially a class that inherites from the INotifyPropertChanged
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// the default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
