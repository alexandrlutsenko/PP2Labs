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
                    wall = new Wall(level);
                }
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
                while (food.OnSnake(food.location.x, food.location.y, snake) || food.OnWall(food.location.x, food.location.y, wall))
                {
                    food.SetRandomPosition();
                }
                if (snake.Collision(wall))
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("press any key to start over");
                    Console.ReadKey();
                    Console.Clear();
                    snake = new Snake();
                    level = 1;
                    score = 0;
                    speed = 100;
                    wall = new Wall();
                }
                if (snake.Eat(food))
                {
                    cnt++;
                    score++;
                }
                //Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();
                Console.SetCursorPosition(10, 25);
                Console.WriteLine("level " + level);
                Console.SetCursorPosition(10, 26);
                Console.WriteLine("score " + score.ToString());
                Console.SetCursorPosition(75, 4);
                Console.WriteLine("use directional keys to move");
                Console.SetCursorPosition(75, 6);
                Console.WriteLine("press Q to save");
                Console.SetCursorPosition(75, 8);
                Console.WriteLine("press W to load");
                Console.SetCursorPosition(75, 10);
                Console.WriteLine("press ESC to exit");

                if (score%4 == 0 && score != 0)
                {
                    speed = speed - 10;
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
                    if(direction != 2)
                        direction = 1;
                }
                if (btn.Key == ConsoleKey.DownArrow)
                {
                    if (direction!= 1)
                        direction = 2;
                }
                if (btn.Key == ConsoleKey.RightArrow)
                {
                    if(direction != 4)
                        direction = 3;
                }
                if (btn.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != 3)
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
