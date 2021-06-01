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
            int r = rand.Next(0, updatableObjects.GetBots().Count);
            int i = 0;
            foreach (Player bot in updatableObjects.GetBots())
            {
                if (i == r)
                {
                    player = bot;
                }
                i++;
            }
            ReplaceBotAndChangeStatus(currentPlayer,player);
            
        }
        private void ReplaceBotAndChangeStatus(Player currentPlayer,Player player)
        {
            if (currentPlayer == null || player == null)
                return;
            currentPlayer.SetIsPlayer(false);
            player.SetIsPlayer(true);
        }
    }
}
