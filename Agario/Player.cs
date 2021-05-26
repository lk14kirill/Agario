using SFML.System;
using SFML.Graphics;


namespace Agario
{
    public class Player : CircleObject
    {
        private bool isEaten;
        public bool IsEaten() => isEaten;
        public void SetIsEaten(bool s) => isEaten = s;
        public Player()
        {
            gameObject.Radius = 10;
            SetRandomColor();
            gameObject.OutlineThickness = 1;
            gameObject.OutlineColor = Color.Black;
        }
        public void LoseWeightAndChangeSpeed()
        {
            if(GetRadius() > 10)
            {
                SetRadius(GetRadius() - GetRadius() * 0.000025f);
            }
            SetSpeed(8 / (GetRadius()*1.2f));
        }
        public void TryEatFood( FoodList foodList)
        {
            foreach (Food food in foodList.food)
            {
                if (MathExt.CheckForIntersect(this, food))
                {
                    foodList.RemoveFood(food);
                    if(GetRadius() <400)
                    this.Eat(food);
                    return;
                }
            }
        }
        public void Eat(CircleObject circle)
        {
            SetRadius(GetRadius() + circle.GetRadius()-4);
        }
        public void MoveToFood(FoodList foodList, float time)
        {
            Food target = new Food();
            float minDistance = 2000;
            foreach (Food food in foodList.food)
            {
                float tempDistance = MathExt.VectorLength(GetCenter(), food.GetCenter());
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    target = food;
                }
            }
            MoveToward(target.GetCenter(), time);
        }
        public void BotInit()
        {
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
            SetSpeed(0.2f);
        }
    }
}
