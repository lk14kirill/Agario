using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class PlayerFabric
    {
        private static List<Player> botsToRemove = new List<Player>();
        public static void AddToBotsToRemove(Player player) => botsToRemove.Add(player);
        public void RemoveCachedBots(UpdatableObjects updatable,DrawableObjects drawable)
        {
            foreach (Player player in botsToRemove)
            {
                UnregisterPlayer(updatable,drawable,player);
            }
            CreatePlayers(updatable, drawable, false, botsToRemove.Count);
            botsToRemove = new List<Player>();
        }
        public  void CreatePlayer(UpdatableObjects updatableObjects, DrawableObjects drawableObjects,bool isPlayer)
        {
            Player newPlayer = new Player();
            newPlayer.Init();
            newPlayer.SetIsPlayer(isPlayer);
            RegisterPlayer(updatableObjects, drawableObjects, newPlayer);
        }
        public  void CreatePlayers(UpdatableObjects updatableObjects, DrawableObjects drawableObjects,bool isPlayer,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                CreatePlayer(updatableObjects, drawableObjects, isPlayer);
            }
        }
        private void RegisterPlayer(UpdatableObjects updatableObjects,DrawableObjects drawableObjects,Player player)
        {
            if (player is IUpdatable)
                updatableObjects.Add(player);
            if (player.GetGO() is Drawable)
                drawableObjects.Add(player.GetGO());
        }
        private void UnregisterPlayer(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, Player player)
        {
            if (player is IUpdatable)
                updatableObjects.Remove(player);
            if (player.GetGO() is Drawable)
                drawableObjects.Remove(player.GetGO());
        }
    }
}
