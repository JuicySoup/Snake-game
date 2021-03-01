using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            world = gameWorld;
            Console.SetWindowSize(world.Width, world.Height);
            Console.SetBufferSize(world.Width, world.Height);
            Console.CursorVisible = false;
        }

        public void Render()
        {
            Console.SetCursorPosition(0, world.Height - 1);
            Console.Write($"Score: {world.Score}");
            // Vi lägger till ett extra blanksteg i slutet för att sudda ut hela foodtimern.
            string foodTimer = $"Food Timer: {world.foodTimer, -2} ";
            Console.SetCursorPosition(world.Width - foodTimer.Length, world.Height - 1);
            Console.Write(foodTimer);

            foreach (var item in world.List)
            {
                if (item is IRenderable)
                {
                    Console.SetCursorPosition(item.Position.X, item.Position.Y);
                    Console.Write((item as IRenderable).Character);
                }
            }
        }

        /// <summary>
        /// För att förhindra att appen blinkar vid Console.Clear skriver vi vår egen anpassade metod för det.
        /// </summary>
        public void RenderBlank()
        {
            foreach (var item in world.List)
            {
                Console.SetCursorPosition(item.Position.X, item.Position.Y);
                Console.Write(" ");
            }
        }
    }
}
