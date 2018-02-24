using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvenEven
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\test\EvenEven.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            string[] ss = s.Split(' ');
            string s2 = "";

            for (int i = 0; i < ss.Length/2; i++)
            {
                if (int.Parse(ss[2*i + 1]) % 2 == 0)
                {
                    s2 = s2 + " " + ss[2*i + 1];
                }
            }

            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"C:\Users\Асер\Desktop\KBTU\test\EvenEvenAns.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine(s2);

            sw.Close();
            fs2.Close();
        }
    }
}
