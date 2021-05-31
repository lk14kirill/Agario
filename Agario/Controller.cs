using System;

namespace Agario
{
    class Controller
    {
        public Player ChangePlayerAndReplaceBots(Player currentPlayer, BotList bots)
        {
            Player player = null;
            Random rand = new Random();
            int r = rand.Next(0, bots.GetBots().Count);
            int i = 0;
            foreach (Player bot in bots.GetBots())
            {
                if (i == r)
                {
                    player = bot;
                }
                i++;
            }
            ReplaceBotAndChangeStatus(bots, r, currentPlayer);
            player.SetIsPlayer(true);
            return player;
        }
        private void ReplaceBotAndChangeStatus(BotList bots, int random, Player currentPlayer)
        {
            currentPlayer.SetIsPlayer(false);
            bots.RemoveOnIndex(random, currentPlayer);
            bots.AddOnIndex(currentPlayer, random);

        }
    }
}
