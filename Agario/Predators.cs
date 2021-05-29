using SFML.Graphics;

namespace Agario
{
    class Predators : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Red;
            player.SetRadius(50);
        }
        public override void MoveToFood(Player player, FoodList foodList, float time, BotList botlist)
        {
            Player target = new Player();
            float minDistance = 5000;
            foreach (Player bot in botlist.bots)
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
        public override void TryEatFood(Player player, FoodList foodList)
        {

        }
        public override void Intersect(Player player, BotList bots)
        {
            foreach (Player bot in bots.bots)
            {
                if (player == bot)
                    return;

                if (MathExt.CheckForIntersect(player, bot))
                {
                    if (player.GetRadius() > bot.GetRadius() + MathExt.GetPercentOf(bot.GetRadius(), 10))
                        EatAndRemoveBot(player, bot, bots);

                    if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
                        EatAndRemoveBot(bot, player, bots);
                }
            }
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten, BotList bots)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating, whoWasEaten, bots);
        }
        public override float GetModifier()
        {
            return base.GetModifier();
        }
    }
}
