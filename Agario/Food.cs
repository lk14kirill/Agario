using SFML.System;
using SFML.Graphics;
using System;

namespace Agario
{
    public class Food : CircleObject
    {
        public Food()
        {
            SetRandomPosition(new Vector2f(Constants.windowX,Constants.windowY));
            SetRandomColor();
            SetRadius(5);
        }
       
    }
}
