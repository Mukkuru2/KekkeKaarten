using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KekkeKaarten.GameObjects
{
    class Question : TextGameObject
    {
        
        public Question(string number) : base("SpriteFonts/GameFont")
        {
            Text = number;
            position.X = GameEnvironment.Screen.X / 4;
            position.Y = 100;
            Color = Color.Black;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.DrawString(spriteFont, text, GlobalPosition, color, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);
            }
        }


    }
}
