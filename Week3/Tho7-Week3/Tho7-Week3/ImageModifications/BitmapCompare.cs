using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tho7_Week3.ImageModifications
{
    /// <author>
    /// Erwim Bonnet
    /// </author>
    public class BitmapCompare
    {
        private static BitmapCompare comp;

        private BitmapCompare() { }

        public static BitmapCompare BmpCompare
        {
            get
            {
                if (comp == null)
                    comp = new BitmapCompare();
                return comp;
            }
        }

        public int GetEqualPixelCount(Bitmap b1, Bitmap b2)
        {
            int equalPixels = 0;

            BitmapData d1 = b1.LockBits(new Rectangle(0, 0, b1.Width, b1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData d2 = b2.LockBits(new Rectangle(0, 0, b2.Width, b2.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            if (b1.Width != b2.Width || b1.Height != b2.Height) return -1;

            unsafe
            {
                byte* b1Scan0 = (byte*)d1.Scan0.ToPointer();
                byte* b2Scan0 = (byte*)d2.Scan0.ToPointer();

                bool pixIsEqual = false;

                for (int y = 0; y < b1.Height; y++)
                {
                    for (int x = 0; x < b1.Width; x++)
                    {
                        byte* p1 = b1Scan0 + y * d1.Stride + x * 3;
                        byte* p2 = b2Scan0 + y * d2.Stride + x * 3;

                        pixIsEqual = false;
                        if (p1[0] == p2[0])
                        {
                            if (p1[1] == p2[1])
                            {
                                if (p1[2] == p2[2])
                                    pixIsEqual = true;
                            }
                        }
                        if (pixIsEqual)
                            equalPixels++;                        

                    }
                }
            }
            b1.UnlockBits(d1);
            b2.UnlockBits(d2);
            return equalPixels;
        }
    }
}
