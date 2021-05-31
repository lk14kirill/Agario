using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class ObjectsToDrawList
    {
        private List<Drawable> drawableObjects = new List<Drawable>();
        public void Init()
        {
            Constants.CircleCreated += AddCircle;
            Constants.CircleRemoved += Remove;
        }
        public void Unsubscribe()
        {
            Constants.CircleCreated -= AddCircle;
            Constants.CircleRemoved -= Remove;
        }
        public void AddCircle(CircleObject circle)
        {
            drawableObjects.Add(circle.GetGO());
        }
        public void Remove(CircleObject circle)
        {
            drawableObjects.Remove(circle.GetGO());
        }
        public void Add(Drawable drawable)
        {
            drawableObjects.Add(drawable);
        }
        public void AddFoodList(List<Food> list)
        {
            foreach (Food food in list)
            {
                drawableObjects.Add(food.gameObject);
            }
        }
        public void Draw(RenderWindow window)
        {
            foreach(Drawable drawableObject in drawableObjects)
            {
                window.Draw(drawableObject);
            }
        }
        public List<Drawable> GetList() => drawableObjects;
    }
}
