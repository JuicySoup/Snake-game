using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Tests
{
    [TestClass()]
    public class GameWorldTests
    {
        [TestMethod()]
        public void CreateFoodTest()
        {
            var world = new GameWorld(50, 20);
            var expected = world.List.Count + 1;
            world.CreateFood();
            var actual = world.List.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdatePlayerBoundsTest()
        {
            var world = new GameWorld(50, 20);
            new Player(world, Direction.Right);
            for (int i = 0; i < 30; i++)
            {
                world.Update();
            }
            var expected = 25;
            var actual = world.List.Find(p => p is Player).Position.X;
            Assert.IsTrue(expected > actual);
        }
    }
}