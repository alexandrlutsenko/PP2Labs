using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            string[] ss1 = s1.Split(' ');
            string[] ss2 = s2.Split(' ');

            int a = int.Parse(ss1[0]);
            int b = int.Parse(ss1[1]);
            int c = int.Parse(ss2[0]);
            int d = int.Parse(ss2[1]);

            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);

            Complex sum = c1 + c2;

            Console.WriteLine("Sum = " + sum);

            Console.ReadKey();
        }
    }
}
