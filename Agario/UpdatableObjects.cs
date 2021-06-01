using System.Collections.Generic;
using SFML.System;

namespace Agario
{
    public class UpdatableObjects
    {
        public List<IUpdatable> updatableObjects = new List<IUpdatable>();
         public List<IUpdatable> GetList() => updatableObjects;
        public List<Player> GetBots()
        {
            List<Player> bots = new List<Player>();
            foreach (IUpdatable updatable in updatableObjects)
            {
                if(updatable is Player)
                {
                    Player player = (Player)updatable;
                    if (!player.IsPlayer())
                    {
                        bots.Add(player);
                    }
                }
                
            }
            return bots;
        }
        public List<Food> GetFood()
        {
            List<Food> foodList = new List<Food>();
            foreach (IUpdatable updatable in updatableObjects)
            {
                if (updatable is Food)
                {
                    Food food = (Food)updatable;
                        foodList.Add(food);
                }
            }
            return foodList;
        }
        public Player GetPlayer()
        {
            Player player = null;
            foreach (IUpdatable pl in updatableObjects)
            {

                if (pl is Player)
                {
                    Player tempPlayer = pl as Player;
                    if (tempPlayer.IsPlayer())
                    {
                      player = tempPlayer;
                    }
                }
            }
            return player;
        }
        public void Add(IUpdatable updatable)
        {
            updatableObjects.Add(updatable);
        }
        public void Remove(IUpdatable updatable)
        {
            updatableObjects.Remove(updatable);
        }
        public void Update(Vector2f direction, List<Food> food, List<Player> bots, float time)
        {
            foreach (IUpdatable updatable in updatableObjects)
            {
                updatable.Update(direction, bots, food, time);
            }
        }
    }
}
