using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Emp e1 = new Emp();
            Emp e2 = new Emp("Emloyee2", 200);

            Console.WriteLine(e1);
            Console.WriteLine(e2); 

            Console.ReadKey();
        }
    }
}
