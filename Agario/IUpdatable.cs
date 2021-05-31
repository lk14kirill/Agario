using SFML.System;
using System.Collections.Generic;


namespace Agario
{
    public interface IUpdatable
    {
        void Update(Vector2f playerDirection, List<Player> bots, FoodList food, float time);
    }
}
