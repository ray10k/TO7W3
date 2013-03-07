using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tho7_Week3.ImageModifications
{
    /* Jonathan Smit 
     * USE: static MedianCompare.percentageChanged, after running to get the difference in percentage (original vs source)
     * USE: static pixelsChanged, after running to get the amount of changed pixels.
     * OUTPUT: bitmap with black, grey or white pixels to show the difference
     * OUTPUT: byte[] with black, grey or white pixels to show the difference
     */
    class MedianCompare
    {
        public static double percentageChanged = 0.0;
        public static int pixelsChanged = 0;
        public static double percentageCorrect = 0.0;
        public static int pixelsCorrect = 0;

        public static byte[] DoAlgorithm(ref byte[] originalImage, ref byte[] sourceImage)
        {
            //counter to keep track of changed pixels
            int changedPixels = 0;

            byte[] retVal = new byte[originalImage.Length];

            for (int y = 0; y < originalImage.Length; y+=3)
            {
                int avg1 = (originalImage[y] + originalImage[y + 1] + originalImage[y + 2]) / 3;
                int avg2 = (sourceImage[y] + sourceImage[y + 1] + sourceImage[y + 2]) / 3;
                byte val = (byte)(((avg1 - avg2) / 2) + 127);

                //if the original rgb-values are not equals to sourceImage 
                //increment changedPixels
                if ( (originalImage[y] != sourceImage[y]) || (originalImage[y + 1] != sourceImage[y + 1]) || (originalImage[y + 2] != sourceImage[y + 2]) )
                {
                    changedPixels++;
                }

                //make the unique 'pixel'
                retVal[y] = val;
                retVal[y+ 1] = val;
                retVal[y+ 2] = val;
                
            }

            int totalPixels = originalImage.Length / 3;

            percentageChanged = (changedPixels / totalPixels) * 100;
            pixelsChanged = changedPixels;

            return retVal;
        }

        public static System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap originalImage, System.Drawing.Bitmap sourceImage)
        {
            Bitmap newBitmap = new Bitmap(sourceImage.Width, sourceImage.Height);

            int changedPixels = 0;

            unsafe
            {
                //lock the original bitmap in memory
                BitmapData originalData = originalImage.LockBits(
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //lock the new bitmap in memory
                BitmapData sourceData = sourceImage.LockBits(
                   new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                   ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //lock the new bitmap in memory
                BitmapData newData = newBitmap.LockBits(
                   new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                   ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                //set the number of bytes per pixel
                int pixelSize = 3;

                for (int y = 0; y < sourceImage.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

                    //get the data from the edited image
                    byte* sRow = (byte*)sourceData.Scan0 + (y * sourceData.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

                    for (int x = 0; x < sourceImage.Width; x++)
                    {
                        //compare here..
                        //procedure:
                        //two pixels, get the average of both pixels
                        //substract pixel one from pixel two, the result is a value some between -255 - 255
                        //divide by 2, then result is a value between -127 - 127
                        //add 127 and the new result is a value between 0 - 254
                        //this value is the new greyvalue

                        int avg1 = (oRow[x * pixelSize] + oRow[x * pixelSize + 1] + oRow[x * pixelSize + 2]) / 3;
                        int avg2 = (sRow[x * pixelSize] + sRow[x * pixelSize + 1] + sRow[x * pixelSize + 2]) / 3;
                        byte val = (byte)(((avg1 - avg2) / 2) + 127);

                        //als de originele rgb-waarden niet gelijk zijn aan de source
                        //optellen van changedPixels
                        if ( (oRow[x * pixelSize] != sRow[x * pixelSize]) || (oRow[x * pixelSize + 1]  != sRow[x * pixelSize + 1]) || (oRow[x * pixelSize + 2] != sRow[x * pixelSize + 2]) )
                        {
                            changedPixels++;
                        }

                        //make the unique pixel
                        nRow[x * pixelSize] = val;
                        nRow[x * pixelSize + 1] = val;
                        nRow[x * pixelSize + 2] = val;

                    }
                }

                originalImage.UnlockBits(originalData);
                sourceImage.UnlockBits(sourceData);
                newBitmap.UnlockBits(newData);
            }

            

            int totalPixels = originalImage.Width * originalImage.Height;

            percentageChanged = ((double)changedPixels / totalPixels) * 100.0;
            pixelsChanged = changedPixels;

            percentageCorrect = 100.0 - percentageChanged;
            pixelsCorrect = totalPixels - pixelsChanged;


            return newBitmap;
        }
    }
}
