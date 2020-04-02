using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class MouseSprite : SpriteGameObject
    {
        public MouseSprite(): base("cursor") { }
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
