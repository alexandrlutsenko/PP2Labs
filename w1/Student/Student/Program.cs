using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Stud s1 = new Stud();
            Stud s2 = new Stud("Student2", 3);

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Console.ReadKey();
        }
    }
}
