using System.Collections.Generic;
using SFML.System;

namespace Agario
{
    public class BotList
    {
        private delegate void OnRemoved();
        private  OnRemoved onRemoved;
        private List<Player> bots = new List<Player>();
        private List<Player> botsToRemove = new List<Player>();
        public void AddToBotsToRemove(Player player) => botsToRemove.Add(player);
        public List<Player> GetBots() => bots;
        public void RemoveCachedBots()
        {
            foreach(Player player in botsToRemove)
            {
                RemoveBot(player);
            }
            botsToRemove = new List<Player>();
        }
        public void Init()
        {
            onRemoved += Create;
        }
        public void Unsubscribe()
        {
            onRemoved -= Create;
        }
        public void AddOnIndex(Player player,int index)
        {
            bots.Insert(index, player);
            Constants.CircleCreated.Invoke(player);
        }
        public void RemoveOnIndex(int index,Player player)
        {
            bots.RemoveAt(index);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(player);
        }
        public void Create()
        {
            Player newBot = new Player();
            newBot.Init();
            bots.Add(newBot);
             if (Constants.CircleCreated != null)
            Constants.CircleCreated.Invoke(newBot);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Player newBot = new Player();
                newBot.Init();
                bots.Add(newBot);
                if (Constants.CircleCreated != null)
                    Constants.CircleCreated.Invoke(newBot);
            }
        }
        public void RemoveBot(Player bot)
        {
            bots.Remove(bot);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(bot);
            if (onRemoved != null)
                onRemoved.Invoke();
        }
         public void UpdateBots(Vector2f direction,FoodList food,BotList bots,float time)
        {
            foreach (Player bot in this.bots)
            {
                bot.Update(direction, bots, food, time);
            }
        }
    }
}
