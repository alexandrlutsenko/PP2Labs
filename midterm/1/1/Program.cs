using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Topow(int n)
            {
                int d = 1;
                for (int i = 1; i <= n; i++)
                {
                    d = d * 2;
                }
                return d;
            }
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = Topow(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
