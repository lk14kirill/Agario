using System.Collections.Generic;

namespace Agario
{
    public class Controller
    {
        public static void EatFoodAndRemove(Player firstCircle,FoodList foodList)     //Ricochets first circle
        {
            foreach (Food food in foodList.food)
            {
                double distanceBetweenRadiuses = MathExt.VectorLength(food.GetCenter(), firstCircle.GetCenter()); ;

                if (distanceBetweenRadiuses <= firstCircle.GetRadius() + food.GetRadius())
                {
                   foodList.RemoveFood(food);
                    firstCircle.Eat(food);
                    return;
                }
            }
        }
        public static void IntersectBetweenPlayers(Player first,Player second) 
        {
                double distanceBetweenRadiuses = MathExt.VectorLength(first.GetCenter(), second.GetCenter()); ;
                if (distanceBetweenRadiuses <= first.GetRadius() + second.GetRadius())
                {
                   if(first.GetRadius() > second.GetRadius()+MathExt.GetPercentOf(second.GetRadius(),10))
                   {
                    first.Eat(second);
                    second.SetBoolAlive(false);
                   }
                   if(first.GetRadius()+MathExt.GetPercentOf(first.GetRadius(),10)< second.GetRadius())
                   {
                    second.Eat(first);
                    first.SetBoolAlive(false);
                   }
                    return;
                }
        }
    }
}
