using SFML.System;
using SFML.Graphics;


namespace Agario
{
    public class Player : CircleObject
    {
        public Player()
        {
            gameObject.Radius = 10;
            SetRandomColor();
            SetSpeed(0.25f);
            gameObject.OutlineThickness = 1;
            gameObject.OutlineColor = Color.Black;
        }
        public void GoToStartPoint(Vector2u window)
        {
            SetPosition(new Vector2f(window.X / 2, window.Y/2));
        }
        public void Eat(CircleObject circle)
        {
            SetRadius(GetRadius() + circle.GetRadius()-4);
            SetSpeed(GetSpeed() - MathExt.GetPercentOf(GetSpeed(), 1));
        }
        
    }
}
