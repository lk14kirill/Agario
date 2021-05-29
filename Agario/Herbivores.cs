using SFML.Graphics;

namespace Agario
{
    public class Herbivores : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Green;
        }
        float speedModifier = 1.2f;
        public override float GetModifier() => speedModifier;
        public override void TryEatFood(Player player, FoodList foodList)
        {
            base.TryEatFood(player, foodList);
        }
        public override void MoveToFood(Player player, FoodList foodList, float time, BotList botlist)
        {
            base.MoveToFood(player, foodList, time, botlist);
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten, BotList bots)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating,whoWasEaten,bots);
        }
        public override void Intersect(Player player, BotList bots)
        {
            foreach (Player bot in bots.bots)
            {
                if (player == bot)
                    return;

                if (MathExt.CheckForIntersect(player, bot))
                {
                    if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
                        EatAndRemoveBot(bot, player, bots);
                }
            }
        }
    }
}
