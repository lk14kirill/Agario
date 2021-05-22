using SFML.System;
using SFML.Graphics;


namespace Agario
{
    public class Player : CircleObject
    {
        private bool isAlive = true;
        public bool IsAlive() => isAlive;
        public void SetBoolAlive(bool s)
        {
            isAlive = s;
            if (!isAlive)
                Destroy();
        }
        public Player()
        {
            gameObject.Radius = 10;
            SetRandomColor();
            SetSpeed(0.25f);
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
    public class Bot : Player
    {

    }
}
