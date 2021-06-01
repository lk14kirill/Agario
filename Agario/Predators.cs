using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class Predators : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Red;
            player.SetRadius(50);
        }
        public override void MoveToFood(Player player, List<Food> foodList, float time,List<Player> bots)
        {
            Player target = new Player();
            float minDistance = 5000;
            foreach (Player bot in bots)
            {
                if (player == bot )
                    continue;
                float tempDistance = MathExt.VectorLength(player.GetCenter(), bot.GetCenter());
                if (tempDistance < minDistance)
                {
                    if (player.GetRadius() < bot.GetRadius() + MathExt.GetPercentOf(bot.GetRadius(), 10)) 
                    continue;
                    minDistance = tempDistance;
                    target = bot;
                }
                
            }
            player.MoveToward(target.GetCenter(), time);
        }
        public override void TryEatFood(Player player, List<Food> foodList)
        {

        }
        public override void Intersect(Player player, List<Player> bots)
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
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating, whoWasEaten);
        }
        public override float GetSpeedModifier()
        {
            return base.GetSpeedModifier();
        }
    }
}
