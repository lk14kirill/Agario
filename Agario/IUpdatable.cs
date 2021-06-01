using SFML.System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Agario
{
    public interface IUpdatable
    {
        void Update(Vector2f playerDirection, List<Player> bots, List<Food> food, float time,Player player);
    }
    public interface IDrawable
    {
        Drawable WhatToDraw();
    }
}
