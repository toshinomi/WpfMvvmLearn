using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfMvvmLearn.Common
{
    public class CommaonLibrary
    {
        static public BitmapImage ImageSelect(BitmapImage image)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "JPG|*.jpg|PNG|*.png",
                    Title = "Open the file"
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    image = new BitmapImage(new Uri(openFileDialog.FileName));
                }
            }
            catch (Exception)
            {
            }

            return image;
        }
    }
}
