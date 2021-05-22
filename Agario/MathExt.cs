using System;
using SFML.System;
using System.Collections.Generic;


namespace Agario
{
    public static class MathExt
    {
        public static float VectorLength(Vector2f firstVector, Vector2f secondVector)
        {
            return (float)Math.Sqrt(Math.Pow(secondVector.X - firstVector.X, 2) +
                                    Math.Pow(secondVector.Y - firstVector.Y, 2));
        }
        public static float GetPercentOf(float value, float percent)
        {
            return value / 100 * percent;
        }
        public static bool CheckForIntersect(CircleObject firstCircle, CircleObject secondCircle)     //Ricochets first circle
        {
            double distanceBetweenRadiuses = VectorLength(secondCircle.GetCenter(), firstCircle.GetCenter()); ;

            if (distanceBetweenRadiuses <= firstCircle.GetRadius() + secondCircle.GetRadius())
            {
                return true;
            }
            return false;
        }
       
        public static (Vector2f, Vector2f) CreateGates(Vector2u window, bool upside)
        {
            float xPos1 = window.X / 2 - GetPercentOf(window.X, 10), xPos2 = window.X / 2 + GetPercentOf(window.X, 10);
            Vector2f firstPoint, secondpoint;
            switch (upside)
            {
                case true:
                    float yPos1 = 0 + GetPercentOf(window.Y, 2.01f);
                    firstPoint = secondpoint = new Vector2f(xPos1, yPos1);
                    secondpoint.X = xPos2;
                    return (firstPoint, secondpoint);
                    break;
                case false:
                    float yPos2 = window.Y - GetPercentOf(window.Y, 2.01f);
                    firstPoint = secondpoint = new Vector2f(xPos1, yPos2);
                    secondpoint.X = xPos2;
                    return (firstPoint, secondpoint);
                    break;
            }
        }
        public static bool IsVectorBiggerThenWindowY(CircleObject circle, Vector2u window)
        {
            if (circle.GetCenter().Y - circle.GetRadius() > GetPercentOf(window.Y, 50))
                return true;
            return false;
        }
    }
}
