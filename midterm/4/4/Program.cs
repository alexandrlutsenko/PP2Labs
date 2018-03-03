using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void F1()
        {
            int a = 1;
            bool dir = true;

            while (true)
            {
                while (dir == true)
                {
                    F2(a);
                    if (a <= 3)
                    {
                        a++;
                    }

                    if (a > 3)
                    {
                        dir = false;
                    }
                }

                while (dir == false)
                {
                    F2(a);
                    if (a >= 1)
                    {
                        a--;
                    }

                    if (a < 1)
                    {
                        a = 1;
                        dir = true;
                    }
                }
            }
        }

        static void F2(int a)
        {
            if (a == 1)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.WriteLine("******\n******\n******");
                Thread.Sleep(500);
            }

            if (a == 2)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("******\n******\n******");
                Thread.Sleep(500);
            }

            if (a == 3)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.WriteLine("******\n******\n******");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("******\n******\n******");
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread = new Thread(F1);
            thread.Start();


            //Console.ReadKey();
        }
    }
}
