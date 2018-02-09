using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a, b;

        public Complex() { }

        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        public static Complex operator +(Complex x, Complex y)
        {
            Complex res = new Complex();

            res.a = x.a * y.b + y.a * x.b;
            res.b = x.b * y.b;

            int c = GCD(res.a, res.b);

            res.a = res.a / c;
            res.b = res.b / c; 

            return res;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", a, b);
        }
    }
}
