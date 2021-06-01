using System.Collections.Generic;
namespace Agario
{
    public class Fraction
    {
        public virtual float GetSpeedModifier()
        {
            return 1;
        }
        public virtual float GetWeightModifier()
        {
            return 1f;
        }
        public virtual void Init(Player player)
        {

        } 

        public virtual void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten)
        {
            Eat(whoIsEating,whoWasEaten);
            whoWasEaten.SetIsEaten(true);
            Fabric.Instance.AddToObjectsToRemove(whoWasEaten);

        }
        public virtual void Intersect(Player player, List<Player> bots)
        {
            foreach (Player bot in bots)
            {
                if (player == bot)
                    return;

                if (MathExt.CheckForIntersect(player, bot))
                {
                    if (player.GetRadius() > bot.GetRadius() + MathExt.GetPercentOf(bot.GetRadius(), 10))
                        EatAndRemoveBot(player, bot);

                    if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
                        EatAndRemoveBot(bot, player);
                }
            }
        }
        public virtual void TryEatFood(Player player, List<Food> foodList)
        {
            foreach (Food food in foodList)
            {
                if (MathExt.CheckForIntersect(player, food))
                {
                    Fabric.Instance.AddToObjectsToRemove(food);
                    if (player.GetRadius() < 400)
                        Eat(player,food);
                    return;
                }
            }
        }
        public virtual void Eat(Player player,CircleObject whatToEat)
        {
            player.SetRadius(player.GetRadius() + whatToEat.GetRadius() - 4);
        }
        public virtual void MoveToFood(Player player, List<Food> foodList, float time,List<Player> bots)
        {
            Food target = new Food();
            float minDistance = 5000;
            foreach (Food food in foodList)
            {
                float tempDistance = MathExt.VectorLength(player.GetCenter(), food.GetCenter());
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    target = food;
                }
            }
            player.MoveToward(target.GetCenter(), time);
        }
    }
}
