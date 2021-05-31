using SFML.Graphics;

namespace Agario
{
    class Omnivores : Fraction
    {
        public override void Init(Player player)
        {
            player.GetGO().OutlineColor = Color.Blue;
        }
        public override void TryEatFood(Player player, FoodList foodList)
        {
            base.TryEatFood(player, foodList);
        }
        public override float GetSpeedModifier()
        {
            return base.GetSpeedModifier();
        }
        public override void MoveToFood(Player player, FoodList foodList, float time, BotList botlist)
        {
            base.MoveToFood(player, foodList, time, botlist);
        }
        public override void EatAndRemoveBot(Player whoIsEating, Player whoWasEaten, BotList bots)
        {
            if (whoIsEating.GetFraction() is Herbivores)
                return;
            base.EatAndRemoveBot(whoIsEating, whoWasEaten, bots);
        }
        public override void Intersect(Player player, BotList bots)
        {
            base.Intersect(player, bots);
        }
    }
}
