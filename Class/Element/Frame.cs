using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp
{
    class Frame
    {
        public XYZ start;
        public XYZ end;

        public Frame(XYZ start, XYZ end)
        {
            this.start = start;
            this.end = end;
        }

        public Frame(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            start = new XYZ(x1, y1, z1);
            end = new XYZ(x2, y2, z2);
        }
    }
}
