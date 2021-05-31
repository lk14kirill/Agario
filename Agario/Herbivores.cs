using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    public class Herbivores : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Green;
        }
        float weightModifier=1.2f,speedModifier = 1.2f;
        public override float GetSpeedModifier() => speedModifier;
        public override float GetWeightModifier() => weightModifier;
        public override void TryEatFood(Player player, FoodList foodList)
        {
            base.TryEatFood(player, foodList);
        }
        public override void MoveToFood(Player player, FoodList foodList, float time, List<Player> botlist)
        {
            base.MoveToFood(player, foodList, time, botlist);
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating,whoWasEaten);
        }
        public override void Intersect(Player player, List<Player> bots)
        {
            foreach (Player bot in bots)
            {
                if (player == bot)
                    return;

                if (MathExt.CheckForIntersect(player, bot))
                {
                    if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
                        EatAndRemoveBot(bot, player);
                }
            }
        }
    }
}
