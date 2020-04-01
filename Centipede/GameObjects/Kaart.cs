using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Kaart : SpriteGameObject
    {
        Kaart(): base("Kaart")
        {
            position.X = 500;
            position.Y = 500;
        
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
