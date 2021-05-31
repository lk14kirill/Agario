using System.Collections.Generic;
using SFML.System;

namespace Agario
{
    public class UpdatableObjects
    {
        public List<IUpdatable> updatableObjects = new List<IUpdatable>();
        private delegate void OnRemoved();
        private OnRemoved onRemoved;
        private static List<Player> botsToRemove = new List<Player>();
        public static void AddToBotsToRemove(Player player) => botsToRemove.Add(player);
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
        public void RemoveCachedBots()
        {
            foreach (Player player in botsToRemove)
            {
                RemoveBot(player);
            }
            botsToRemove = new List<Player>();
        }
        public void Init()
        {
            onRemoved += CreateBot;
        }
        public void Unsubscribe()
        {
            onRemoved -= CreateBot;
        }
        public void Add(IUpdatable updatable)
        {
            updatableObjects.Add(updatable);
        }
        public void Remove(IUpdatable updatable)
        {
            updatableObjects.Remove(updatable);
        }
        public void AddOnIndex(Player player, int index)
        {
            updatableObjects.Insert(index, player);
            Constants.CircleCreated.Invoke(player);
        }
        public void RemoveOnIndex(int index, Player player)
        {
            updatableObjects.RemoveAt(index);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(player);
        }
        public void CreatePlayer()
        {
            Player newPlayer = new Player();
            newPlayer.id = 0;
            newPlayer.Init();
            newPlayer.SetIsPlayer(true);
            updatableObjects.Add(newPlayer);
            if (Constants.CircleCreated != null)
                Constants.CircleCreated.Invoke(newPlayer);
        }
        public void CreateBot()
        {
            Player newBot = new Player();
            newBot.Init();
            newBot.id = j;
            updatableObjects.Add(newBot);
            if (Constants.CircleCreated != null)
                Constants.CircleCreated.Invoke(newBot);
        }
        int j;
        public void CreateBots(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                j = i+1;
                CreateBot();
            }
        }
        public void RemoveBot(Player bot)
        {
            updatableObjects.Remove(bot);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(bot);
            if (onRemoved != null)
                onRemoved.Invoke();
        }
        public void UpdateBots(Vector2f direction, FoodList food, List<Player> bots, float time)
        {
            foreach (IUpdatable updatable in updatableObjects)
            {
                updatable.Update(direction, bots, food, time);
            }
        }
    }
}
