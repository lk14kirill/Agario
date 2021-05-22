using System.Collections.Generic;

namespace Agario
{
    public class BotList
    {
        private delegate void OnRemoved();
        OnRemoved onRemoved;
        public List<Bot> bots = new List<Bot>();
        public void Init()
        {
            onRemoved += Create;
        }
        public void Create()
        {
            Bot newBot = new Bot();
            bots.Add(newBot);
            Constants.CircleCreated.Invoke(newBot);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Bot newBot = new Bot();
                bots.Add(newBot);
                if (Constants.CircleCreated != null)
                    Constants.CircleCreated.Invoke(newBot);
            }
        }
        public void RemoveBot(Bot bot)
        {
            bots.Remove(bot);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(bot);
            if (onRemoved != null)
                onRemoved.Invoke();
        }
        public void MoveBotsToFood(FoodList foodlist,float time)
        {
            foreach(Bot bot in bots)
            {
                bot.MoveToFood(foodlist,time);
            }
        }
    }
}
