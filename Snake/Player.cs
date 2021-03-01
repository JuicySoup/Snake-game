using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Player : GameObject, IMovable, IRenderable
    {
        public Direction Direction { get; set; }
        public char Character { get { return 'X'; } }
        public Player(GameWorld gameWorld, Direction d)
        {
            Position.X = gameWorld.Width / 2;
            Position.Y = gameWorld.Height / 2;
            gameWorld.List.Add(this);
            Direction = d;
        }

        public override void Update()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                default:
                    break;
            }
        }
    }
}
