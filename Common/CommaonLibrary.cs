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
        static public BitmapImage ImageSelect()
        {
            BitmapImage image = null;
            try
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    image = new BitmapImage(new Uri(openFileDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
    }
}
