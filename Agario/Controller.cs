using System.Collections.Generic;

namespace Agario
{
    public class Controller
    {
        public void IntersectBetweenPlayerAndBots(Player player, BotList bots)
        {
            foreach (Player bot in bots.bots)
            {
                if (player == bot)
                    return;

                if(MathExt.CheckForIntersect(player,bot))
                {
                    if (player.GetRadius() > bot.GetRadius() + MathExt.GetPercentOf(bot.GetRadius(), 10))
                        EatAndRemoveBot(player, bot, bots);

                    if (player.GetRadius() + MathExt.GetPercentOf(player.GetRadius(), 10) < bot.GetRadius())
                        EatAndRemoveBot(bot, player, bots);   
                }
                
            }
        }
        private void EatAndRemoveBot(Player whoIsEating,Player whoWasEaten, BotList bots)
        {
            whoIsEating.Eat(whoWasEaten);
            whoWasEaten.SetIsEaten(true);
            bots.AddToBotsToRemove(whoWasEaten);
        }
        public void IntersectBetweenBots(BotList bots)
        {
            foreach (Player bot in bots.bots)
            {
                IntersectBetweenPlayerAndBots(bot, bots);
            }
        }

    }
}
