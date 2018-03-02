using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        public static string SecMin(string[] a)
        {
            for(int i = 1; i < a.Length; i++)
            {
                int k = int.Parse(a[i - 1]);
                int l = int.Parse(a[i]);

                if (k > l)
                {
                    a[i - 1] = l.ToString();
                    a[i] = k.ToString(); 
                    i = 0;
                }
            }
            return a[1];
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\testmid\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();
            string[] ss = s.Split(' ');
            sr.Close();
            fs.Close();

            string sss = SecMin(ss);

            FileStream fs1 = new FileStream(@"C:\Users\Асер\Desktop\KBTU\testmid\output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(sss);
            sw.Close();
            fs1.Close();
        }
    }
}
