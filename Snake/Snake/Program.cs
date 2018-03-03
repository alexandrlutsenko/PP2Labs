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
        static int map = 1;
        static int level = 1;
        static Wall wall = new Wall(map);
        static int cnt = 0;
        static int score = 0;
        static int direction = 0;
        static bool gameover = false;
        static int speed = 150;
        static int sp = 0;
        //static int qm, ql, qcnt, qs, qd, qspeed, qsp;


        static void Game()
        {
            while (!gameover)
            {
                if (cnt == 4)
                {
                    level++;
                    map++;
                    if(map > 4)
                    {
                        map = 1;
                    }
                    cnt = 0;
                    Console.Clear();
                    wall = new Wall(map);
                }

                if (score%4 == 0 && score != 0)
                {
                    if (sp == 0)
                    {
                        speed = speed - 10;
                        sp++;
                    }
                }
                if (score%4 == 1)
                {
                    sp = 0;
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

                if (snake.Eat(food))
                {
                    cnt++;
                    score++;
                }

                if (snake.Collision(wall))
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("press SPACE to start over");
                    Console.SetCursorPosition(30, 12);
                    Console.WriteLine("press ESC to exit");
                    Console.SetCursorPosition(30, 13);
                    Console.WriteLine("press them twice, 'cause i have no idea how to fix that");
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (k.Key == ConsoleKey.Escape)
                    {
                        gameover = true;
                        break;
                    }
                    if (k.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        snake = new Snake();
                        direction = 0;
                        cnt = 0;
                        map = 1;
                        level = 1;
                        score = 0;
                        speed = 150;
                        sp = 0;
                        wall = new Wall(map);
                    }
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
                Console.WriteLine("use DIRECTIONAL KEYS to move");
                Console.SetCursorPosition(75, 6);
                Console.WriteLine("press Q to save");
                Console.SetCursorPosition(75, 8);
                Console.WriteLine("press W to load (works wierdly)");
                Console.SetCursorPosition(75, 10);
                Console.WriteLine("press ESC to exit");

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
                    if (direction != 3 && direction != 0)
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
                   /* qm = map;
                    ql = level;
                    qcnt = cnt;
                    qs = score;
                    qd = direction;
                    qspeed = speed;
                    qsp = sp;*/
                }
                if (btn.Key == ConsoleKey.W)
                {
                    snake = snake.Deserialization();
                    food = food.Deserialization();
                    wall = wall.Deserialization();

                    Console.Clear();

                    /*map = qm;
                    level = ql;
                    cnt = qcnt;
                    score = qs;
                    direction = qd;
                    speed = qspeed;
                    sp = qsp;*/
                }
            }
        }
    }
}
