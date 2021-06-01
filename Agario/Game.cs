using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Agario
{
    class Game
        {
            private double time;
            private float totalTimeBeforeUpdate = 0f;
            private float previousTimeElapsed = 0f;
            private float deltaTime = 0f;
            private  float totalTimeElapsed = 0f;
            private static bool isGameEnded = false;
            public bool IsGameEnded() => isGameEnded;
            public static void GameEnded(bool s) => isGameEnded = s;

            private DrawableObjects drawableObjects = new DrawableObjects();
            private UpdatableObjects updatableObjects = new UpdatableObjects();
            private Clock clock = new Clock();
            private Controller controller = new Controller();
            private RenderWindow window = new RenderWindow(new VideoMode(Constants.windowX, Constants.windowY), "Game window");
            private PlayerText text = new PlayerText();

            private Vector2f direction;
            public void GameCycle()
            {
                Init();
                while (window.IsOpen /*&& !updatableObjects.GetPlayer().IsEaten()*/)
                {
                 DoCycleStep();
                }
            }
            private void Init()
            {
                WindowSetup();
                CreateObjects();
                PlayerText text = new PlayerText();
                Fabric.Instance.RegisterObject(updatableObjects,drawableObjects,text);
                text.Initialize(updatableObjects.GetPlayer().GetGO().OutlineColor);
            }
            private void DoCycleStep()
            {

           
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;
               if(totalTimeBeforeUpdate >= Constants.TIME_UNTIL_UPDATE)
               {
                 time = clock.ElapsedTime.AsMicroseconds();
                 clock.Restart();
                 time /= 800;                                              

                 window.Clear(Color.White);
                 window.DispatchEvents();

                 updatableObjects.Update(direction, updatableObjects.GetFood(), updatableObjects.GetBots(), (float)time,updatableObjects.GetPlayer());

                 Fabric.Instance.RemoveCachedObjectsAndCreateNew(updatableObjects, drawableObjects);

                 drawableObjects.Draw(window);
                 window.Display();
               }
              
            }
            private void OnKeyChangePlayer(object sender, KeyEventArgs e)
            {
                if (e.Code == Keyboard.Key.F)
                    controller.ChangePlayerAndReplaceBots(updatableObjects);
            }
            private void CreateObjects()
            {
               Fabric.Instance.CreateFood(updatableObjects, drawableObjects, 150);
               Fabric.Instance.CreatePlayer(updatableObjects,drawableObjects,true);
               Fabric.Instance.CreatePlayers(updatableObjects,drawableObjects,false,9);
            }
            private void WindowSetup()
            {
                window.MouseMoved += OnMouseMoved;
                window.Closed += WindowClosed;
                window.KeyPressed += OnKeyChangePlayer;
            }
            private void WindowUnsubscribe()
            {
                 window.MouseMoved -= OnMouseMoved;
                 window.Closed -= WindowClosed;
                 window.KeyPressed -= OnKeyChangePlayer;
            }
            public void OnMouseMoved(object sender, MouseMoveEventArgs e)
            {
                direction = new Vector2f(e.X, e.Y);
            }
            private void WindowClosed(object sender, EventArgs e)
            {
                RenderWindow w = (RenderWindow)sender;
                WindowUnsubscribe();
                w.Close();
            }
        
    }
}
