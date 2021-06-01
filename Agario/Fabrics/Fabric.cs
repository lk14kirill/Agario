using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class Fabric
    {
        private static Fabric instance;
        public static Fabric Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Fabric();
                }
                return instance;
            }
        }

        private List<IUpdatable> objectsToRemove = new List<IUpdatable>();
        public void AddToObjectsToRemove(IUpdatable updatable) => objectsToRemove.Add(updatable);
        public void RemoveCachedObjectsAndCreateNew(UpdatableObjects updatableObjects, DrawableObjects drawable)
        {
            foreach (IUpdatable updatable in objectsToRemove)
            {
                UnregisterObject(updatableObjects, drawable, updatable);
                if (updatable is Player)
                    CreatePlayer(updatableObjects, drawable, false);
                if (updatable is Food)
                    RegisterObject(updatableObjects, drawable, new Food());
            }

            objectsToRemove = new List<IUpdatable>();
        }
        public  void CreatePlayer(UpdatableObjects updatableObjects, DrawableObjects drawableObjects,bool isPlayer)
        {
            Player newPlayer = new Player();
            newPlayer.Init();
            newPlayer.SetIsPlayer(isPlayer);
            RegisterObject(updatableObjects, drawableObjects, newPlayer);
        }
        public  void CreatePlayers(UpdatableObjects updatableObjects, DrawableObjects drawableObjects,bool isPlayer,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                CreatePlayer(updatableObjects, drawableObjects, isPlayer);
            }
        }
        public void CreateFood(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Food food = new Food();
                RegisterObject(updatableObjects, drawableObjects, food);
            }
        }
        public void RegisterObject(UpdatableObjects updatableObjects,DrawableObjects drawableObjects,IUpdatable updatable)
        {
            if (updatable is IUpdatable)
                updatableObjects.Add(updatable);
            if (updatable is IDrawable)
                drawableObjects.Add(updatable as IDrawable);
        }
        public void UnregisterObject(UpdatableObjects updatableObjects, DrawableObjects drawableObjects, IUpdatable updatable)
        {
            if (updatable is IUpdatable)
                updatableObjects.Remove(updatable);
            if (updatable is IDrawable)
                drawableObjects.Remove(updatable as IDrawable);
        }
    }
}
