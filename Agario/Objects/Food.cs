using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace Agario
{
    public class Food : CircleObject,IUpdatable,IDrawable
    {
        public Food()
        {
            SetRandomPosition(new Vector2f(Constants.windowX,Constants.windowY));
            SetRandomColor();
            SetRadius(5);
        }
        public void Update(Vector2f direction,List<Player> players,List<Food> food,float time,Player player)
        {

        }
        public Drawable WhatToDraw()
        {
           return GetGO();
        }
    }
}
