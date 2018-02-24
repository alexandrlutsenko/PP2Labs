﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    public class Food
    {
        public Random rnd = new Random();
        public Point location = new Point(0, 0);

        public Food()
        {
            location.x = rnd.Next(2, Console.WindowWidth);
            location.y = rnd.Next(2, Console.WindowHeight);
        }

        public void SetRandomPosition()
        {
            location.x = rnd.Next(2, Console.WindowWidth);
            location.y = rnd.Next(2, Console.WindowHeight);
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write("@");
        }

        public void Serialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            FileStream fs = new FileStream("savef.xml", FileMode.Create, FileAccess.ReadWrite);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Food Deserialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            FileStream fs = new FileStream("savef.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Food food = xs.Deserialize(fs) as Food;
            fs.Close();
            return food;
        }
    }
}
