using SFML.Graphics;
using System.Collections.Generic;

namespace Agario
{
    class DrawableObjects
    {
        public static List<IDrawable> drawableObjects = new List<IDrawable>();

        public void Remove(IDrawable drawable)
        {
            drawableObjects.Remove(drawable);
        }
        public void Add(IDrawable drawable)
        {
            drawableObjects.Add(drawable);
        }
        public void Draw(RenderWindow window)
        {
            foreach(IDrawable drawableObject in drawableObjects)
            {
                window.Draw(drawableObject.WhatToDraw());
            }
        }
        public static List<IDrawable> GetList() => drawableObjects;
    }
}
