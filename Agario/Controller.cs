using System.Collections.Generic;

namespace Agario
{
    public class Controller
    {
        public  void TryEatFood(Player player,FoodList foodList)
        {
            foreach (Food food in foodList.food)
            {
                double distanceBetweenRadiuses = MathExt.VectorLength(food.GetCenter(), player.GetCenter());

                if (distanceBetweenRadiuses <= player.GetRadius() + food.GetRadius())
                {
                   foodList.RemoveFood(food);
                    player.Eat(food);
                    return;
                }
            }
        }
        public  void TryEatFood(BotList bots, FoodList foodList)     
        {
            foreach(Bot bot in bots.bots)
            {
                TryEatFood(bot, foodList);             
            }         
        }
        //public  void IntersectBetweenBots(BotList bots) 
        //{
        //    foreach(Bot bot in bots.bots)
        //    {
        //        IntersectBetweenPlayers(bot, bots);
        //    }
        //}
        //public  void IntersectBetweenPlayers(Player player, BotList bots)
        //{
        //    foreach (Bot bot in bots.bots)
        //    {
        //        if (player == bot)
        //            return;
        //        double distanceBetweenRadiuses = MathExt.VectorLength(player.GetCenter(), bot.GetCenter()); ;
        //        if (distanceBetweenRadiuses <= player.GetRadius()+bot.GetRadius() / 2)
        //        {
        //            if (player.GetRadius() > bot.GetRadius() + MathExt.GetPercentOf(bot.GetRadius(), 10))
        //            {
        //                player.Eat(bot);
        //                bots.RemoveBot(bot);
        //            }
        //            if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
        //            {
        //                bot.Eat(player);
        //                bots.RemoveBot()
        //                Game.GameEnded(true);
        //            }
        //        }
        //    }

        //}
        public void IntersectBetweenBots(BotList list1)
        {
            foreach (Bot first in list1.bots)
            {
                foreach (Bot second in list1.bots)
                {
                    if (first != second)
                    {                
                        double distanceBetweenRadiuses = MathExt.VectorLength(first.GetCenter(), second.GetCenter()); ;
                        if (distanceBetweenRadiuses <= first.GetRadius() + second.GetRadius() / 2)
                        {
                            if (first.GetRadius() > second.GetRadius() /*+ MathExt.GetPercentOf(second.GetRadius(), 10)*/)
                            {
                                first.Eat(second);
                                list1.RemoveBot(second);
                            }
                            if (first.GetRadius() /*+MathExt.GetPercentOf(first.GetRadius(), 10)*/ < second.GetRadius())
                            {
                                second.Eat(first);
                                list1.RemoveBot(first);
                            }
                            return;
                        }
                    }
                }
            }
        }
        public void IntersectBetweenPlayers(Player first, BotList bots)
        {
            foreach (Bot second in bots.bots)
            {
                double distanceBetweenRadiuses = MathExt.VectorLength(first.GetCenter(), second.GetCenter()); ;
                if (distanceBetweenRadiuses <= first.GetRadius() + second.GetRadius() / 2)
                {
                    if (first.GetRadius() > second.GetRadius() + MathExt.GetPercentOf(second.GetRadius(), 10))
                    {
                        first.Eat(second);
                        bots.RemoveBot(second);
                    }
                    if (first.GetRadius() + MathExt.GetPercentOf(first.GetRadius(), 10) < second.GetRadius())
                    {
                        second.Eat(first);
                        Game.GameEnded(true);  // mne toshe ne nrav
                    }
                    return;
                }
            }

        }
    }
}
