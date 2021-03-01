using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void UpdateTestRight()
        {
            var player = new Player(new GameWorld(50, 20), Direction.Right);
            var expected = new Position(player.Position.X+1, player.Position.Y);
            player.Update();
            var actual = new Position(player.Position.X, player.Position.Y);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void UpdateTestLeft()
        {
            var player = new Player(new GameWorld(50, 20), Direction.Left);
            var expected = new Position(player.Position.X - 1, player.Position.Y);
            player.Update();
            var actual = new Position(player.Position.X, player.Position.Y);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void UpdateTestUp()
        {
            var player = new Player(new GameWorld(50, 20), Direction.Up);
            var expected = new Position(player.Position.X, player.Position.Y - 1);
            player.Update();
            var actual = new Position(player.Position.X, player.Position.Y);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void UpdateTestDown()
        {
            var player = new Player(new GameWorld(50, 20), Direction.Down);
            var expected = new Position(player.Position.X, player.Position.Y + 1);
            player.Update();
            var actual = new Position(player.Position.X, player.Position.Y);
            Assert.AreEqual(expected, actual);
        }
    }
}