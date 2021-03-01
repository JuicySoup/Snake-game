using System;
using System.Threading;

namespace Snake
{
    // Av Jonathan Österberg + jobbat tillsammans med Elvira Urberg
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Start()
        {
            // Initialisera spelet
            const int frameRate = 10;
            int updateCounter = 0;
            GameWorld world = new GameWorld(50, 20);
            ConsoleRenderer renderer = new ConsoleRenderer(world);
            Player player = new Player(world, Direction.Right);
            world.CreateFood();
            // Huvudloopen
            bool running = true;
            while (running)
            {
                if (world.foodTimer == 0)
                {
                    Console.Clear();
                    string endString1 = "Game over";
                    string endString2 = $"Your score was {world.Score}";
                    Console.SetCursorPosition((world.Width / 2) - (endString1.Length / 2), world.Height / 3);
                    Console.Write(endString1);
                    Console.SetCursorPosition((world.Width / 2) - (endString2.Length / 2), world.Height / 2);
                    Console.Write(endString2);
                    break;
                }
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        break;
                    case ConsoleKey.UpArrow:
                        player.Direction = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        player.Direction = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        player.Direction = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        player.Direction = Direction.Right;
                        break;
                }
                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();

                // Vi kollar om det har gått en sekund.
                if (updateCounter == frameRate - 1)
                {
                    // Om det har det, uppdatera dessa timers så att de uppdateras varje sekund.
                    world.foodTimer--;
                    world.randomCounter++;
                    updateCounter = 0;
                }
                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
                updateCounter++;
            }
        }

        static void Main(string[] args)
        {
            Start();
            // Vi lägger en readline här så att programmet inte krashas efteråt.
            Console.ReadLine();
        }
    }
}
