using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program
    {
        static void showFolderContent(DirectoryInfo cur, int pos)
        {
            FileSystemInfo[] data = cur.GetFileSystemInfos();
            for (int i = 0; i < data.Length; i++)
            {
                if (i == pos)
                    Console.BackgroundColor = ConsoleColor.Blue;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                if (data[i].GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(data[i].Name);
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Асер\Desktop\KBTU\test");
            while (true)
            {
                Console.Clear();
                showFolderContent(dir, pos);
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos > dir.GetFileSystemInfos().Length - 1)
                            pos = 0;
                        break;

                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        if (f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                        }
                        else if (f.GetType() == typeof(FileInfo))
                        {
                            FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);
                            Console.Clear();
                            Console.WriteLine(sr.ReadToEnd());

                            ConsoleKeyInfo ck = new ConsoleKeyInfo();
                            do
                            {
                                ck = Console.ReadKey();
                            }
                            while (ck.Key != ConsoleKey.Backspace);
                            Console.Clear();
                            showFolderContent(dir, pos);
                            sr.Close();
                            fs.Close();
                        }
                        break;

                    case ConsoleKey.Backspace:
                        dir = dir.Parent;
                        break;
                }
            }
        }
    }
}
