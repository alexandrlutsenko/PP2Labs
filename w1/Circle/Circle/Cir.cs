using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Cir
    {
        double rad, diam, circ, area;

        public Cir()
        {
            rad = 1;
        }

        public Cir(int r)
        {
            rad = r;
        }

        public void FindArea()
        {
            area = Math.PI * rad * rad;
        }

        public void FindDiameter()
        {
            diam = 2 * rad;
        }

        public void FindCircumference()
        {
            circ = 2 * Math.PI * rad;
        }

        public override string ToString()
        {
            return "radius = " + rad + "\narea = " + area + "\ndiameter = " + diam + "\ncircumference = " + circ;
        }
    }
}
