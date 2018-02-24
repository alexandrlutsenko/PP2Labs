using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthMin
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int a = int.Parse(Console.ReadLine());

            for (int i = 0; i < ss.Length - 1; i++)
            {
                if (int.Parse(ss[i]) > int.Parse(ss[i + 1]))
                {
                    ss[i] = ss[i + 1];
                    ss[i + 1] = ss[i];
                }
            }

            Console.WriteLine(ss[a]);

            Console.ReadKey();
        }
    }
}