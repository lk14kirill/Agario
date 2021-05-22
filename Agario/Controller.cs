using System.Collections.Generic;

namespace Agario
{
    public class Controller
    {
        public  void EatFoodAndRemove(Player firstCircle,FoodList foodList)     //Ricochets first circle
        {
            foreach (Food food in foodList.food)
            {
                double distanceBetweenRadiuses = MathExt.VectorLength(food.GetCenter(), firstCircle.GetCenter()); ;

                if (distanceBetweenRadiuses <= firstCircle.GetRadius() + food.GetRadius())
                {
                   foodList.RemoveFood(food);
                    firstCircle.Eat(food);
                    return;
                }
            }
        }
        public  void EatFoodAndRemove(BotList bots, FoodList foodList)     //Ricochets first circle
        {
            foreach(Bot bot in bots.bots)
            {
                foreach (Food food in foodList.food)
                {
                    double distanceBetweenRadiuses = MathExt.VectorLength(food.GetCenter(), bot.GetCenter()); ;

                    if (distanceBetweenRadiuses <= bot.GetRadius() + food.GetRadius())
                    {
                        foodList.RemoveFood(food);
                        bot.Eat(food);
                        return;
                    }
                }
            }
            
        }
        public  void IntersectBetweenBots(BotList list1) 
        {
            foreach(Bot first in list1.bots)
            {
                foreach(Bot second in list1.bots)
                {
                    if(first != second)
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
        public  void IntersectBetweenPlayers(Player first, BotList bots)
        {
            foreach (Bot second in bots.bots)
            {
                double distanceBetweenRadiuses = MathExt.VectorLength(first.GetCenter(), second.GetCenter()); ;
                if (distanceBetweenRadiuses <= first.GetRadius()+second.GetRadius() / 2)
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
