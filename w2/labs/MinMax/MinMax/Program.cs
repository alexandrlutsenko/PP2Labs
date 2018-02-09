using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class Program
    {

        static void f()
        {
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\test\testminmax.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            string[] st = s.Split(' ');
            int min = int.Parse(st[0]);
            int max = int.Parse(st[0]);

            for (int i = 0; i < st.Length; i++)
            {
                int a = int.Parse(st[i]);
                if (min > a)
                {
                    min = a;
                }
                if (max < a)
                {
                    max = a;
                }
            }
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);

            sr.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            f();

            Console.ReadKey();
        }
    }
}
