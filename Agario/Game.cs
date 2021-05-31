﻿using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

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

            private FoodList food = new FoodList();
            private ObjectsToDrawList drawableObjects = new ObjectsToDrawList();
            private BotList bots = new BotList();
            private Clock clock = new Clock();
            private Controller controller = new Controller();
            private RenderWindow window = new RenderWindow(new VideoMode(Constants.windowX, Constants.windowY), "Game window");
            private Player player = new Player();

            private Vector2f direction;
            public void GameCycle()
            {
                Init();
                while (window.IsOpen && !player.IsEaten())
                {
                    DoCycleStep();
                }
            }
            private void Init()
            {
                WindowSetup();
                AddAllDrawableObjectsToList();
                player.Init();
                player.SetIsPlayer(true);
                InitializeLists();
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
                 time /= 800;                                              //for smoother movement of ball

                 window.Clear(Color.White);
                 window.DispatchEvents();
 
                 player.Update(direction, bots, food, (float)time);
                 bots.UpdateBots(direction, food, bots, (float)time);

                 bots.RemoveCachedBots();

                 drawableObjects.Draw(window);
                 window.Display();
               }
              
            }
            private void OnKeyChangePlayer(object sender, KeyEventArgs e)
            {
                if (e.Code == Keyboard.Key.F)
                    player = controller.ChangePlayerAndReplaceBots(player, bots);
            }
            private void AddAllDrawableObjectsToList()
            {
                drawableObjects.Add(player.GetGO());
            }
            private void InitializeLists()
            {
               drawableObjects.Init();
               bots.Init();
               food.Init();
               bots.Create(9);
               food.Create(150);
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
                bots.Unsubscribe();
                food.Unsubscribe();
                drawableObjects.Unsubscribe();
                w.Close();
            }
        
    }
}
