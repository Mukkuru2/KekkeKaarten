using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Kaart : SpriteGameObject
    {
        public Kaart(): base("kaart")
        {
            position.X = 500;
            position.Y = 500;
            
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.MousePosition.X >= position.X && inputHelper.MousePosition.X <= position.X + sprite.Width &&
                inputHelper.MousePosition.Y >= position.Y && inputHelper.MousePosition.Y <= position.Y + sprite.Height) {
                position.Y = 500; 
            }
            else {
                position.Y = 600;
                    }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }
    }
}
