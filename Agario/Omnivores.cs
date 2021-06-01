using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class Omnivores : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Blue;
        }
        public override void TryEatFood(Player player, List<Food> foodList)
        {
            base.TryEatFood(player, foodList);
        }
        public override float GetSpeedModifier()
        {
            return base.GetSpeedModifier();
        }
        public override void MoveToFood(Player player, List<Food> foodList, float time, List<Player> bots)
        {
            base.MoveToFood(player, foodList, time, bots);
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating, whoWasEaten);
        }
        public override void Intersect(Player player, List<Player> bots)
        {
            base.Intersect(player, bots);
        }
    }
}
