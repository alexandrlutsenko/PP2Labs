using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Stud
    {
        public string name;
        public float gpa;

        public Stud()
        {
            name = "Student1";
            gpa = 4;
        }

        public Stud(string n, float w)
        {
            name = n;
            gpa = w;
        }

        public override string ToString()
        {
            return "Name " + name + "\nGPA " + gpa;
        }
    }
}
