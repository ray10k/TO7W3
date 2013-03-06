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
     * USE: static MedianCompare.percentage, after running to get the difference in percentage (original vs source)
     * OUTPUT: new Bitmap with black, grey or white pixels to show the difference
     *
     */
    class MedianCompare
    {
        public static int percentage;

        public System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap originalImage, System.Drawing.Bitmap sourceImage)
        {
            Bitmap newBitmap = new Bitmap(sourceImage.Width, sourceImage.Height);

            percentage = 0;
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
                        //get original data
                        byte oR = oRow[x * pixelSize];
                        byte oG = oRow[x * pixelSize + 1];
                        byte oB = oRow[x * pixelSize + 2];

                        //get source data
                        byte sR = sRow[x * pixelSize];
                        byte sG = sRow[x * pixelSize + 1];
                        byte sB = sRow[x * pixelSize + 2];

                        //compare here..

                        if(true){
                            changedPixels++;
                        }

                        byte nR = 0, nG = 0, nB = 0;

                        //make the unique pixel
                        nRow[x * pixelSize] = nR;
                        nRow[x * pixelSize + 1] = nG;
                        nRow[x * pixelSize + 2] = nB;

                    }
                }
            }

            int totalPixels = originalImage.Width * originalImage.Height;

            percentage = (changedPixels / totalPixels) * 100;

            return newBitmap;
        }
    }
}
