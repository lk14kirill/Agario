using System.Collections.Generic;

namespace Agario
{
    public class FoodList
    {
       
        public List<Food> food = new List<Food>();
        public void Create()
        {
            Food newFood = new Food();
            food.Add(newFood);
            Constants.createDelegate.Invoke(newFood);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Food newFood = new Food();
                food.Add(newFood);
                if (Constants.createDelegate != null)
                    Constants.createDelegate.Invoke(newFood);
            }
        }
        public  void RemoveFood(Food foodItem)
        {
            food.Remove(foodItem);
            if (Constants.removeDelegate != null)
                Constants.removeDelegate.Invoke(foodItem);
            Create();
        }
    }
}
