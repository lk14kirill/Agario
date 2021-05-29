using SFML.System;
using SFML.Graphics;
using System;


namespace Agario
{
    public class Player : CircleObject
    {
        private bool isEaten;
        private float speedModifier = 1;
        private Fraction fraction;
        public void SetFractionOmniVores() => fraction = new Omnivores();
        public Fraction GetFraction() => fraction;
        public bool IsEaten() => isEaten;
        public void SetIsEaten(bool s) => isEaten = s;
        public Player()
        {
            gameObject.Radius = 10;
            SetRandomColor();
            gameObject.OutlineThickness =3;
            fraction = RandomFraction();
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
        }
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
            if (GetRadius() > 10)
            {
                SetRadius(GetRadius() - GetRadius() * 0.000025f);
            }
            SetSpeed(8 / (GetRadius() * 1.2f) * speedModifier);
        }
     
        public void Intersect(Player player,BotList bots)
        {
            fraction.Intersect(player,bots);
        }
        public void Eat(CircleObject circle)
        {
            SetRadius(GetRadius() + circle.GetRadius() - 4);
        }
        public void Init()
        {
            fraction.Init(this);
            speedModifier = fraction.GetModifier();
        }
        public void TryEatFood(FoodList foodlist)
        {
            fraction.TryEatFood(this, foodlist);
        }
        public void MoveToFood(FoodList foodlist, float time, BotList botlist)
        {
            fraction.MoveToFood(this, foodlist, time, botlist);
        }
    }
}
