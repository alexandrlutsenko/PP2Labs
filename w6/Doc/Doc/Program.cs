using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());

            Doc d = new Doc(n, a);



            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
