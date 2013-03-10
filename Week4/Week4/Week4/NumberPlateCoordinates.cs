using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    public class NumberPlateCoordinates
    {
        public Point LeftTop { get; set; }
        public Point RightTop { get; set; }
        public Point LeftBottom { get; set; }
        public Point RightBottom { get; set; }

        public string FileName { get; set; }
    }
}
