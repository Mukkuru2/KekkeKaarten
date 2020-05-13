using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class MouseSprite : SpriteGameObject
    {
        public MouseSprite(): base("Sprites/cursor") { }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            position = inputHelper.MousePosition;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }
    }
    
}
