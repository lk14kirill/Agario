using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Agario
{
    class Game
    {
        public double time;
        private static bool isGameEnded = false;
        public bool IsGameEnded() => isGameEnded;
        public static void GameEnded(bool s) => isGameEnded = s;

        private FoodList foodList = new FoodList();
        private ObjectsToDrawList objectsToDraw = new ObjectsToDrawList();
        private BotList botlist = new BotList();
        private Clock clock = new Clock();
        private Controller controller = new Controller();
        private RenderWindow window = new RenderWindow(new VideoMode(Constants.windowX, Constants.windowY), "Game window");
        private Player player = new Player();

        private Vector2f direction;
        public void GameCycle()
        {
            Init();
            while (window.IsOpen && !isGameEnded)
            {
                Cycle();
            }
        }
        private void Init()
        {
            WindowSetup();
            AddAllDrawableObjectsToList();
            player.gameObject.OutlineColor = Color.Red;
            objectsToDraw.Init();
            foodList.Init();
            botlist.Init();
            botlist.Create(7);
            foodList.Create(100);
        }
        private void Cycle()
        {
            time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time /= 800;                                              //for smoother movement of ball

            window.Clear(Color.White);
            window.DispatchEvents();

            controller.TryEatFood(player, foodList);
            controller.TryEatFood(botlist, foodList);

            controller.IntersectBetweenBots(botlist);
            controller.IntersectBetweenPlayers(player, botlist);

            player.MoveToward(direction, (float)time);
            botlist.MoveBotsToFood(foodList, (float)time);

            DrawObjects();
            window.Display();
        }
        private void AddAllDrawableObjectsToList()
        {
            objectsToDraw.Add(player.GetGO());

        }
        private void DrawObjects()
        {
            foreach (Drawable shape in objectsToDraw.GetList())
            {
                window.Draw(shape);
            }
        }
        private void WindowSetup()
        {
            window.MouseMoved += OnMouseMoved;
            window.Closed += WindowClosed;
            //window.SetMouseCursorVisible(false);
        }
        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            direction = new Vector2f(e.X, e.Y);
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}
