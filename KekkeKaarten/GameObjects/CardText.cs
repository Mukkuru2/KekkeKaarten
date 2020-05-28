﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KekkeKaarten.GameObjects
{
    class CardText : TextGameObject
    {
        
        public CardText(string number, Vector2 startPosition) : base("SpriteFonts/GameFont")
        {
            Text = number;
            position.X  = startPosition.X + 90;
            position.Y = startPosition.Y + 70;
            Color = Color.Black;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
