using SFML.System;
using SFML.Graphics;
using System;

namespace Agario
{
    public class CircleObject
    {
        private bool canMove = true;
        private float speed = 1;
        public CircleShape gameObject = new CircleShape();

        public void SetBoolCanMove(bool a) => canMove = a;
        public bool GetCanMove() => canMove;
        public void SetPosition(Vector2f vector)
        {
            if (canMove)
                gameObject.Position = new Vector2f(vector.X - GetRadius(), vector.Y - GetRadius());
        }
        public Vector2f GetPosition() => new Vector2f(gameObject.Position.X, gameObject.Position.Y);
        public Vector2f GetCenter() => new Vector2f(gameObject.Position.X + gameObject.Radius, gameObject.Position.Y + gameObject.Radius);
        public void SetRadius(float radius) => gameObject.Radius = radius;
        public float GetRadius() => gameObject.Radius;
        public CircleShape GetGO() => gameObject;
        public float GetSpeed() => speed;
        public void SetSpeed(float tempSpeed) => speed = tempSpeed;
        public void SetRandomPosition(Vector2f window)
        {
            Random rand = new Random();
            Vector2f vector = new Vector2f(rand.Next(0, (int)window.X),rand.Next(0, (int)window.Y));
            SetPosition(vector);
        }
        public void SetRandomColor()
        {
            Random rand = new Random();
            Color color = new Color((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256));
            gameObject.FillColor = color;
        }
        public void Destroy() => this.Destroy();
        public void MoveToward(Vector2f direction, float time)
        {
            if (direction != new Vector2f(0, 0) && GetCanMove())
            {
                float distance = MathExt.VectorLength(direction, GetCenter());
                if (distance >2)
                {
                    Vector2f directionTemp = new Vector2f(speed * time * (direction.X - GetCenter().X) / distance,
                                      speed * time * (direction.Y - GetCenter().Y) / distance);
                    gameObject.Position += directionTemp;
                }
            }
        }
    }
}
