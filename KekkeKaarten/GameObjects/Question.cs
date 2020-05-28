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
            position.Y = 200;
            Color = Color.Black;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }


    }
}
