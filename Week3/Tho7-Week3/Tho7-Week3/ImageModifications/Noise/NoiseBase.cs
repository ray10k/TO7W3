using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tho7_Week3.ImageModifications.Noise
{
    /// <summary>
    /// Base class for Noise
    /// </summary>
    /// <author>
    /// Erwin Bonnet
    /// </author>
    public abstract class NoiseBase
    {
        private string _name;
        private int _percentage;

        public string Name
        {
            get { return _name; }
        }

        public int Percentage
        {
            get { return _percentage; }
        }

        public NoiseBase(string name, int percentage)
        {
            _name = name;
            _percentage = percentage;
        }

        public abstract Bitmap MakeNoise(Bitmap sourceImage);
    }
}
