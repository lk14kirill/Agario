using System.Collections.Generic;

namespace Agario
{
    public class BotList
    {
        public List<Bot> bots = new List<Bot>();
        public void Create()
        {
            Bot newBot = new Bot();
            bots.Add(newBot);
            Constants.createDelegate.Invoke(newBot);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Bot newBot = new Bot();
                bots.Add(newBot);
                if (Constants.createDelegate != null)
                    Constants.createDelegate.Invoke(newBot);
            }
        }
        public void RemoveBot(Bot bot)
        {
            bots.Remove(bot);
            if (Constants.removeDelegate != null)
                Constants.removeDelegate.Invoke(bot);
            Create();
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
