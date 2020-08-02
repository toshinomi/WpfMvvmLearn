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

        static public byte DoubleToByte(double _dValue)
        {
            byte nCnvValue = 0;

            if (_dValue > 255.0)
            {
                nCnvValue = 255;
            }
            else if (_dValue < 0)
            {
                nCnvValue = 0;
            }
            else
            {
                nCnvValue = (byte)_dValue;
            }

            return nCnvValue;
        }

        static public byte LongToByte(long _lValue)
        {
            byte nCnvValue = 0;

            if (_lValue > 255)
            {
                nCnvValue = 255;
            }
            else if (_lValue < 0)
            {
                nCnvValue = 0;
            }
            else
            {
                nCnvValue = (byte)_lValue;
            }

            return nCnvValue;
        }
    }
}
