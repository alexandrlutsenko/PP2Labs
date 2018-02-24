using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {
        static Snake snake = new Snake();
        static Food food = new Food();
        static int level = 1;
        static Wall wall = new Wall(level);
        static int cnt = 0;
        static int score = 0;
        static int direction = 1;
        static bool gameover = false;
        static int speed = 100;

        static void Game()
        {
            while (!gameover)
            {
                if (cnt == 4)
                {
                    level++;
                    cnt = 0;
                }
                wall = new Wall(level);

                if (direction == 1)
                {
                    snake.Move(0, -1);
                }
                if (direction == 2)
                {
                    snake.Move(0, 1);
                }
                if (direction == 3)
                {
                    snake.Move(1, 0);
                }
                if (direction ==  4)
                {
                    snake.Move(-1, 0);
                }
                while (snake.ColwItself(food.location.x, food.location.y) || snake.ColwWall(food.location.x, food.location.y, wall))
                {
                    food.SetRandomPosition();
                }
                if (snake.Collision(wall))
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    score = 0;
                    speed = 100;
                }
                if (snake.Eat(food))
                {
                    cnt++;
                    score++;
                }
                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();
                Console.SetCursorPosition(10, 0);
                Console.WriteLine("level " + level);
                Console.WriteLine("score " + score.ToString());

                if (score%4 == 0 && score != 0)
                {
                    speed = Math.Max(speed - 1, 1);
                }
                Thread.Sleep(speed);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread = new Thread(Game);
            thread.Start();

            while (!gameover)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                if(btn.Key == ConsoleKey.UpArrow)
                {
                    direction = 1;
                }
                if (btn.Key == ConsoleKey.DownArrow)
                {
                    direction = 2;
                }
                if (btn.Key == ConsoleKey.RightArrow)
                {
                    direction = 3;
                }
                if (btn.Key == ConsoleKey.LeftArrow)
                {
                    direction = 4;
                }
                if (btn.Key == ConsoleKey.Escape)
                {
                    gameover = true;
                }
                if (btn.Key == ConsoleKey.Q)
                {
                    snake.Serialization();
                    food.Serialization();
                    wall.Serialization();
                }
                if (btn.Key == ConsoleKey.W)
                {
                    snake.Deserialization();
                    food.Deserialization();
                    wall.Deserialization();
                }
            }
        }
    }
}
