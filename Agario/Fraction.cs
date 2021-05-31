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
            whoIsEating.Eat(whoWasEaten);
            whoWasEaten.SetIsEaten(true);
            UpdatableObjects.AddToBotsToRemove(whoWasEaten);

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
        public virtual void TryEatFood(Player player, FoodList foodList)
        {
            foreach (Food food in foodList.food)
            {
                if (MathExt.CheckForIntersect(player, food))
                {
                    foodList.RemoveFood(food);
                    if (player.GetRadius() < 400)
                        player.Eat(food);
                    return;
                }
            }
        } 
        public virtual void MoveToFood(Player player, FoodList foodList, float time,List<Player> bots)
        {
            Food target = new Food();
            float minDistance = 5000;
            foreach (Food food in foodList.food)
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
