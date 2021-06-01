using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agario
{
    public class PlayerText:IDrawable,IUpdatable
    {
        private Text text = new Text();
        public Text GetText() => text;
        public void Initialize(Color color)
        {
            text.FillColor = color;
            text.Position = new Vector2f(0, 0);
            text.CharacterSize = 60;
            Font font = new Font(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\font.ttf");
            text.Font = font;
            text.DisplayedString = "10";
        }
        public void Update(Vector2f direction,List<Player> players,List<Food> food,float time,Player player)
        {
            if(player != null)
            {
                string newText = "Fraction-" +player.GetFraction().ToString() + "\n"+Math.Round(player.GetRadius()).ToString();
                newText = newText.Replace("Agario.", "");
                text.DisplayedString = newText;
                text.FillColor = player.GetGO().OutlineColor;
            }        
            else
                text.DisplayedString = "Dead";
        } 
        public Drawable WhatToDraw()
        {
            return text;
        }
    }
}
