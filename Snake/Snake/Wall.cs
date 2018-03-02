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
            FileStream fs = new FileStream(@"C:\Users\Асер\Desktop\KBTU\Snake\Snake\bin\Debug\Levels\level" + level + ".txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            
            int row = 0;
            string line = null;
            while (row < 21)
            {
                line = sr.ReadLine();
                for (int col = 1; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                row++;
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
