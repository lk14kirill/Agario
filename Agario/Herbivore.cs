using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    public class Herbivore : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Green;
        }
        float weightModifier=1.2f,speedModifier = 1.2f;
        public override float GetSpeedModifier() => speedModifier;
        public override float GetWeightModifier() => weightModifier;
        public override void TryEatFood(Player player, List<Food> foodList)
        {
            base.TryEatFood(player, foodList);
        }
        public override void Eat(Player player, CircleObject whatToEat)
        {
            player.SetRadius(player.GetRadius() + whatToEat.GetRadius() - 3.5f);
        }
        public override void MoveToFood(Player player, List<Food> foodList, float time, List<Player> botlist)
        {
            base.MoveToFood(player, foodList, time, botlist);
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten)
        {
            if (whoIsEating.GetFraction() is Herbivore)
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
