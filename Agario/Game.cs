using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Agario
{
    class Game
    {
        public double time;
        private int[] score = new int[2];
        private int[] scoreForText = new int[2];

        private FoodList foodList = new FoodList();
        private ObjectsToDrawList objectsToDraw = new ObjectsToDrawList();
        private Clock clock = new Clock();
        private RenderWindow window = new RenderWindow(new VideoMode(Constants.windowX, Constants.windowY), "Game window");
        private Player player = new Player();

        private Vector2f direction;
        private Bot bot = new Bot();
        public void GameCycle()
        {
            Init();
            while (window.IsOpen && score[0] != 10 && score[1] != 10)
            {
                Cycle();
            }
        }
        private void Init()
        {
            foodList.Create(100);
            WindowSetup();
            AddAllDrawableObjectsToList();
            objectsToDraw.Init();
        }
        private void Cycle()
        {
            time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time /= 800;                                              //for smoother movement of ball

            window.Clear(Color.White);
            window.DispatchEvents();
            Controller.EatFoodAndRemove(player, foodList);
            Controller.IntersectBetweenPlayers(player, bot);
            player.MoveToward(direction, window.Size, (float)time);


            DrawObjects();
            window.Display();
        }
        private void AddAllDrawableObjectsToList()
        {
            objectsToDraw.Add(player.GetGO());
            objectsToDraw.AddItemList(foodList.food);
            objectsToDraw.Add(bot.GetGO());
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
