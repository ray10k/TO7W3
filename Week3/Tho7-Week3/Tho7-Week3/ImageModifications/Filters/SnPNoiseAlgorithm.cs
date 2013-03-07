using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tho7_Week3.ImageModifications.Filters
{
	class SnPNoiseAlgorithm : VisionAlgorithm
	{
		private int _upper, _lower;

		public SnPNoiseAlgorithm(String name,int amount = 20)
			: base(name)
		{
			this._lower = amount/2;
			this._upper = 100 - (amount / 2);
		}

		public override Bitmap DoAlgorithm(Bitmap sourceImage)
		{
			BitmapData rawData = sourceImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
				System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] rawBytes = new byte[rawData.Stride*rawData.Height];
			System.Runtime.InteropServices.Marshal.Copy(rawData.Scan0, rawBytes, 0, rawBytes.Length);
			sourceImage.UnlockBits(rawData);

			byte[] newBytes = DoAlgorithm(ref rawBytes);

			Bitmap retval = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format24bppRgb);
			BitmapData newData = retval.LockBits(new Rectangle(0, 0, retval.Width, retval.Height),
				ImageLockMode.ReadWrite, retval.PixelFormat);

			System.Runtime.InteropServices.Marshal.Copy(newBytes, 0, newData.Scan0, newBytes.Length);
			retval.UnlockBits(newData);

			return retval;

		}

		public byte[] DoAlgorithm(ref byte[] sourceData)
		{
			Random rand = new Random();
			byte[] newData = new byte[sourceData.Length];

			for (int i = 0; i < sourceData.Length; i += 3)
			{
				int current = rand.Next(100);
				if (current <= _lower)
				{
					newData[i] = 0;
					newData[i + 1] = 0;
					newData[i + 2] = 0;
				}
				else if (current >= _upper)
				{
					newData[i] = 0xff;
					newData[i + 1] = 0xff;
					newData[i + 2] = 0xff;
				}
				else
				{
					newData[i] = sourceData[i];
					newData[i + 1] = sourceData[i + 1];
					newData[i + 2] = sourceData[i + 2];
				}
			}
			return newData;
		}
	}
}
