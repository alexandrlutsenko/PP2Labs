using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rec
    {
        public double wid, hei, per, area;

        public Rec()
        {
            wid = 2;
            hei = 1;
        }

        public Rec(int a, int b)
        {
            wid = a;
            hei = b;
        }

        public void FindPer()
        {
            per = 2 * (wid + hei);
        }

        public void FindArea()
        {
            area = wid * hei;
        }

        public override string ToString()
        {
            return "width = " + wid + "\nheight = " + hei + "\nperimetr = " + per + "\narea = " + area;
        }
    }
}
