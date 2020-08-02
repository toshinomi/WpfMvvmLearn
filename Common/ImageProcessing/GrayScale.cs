using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using static WpfMvvmLearn.Common.CommonInfomation;

namespace WpfMvvmLearn.Common.ImageProcessing
{
    public class GrayScale
    {
        public GrayScale()
        {
        }

        ~GrayScale()
        {
        }

        public bool ImageProcessing(ref WriteableBitmap writeableBitmap)
        {
            bool result = true;

            int widthSize = writeableBitmap.PixelWidth;
            int heightSize = writeableBitmap.PixelHeight;

            writeableBitmap.Lock();

            int indexWidth;
            int indexHeight;

            unsafe
            {
                for (indexHeight = 0; indexHeight < heightSize; indexHeight++)
                {
                    for (indexWidth = 0; indexWidth < widthSize; indexWidth++)
                    {
                        byte* pixel = (byte*)writeableBitmap.BackBuffer + indexHeight * writeableBitmap.BackBufferStride + indexWidth * 4;
                        byte grayScale = (byte)((pixel[(int)Pixel.B] + pixel[(int)Pixel.G] + pixel[(int)Pixel.R]) / 3);

                        pixel[(int)Pixel.B] = grayScale;
                        pixel[(int)Pixel.G] = grayScale;
                        pixel[(int)Pixel.R] = grayScale;
                    }
                }
                writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, widthSize, heightSize));
                writeableBitmap.Unlock();
                writeableBitmap.Freeze();
            }

            return result;
        }
    }
}
