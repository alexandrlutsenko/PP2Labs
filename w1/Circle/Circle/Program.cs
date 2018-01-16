using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Cir c = new Cir();

            c.FindArea();
            c.FindDiameter();
            c.FindCircumference();

            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
