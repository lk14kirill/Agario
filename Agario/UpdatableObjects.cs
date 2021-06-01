using System.Collections.Generic;
using SFML.System;

namespace Agario
{
    public class UpdatableObjects
    {
        public List<IUpdatable> updatableObjects = new List<IUpdatable>();
        private delegate void OnRemoved();
        private OnRemoved onRemoved;
        public List<Player> GetBots()
        {
            List<Player> bots = new List<Player>();
            foreach (Player bot in updatableObjects)
            {
                if (!bot.IsPlayer())
                {
                    bots.Add(bot);
                } 
            }
            return bots;
        }
        public List<IUpdatable> GetList() => updatableObjects;
        public Player GetPlayer()
        {
            Player player = null;
            foreach (Player pl in updatableObjects)
            {
                if (pl.IsPlayer())
                {
                    player =  pl;
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
            if (onRemoved != null)
                onRemoved.Invoke();
        }
        public void Update(Vector2f direction, FoodList food, List<Player> bots, float time)
        {
            foreach (IUpdatable updatable in updatableObjects)
            {
                updatable.Update(direction, bots, food, time);
            }
        }
    }
}
