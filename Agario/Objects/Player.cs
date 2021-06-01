using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace Agario
{
    public class Player : CircleObject,IUpdatable,IDrawable
    {
        public int id;
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
                    return new Omnivore();
                case 2:
                    return new Herbivore();
                case 3:
                    return new Predator();
            }
            return new Omnivore();
        }

        public void LoseWeightAndChangeSpeed()
        {
            if (GetRadius() > 10 && weightModifier != 0)
            {
                SetRadius(GetRadius() - GetRadius() * 0.00023f * weightModifier);
            }
            SetSpeed(8 / (GetRadius() * 1.2f) * speedModifier);
        }
        public void Update(Vector2f playerDirection,List<Player> bots,List<Food> food,float time,Player player)
        {
            if (IsPlayer())
                MoveToward(playerDirection, time);
            else
                MoveToFood(food,time,bots);
            Intersect(bots);
            LoseWeightAndChangeSpeed();
            TryEatFood(food);
        }
        public Drawable WhatToDraw()
        {
            return GetGO();
        }
        public void Intersect(List<Player> bots)
        {
            fraction.Intersect(this,bots);
        }
      
        public void Init()
        {
            fraction.Init(this);
            speedModifier = fraction.GetSpeedModifier();
            weightModifier = fraction.GetWeightModifier();
        }
        public void TryEatFood(List<Food> foodlist)
        {
            fraction.TryEatFood(this, foodlist);
        }
        public void MoveToFood(List<Food> foodlist, float time, List<Player> bots)
        {
            if(!IsPlayer())
            fraction.MoveToFood(this, foodlist, time, bots);
        }
    }
}
