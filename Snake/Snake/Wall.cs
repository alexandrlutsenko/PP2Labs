using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public void ReadLevel(int level)
        {
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\Snake\Snake\bin\Debug\Levels\level" + level + ".txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '#')
                    {
                        body.Add(new Point(j, i));
                    }
                }
            }
            sr.Close();
            fs.Close();
        }

        public Wall() { }
        public Wall(int level)
        {
            body = new List<Point>();
            sign = '#';
            color = ConsoleColor.Cyan;
            ReadLevel(level);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Serialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("savew.xml", FileMode.Create, FileAccess.ReadWrite);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Wall Deserialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("savew.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Wall wall = xs.Deserialize(fs) as Wall;
            fs.Close();
            return wall;
        }
    }
}
