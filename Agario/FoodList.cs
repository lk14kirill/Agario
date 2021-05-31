using System.Collections.Generic;

namespace Agario
{
    public class FoodList
    {
        private delegate void OnRemoved();
        OnRemoved onRemoved;
        public List<Food> food = new List<Food>();
        public void Init()
        {
            onRemoved += Create;
        }
        public void Unsubscribe()
        {
            onRemoved -= Create;
        }
        public void Create()
        {
            Food newFood = new Food();
            food.Add(newFood);
            Constants.CircleCreated.Invoke(newFood);
        }
        public void Create(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Food newFood = new Food();
                food.Add(newFood);
                if (Constants.CircleCreated != null)
                    Constants.CircleCreated.Invoke(newFood);
            }
        }
        public  void RemoveFood(Food foodItem)
        {
            food.Remove(foodItem);
            if (Constants.CircleRemoved != null)
                Constants.CircleRemoved.Invoke(foodItem);
            if (onRemoved != null)
                onRemoved.Invoke();
        }
    }
}
