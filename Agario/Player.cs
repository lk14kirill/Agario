using SFML.System;
using SFML.Graphics;
using System;


namespace Agario
{
    public interface IUpdatable
    {
        void Update();
    }
    public class Player : CircleObject
    {
        private bool isEaten;
        private float speedModifier = 1;
        private float weightModifier = 0.000025f;
        private Fraction fraction;
        private bool isPlayer = false;
        public Player()
        {
            gameObject.Radius = 10;
            SetRandomColor();
            gameObject.OutlineThickness =3;
            fraction = RandomFraction();
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
        } 
        public bool IsPlayer() => isPlayer;
        public void SetIsPlayer(bool s) => isPlayer = s;
        public Fraction GetFraction() => fraction;
        public bool IsEaten() => isEaten;
        public void SetIsEaten(bool s) => isEaten = s;
        private Fraction RandomFraction()
        {
            Random rand = new Random();
            switch (rand.Next(1, 4))
            {
                case 1:
                    return new Omnivores();
                case 2:
                    return new Herbivores();
                case 3:
                    return new Predators();
            }
            return new Omnivores();
        }

        public void LoseWeightAndChangeSpeed()
        {
            if (GetRadius() > 10 && weightModifier != 0)
            {
                SetRadius(GetRadius() - GetRadius() * weightModifier);
            }
            SetSpeed(8 / (GetRadius() * 1.2f) * speedModifier);
        }
        public void Update(Vector2f playerDirection,BotList bots,FoodList food,float time)
        {
            if (IsPlayer())
                MoveToward(playerDirection, time);
            else
                MoveToFood(food,time,bots);
            Intersect(bots);
            LoseWeightAndChangeSpeed();
            TryEatFood(food);
        }
        public void Intersect(BotList bots)
        {
            fraction.Intersect(this,bots);
        }
        public void Eat(CircleObject circle)
        {
            SetRadius(GetRadius() + circle.GetRadius() - 4);
        }
        public void Init()
        {
            fraction.Init(this);
            speedModifier = fraction.GetSpeedModifier();
            weightModifier = fraction.GetWeightModifier();
        }
        public void TryEatFood(FoodList foodlist)
        {
            fraction.TryEatFood(this, foodlist);
        }
        public void MoveToFood(FoodList foodlist, float time, BotList botlist)
        {
            if(!IsPlayer())
            fraction.MoveToFood(this, foodlist, time, botlist);
        }
    }
}
