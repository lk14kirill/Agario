using SFML.System;


namespace Agario
{
    public class Bot : Player
    {
        public Bot()
        {
            SetRandomPosition(new Vector2f(Constants.windowX,Constants.windowY));
            SetSpeed(0.2f);
        }
        public void MoveToFood(FoodList foodList,float time)
        {
            Food target = new Food();
            float minDistance = 2000;
            foreach(Food food in foodList.food)
            {
                float tempDistance= MathExt.VectorLength(GetCenter(), food.GetCenter());
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    target = food;
                }
            }
            MoveToward(target.GetCenter(), time);
        }
    }
}
