using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc
{
    class Doc
    {
        public string name;
        public int age;

        public Doc() { }

        public Doc(string n, int a)
        {
            name = n;
            age = a;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string ab)
        {
            name = ab;
        }

        public override string ToString()
        {
            return "Doc's name is " + name + "\nDoc's " + age + " years old";
        }
    }
}
