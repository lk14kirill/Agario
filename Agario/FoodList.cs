using System.Collections.Generic;

namespace Agario
{
    public class FoodList
    {
        public delegate void RemoveDelegate(Food food);
        public static RemoveDelegate removeDelegate;
        public delegate void CreateDelegate(Food food);
        public static CreateDelegate createDelegate;
        public List<Food> food = new List<Food>();
        public void Create()
        {
            Food newFood = new Food();
            food.Add(newFood);
            createDelegate.Invoke(newFood);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Food newFood = new Food();
                food.Add(newFood);
                if(createDelegate != null)
                   createDelegate.Invoke(newFood);
            }
        }
        public  void RemoveFood(Food foodItem)
        {
            food.Remove(foodItem);
            if (removeDelegate != null)
                removeDelegate.Invoke(foodItem);
            Create();
        }
    }
}
