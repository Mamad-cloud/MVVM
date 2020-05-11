using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace treeView
{
    // this is an attribute 
    [ValueConversion(typeof(string),typeof(BitmapImage))]


    // converts a string to a specific image type of a drive, file or folder
    public class HeaderToImageConverter : IValueConverter
    {
        // we create this static instance here to be able to find it easily in the xaml 
        public static HeaderToImageConverter instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the Full path
            var path = (string)value;

            // Get the file/folder name
            var name = DirectoryStructure.GetFileFolderName(path);

            // By default we pressume an image..
            var image = "Images/file.png";

            // if the name is blank, then we pressume it's a drive because files and folder names cannot be blank
            if (string.IsNullOrEmpty(name))
            {
                image = "Images/drive.png";
            }
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory)) // this is a very useful way of using file information
            {
                image = "Images/folder-closed.png";
            }
            // we need the pack://application:,,, to access the assets that are embeded inside the application
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
