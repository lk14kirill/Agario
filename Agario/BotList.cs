using System.Collections.Generic;

namespace Agario
{
    public class BotList
    {
        private delegate void OnRemoved();
        private  OnRemoved onRemoved;
        public List<Player> bots = new List<Player>();
        private List<Player> botsToRemove = new List<Player>();
        public void AddToBotsToRemove(Player player) => botsToRemove.Add(player);
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
        public void Create()
        {
            Player newBot = new Player();
            newBot.BotInit();
            bots.Add(newBot);
            Constants.CircleCreated.Invoke(newBot);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Player newBot = new Player();
                newBot.BotInit();
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
        public void MoveBotsToFood(FoodList foodlist,float time)
        {
            foreach(Player bot in bots)
            {
                bot.MoveToFood(foodlist,time);
            }
        }
        public void TryEatFood(FoodList foodList)
        {
            foreach (Player bot in bots)
            {
                bot.TryEatFood(foodList);
            }
        }
        public void LoseWeight()
        {
            foreach(Player player in bots)
            {
                player.LoseWeightAndChangeSpeed();
            }
        }
    }
}
