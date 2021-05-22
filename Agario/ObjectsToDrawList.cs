using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class ObjectsToDrawList
    {
        private List<Drawable> objectsToDraw = new List<Drawable>();
        public void Init()
        {
            Constants.createDelegate += AddFood;
            Constants.removeDelegate += RemoveFood;
        }
        public void AddFood(CircleObject circle)
        {
            objectsToDraw.Add(circle.GetGO());
        }
        public void RemoveFood(CircleObject circle)
        {
            objectsToDraw.Remove(circle.GetGO());
        }
        public void Add(Drawable drawable)
        {
            objectsToDraw.Add(drawable);
        }
        public void AddFoodList(List<Food> list)
        {
            foreach (Food food in list)
            {
                objectsToDraw.Add(food.gameObject);
            }
        }
        public List<Drawable> GetList() => objectsToDraw;
    }
}
