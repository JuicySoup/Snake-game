using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public abstract class GameObject
    {
        public Position Position;

        public abstract void Update();
    }
    public interface IRenderable
    {
        char Character { get; }
    }

    public interface IMovable
    {
        Direction Direction { get; set; }
    }
}