using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
     public class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Snake()
        {
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>
            {
                new Point(12, 10),
                new Point(11, 10),
                new Point(10, 10)
            };
        }

        public void Move(int dx, int dy)
        {
            Point fill = body[body.Count - 1];
            Console.SetCursorPosition(fill.x, fill.y);
            Console.Write(' ');

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;



            /*if (body[0].x < 1)
            {
                body[0].x = Console.WindowWidth - 1;
            }
            if (body[0].x > Console.WindowWidth - 1)
            {
                body[0].x = 1;
            }
            if (body[0].y < 1)
            {
                body[0].y = Console.WindowHeight - 1;
            }
            if (body[0].y > Console.WindowHeight - 1)
            {
                body[0].y = 1;
            }*/
        }

        public void Serialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            FileStream fs = new FileStream("save.xml", FileMode.Create, FileAccess.ReadWrite);
            try
            {
                xs.Serialize(fs, this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public Snake Deserialization()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Snake snake = xs.Deserialize(fs) as Snake;
            fs.Close();
            return snake;
        }

        public bool Eat(Food food)
        {
            if (body[0].x == food.location.x && body[0].y == food.location.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                food.SetRandomPosition();
                return true;
            }
            return false;
        }

        public bool Collision(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }


        public void Draw()
        {

            for (int i = 0; i < body.Count; i++)
            {
                int index = 0;
                foreach (Point p in body)
                {
                    if (index == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = color;
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(sign);
                    index++;
                }
            }
        }
    }
}
