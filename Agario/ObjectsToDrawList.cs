using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class ObjectsToDrawList
    {
        private List<Drawable> objectsToDraw = new List<Drawable>();
        public void Init()
        {
            FoodList.createDelegate += AddFood;
            FoodList.removeDelegate += RemoveFood;
        }
        public void AddFood(Food food)
        {
            objectsToDraw.Add(food.GetGO());
        }
        public void RemoveFood(Food food)
        {
            objectsToDraw.Remove(food.GetGO());
        }
        public void Add(Drawable drawable)
        {
            objectsToDraw.Add(drawable);
        }
        public void AddItemList(List<Food> list)
        {
            foreach (Food food in list)
            {
                objectsToDraw.Add(food.gameObject);
            }
        }
        public List<Drawable> GetList() => objectsToDraw;
    }
}
