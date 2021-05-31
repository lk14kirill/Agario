using System;
using System.Collections.Generic;

namespace Agario
{
    class Controller
    {
        public void ChangePlayerAndReplaceBots(UpdatableObjects updatableObjects)
        {
            Player player = null;
            Player currentPlayer = updatableObjects.GetPlayer();
            Random rand = new Random();
            int r = rand.Next(0, updatableObjects.GetBots().Count -1);
            int i = 0;
            foreach (Player bot in updatableObjects.GetBots())
            {
                if (i == r)
                {
                    player = bot;
                }
                i++;
            }
            ReplaceBotAndChangeStatus(updatableObjects, r, currentPlayer,player);
            
        }
        private void ReplaceBotAndChangeStatus(UpdatableObjects bots, int random, Player currentPlayer,Player player)
        {
            if (currentPlayer == null || player == null)
                return;
            currentPlayer.SetIsPlayer(false);
            player.SetIsPlayer(true);
            bots.RemoveOnIndex(random, currentPlayer);
            bots.RemoveOnIndex(random, player);
            bots.AddOnIndex(player,random);
            bots.AddOnIndex(currentPlayer, random);
            foreach (Player bot in bots.GetList())
            {
                Console.WriteLine(random);
                Console.WriteLine(bot.IsPlayer() + "-" + bot.id);
            }
        }
    }
}
