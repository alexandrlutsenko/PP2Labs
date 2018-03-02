using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Асер\Desktop\KBTU\testmid\3");
            string s = "FIT";
            for (int i = 1; i <= 4; i++)
            {
                FileInfo fi = new FileInfo(@"C:\Users\Асер\Desktop\KBTU\testmid\3\"+i+".txt");
                FileStream fs = fi.OpenRead();
                StreamReader sr = new StreamReader(fs);
                string a = sr.ReadLine();
                if (a == s)
                {
                    Console.WriteLine(fi.Name);
                }
                sr.Close();
                fs.Close();
            }
            Console.ReadKey();
        }
    }
}
