using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using static WpfMvvmLearn.Common.CommonInfomation;

namespace WpfMvvmLearn.Common.ImageProcessing
{
    public class EdgeDetection
    {
        public EdgeDetection()
        {
        }

        ~EdgeDetection()
        {
        }

        public bool ImageProcessing(ref WriteableBitmap writeableBitmap)
        {
            bool result = true;

            short[,] mask =
            {
            {1,  1, 1},
            {1, -8, 1},
            {1,  1, 1}
        };
            int widthSize = writeableBitmap.PixelWidth;
            int heightSize = writeableBitmap.PixelHeight;
            int maskSize = mask.GetLength(0);

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

                        long totalBlue = 0;
                        long totalGreen = 0;
                        long totalRed = 0;
                        int indexWidthMask;
                        int indexHightMask;

                        for (indexHightMask = 0; indexHightMask < maskSize; indexHightMask++)
                        {
                            for (indexWidthMask = 0; indexWidthMask < maskSize; indexWidthMask++)
                            {
                                if (indexWidth + indexWidthMask > 0 &&
                                    indexWidth + indexWidthMask < widthSize &&
                                    indexHeight + indexHightMask > 0 &&
                                    indexHeight + indexHightMask < heightSize)
                                {
                                    byte* pixelMaskArea = (byte*)writeableBitmap.BackBuffer + (indexHeight + indexHightMask) * writeableBitmap.BackBufferStride + (indexWidth + indexWidthMask) * 4;

                                    totalBlue += pixelMaskArea[(int)Pixel.B] * mask[indexWidthMask, indexHightMask];
                                    totalGreen += pixelMaskArea[(int)Pixel.G] * mask[indexWidthMask, indexHightMask];
                                    totalRed += pixelMaskArea[(int)Pixel.R] * mask[indexWidthMask, indexHightMask];
                                }
                            }
                        }
                        pixel[(int)Pixel.B] = CommonHelper.LongToByte(totalBlue);
                        pixel[(int)Pixel.G] = CommonHelper.LongToByte(totalGreen);
                        pixel[(int)Pixel.R] = CommonHelper.LongToByte(totalRed);
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
