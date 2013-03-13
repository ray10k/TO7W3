using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Week4.Algorithms
{
    public abstract class VisionAlgorithm
    {
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = Name; }
        }

        public VisionAlgorithm(String name)
        {
            this._name = name;
        }

        public abstract NumberPlateCoordinates DoAlgorithm(Bitmap sourceImage);
    }
}
