using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Food : GameObject, IRenderable
    {
        public char Character { get { return '*'; } }

        public Food(GameWorld gameWorld)
        {
            Random rand = new Random();
            Position.X = rand.Next(0, gameWorld.Width);
            // För att mat inte ska kunna spawna på samma linje som score och foodtimer ändrar vi height
            Position.Y = rand.Next(0, gameWorld.Height - 2);
        }
        public override void Update()
        {

        }
    }
}