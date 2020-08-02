using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfMvvmLearn.Common
{
    static public class CommonHelper
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
            catch (Exception ex)
            {
                throw new Exception("Open File Error", ex);
            }

            return image;
        }

        static public BitmapImage ToBitmapImage(WriteableBitmap writeableBitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
                encoder.Save(stream);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }
    }
}
