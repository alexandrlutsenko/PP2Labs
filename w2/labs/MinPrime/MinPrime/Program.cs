using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPrime
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i*i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

        static void MnPrime()
        {
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\test\testminprime.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            string[] st = s.Split(' ');

            List<int> list = new List<int>();
            for (int i = 0; i < st.Length; i++)
            {
                if (IsPrime(int.Parse(st[i])) == true)
                {
                    list.Add(int.Parse(st[i]));
                }
            }

            int minp = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                int a = list[i];
                if (minp > a)
                {
                    minp = a;
                }
            }

            sr.Close();
            fs.Close();

            FileStream fs1 = new FileStream(@"C:\Users\Асер\Desktop\KBTU\test\minprimeanswer.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);

            sw.WriteLine(minp);

            sw.Close();
            fs1.Close();

        }


        static void Main(string[] args)
        {
            MnPrime();
        }
    }
}
