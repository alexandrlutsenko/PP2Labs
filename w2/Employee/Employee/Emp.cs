using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Emp
    {
        public string name;
        public float wage;

        public Emp()
        {
            name = "Employee1";
            wage = 100;
        }

        public Emp(string n, float w)
        {
            name = n;
            wage = w;
        }

        public override string ToString()
        {
            return "Name " + name + "\nWage " + wage;
        }
    }
}
