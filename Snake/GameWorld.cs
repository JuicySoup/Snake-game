using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Snake
{
    public class GameWorld
    {
        public int Width, Height, Score, foodTimer, randomCounter, randomNumber;
        public List<GameObject> List = new List<GameObject>();
        private Player player;

        public GameWorld(int width, int height)
        {
            Width = width;
            Height = height;
            foodTimer = 10;
        }

        public void Update()
        {

            // Vi kör update på alla individuella saker i GameObject listan 
            foreach (var item in List)
            {
                item.Update();
                // Om item är Player, kastar vi item till Player 
                // för att kunna använda dess properties utanför loopen.
                if (item is Player)
                {
                    player = item as Player;
                }
            }

            // För att kunna hantera flera Food i GameObject listan gör vi en loop som har index.
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] is Food)
                {
                    if (List[i].Position.Equals(player.Position))
                    {
                        List.RemoveAt(i);
                        Score++;
                        CreateFood();
                        foodTimer = 10;
                    }

                    // Om randomCounter som uppdateras varje sekund når randomNumber 
                    // gör vi en ny mat som kommer ha ny position.
                    if (randomCounter == randomNumber)
                    {
                        List.RemoveAt(i);
                        RandomizeFood();
                        CreateFood();
                    }
                }
            }

            UpdatePlayerBounds();
        }
        public void CreateFood()
        {
            Food food = new Food(this);
            this.List.Add(food);
        }

        public void RandomizeFood()
        {
            Random rand = new Random();
            randomNumber = rand.Next(2, 8);
            randomCounter = 0;

        }

        /// <summary>
        /// Vi gör spelvärlden oändlig genom att teleportera spelaren till motsatt sida som spelaren åker in i,
        /// utan att ändra på direction. 
        /// </summary>
        public void UpdatePlayerBounds()
        {
            if (player.Position.X < 0)
            {
                player.Position.X = Width - 1;
            }
            else if (player.Position.X >= Width)
            {
                player.Position.X = 0;
            }
            else if (player.Position.Y < 0)
            {
                player.Position.Y = Height - 1;
            }
            else if (player.Position.Y >= Height - 1)
            {
                player.Position.Y = 0;
            }
        }
    }
}