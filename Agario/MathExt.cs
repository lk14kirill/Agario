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

            if (distanceBetweenRadiuses <= firstCircle.GetRadius() + secondCircle.GetRadius() / 2)
            {
                return true;
            }
            return false;
        }

    }
}
