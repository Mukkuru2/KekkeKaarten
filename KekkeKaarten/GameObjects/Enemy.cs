using KekkeKaarten;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Enemy : RotatingSpriteGameObject
    {
        public Enemy() : base("spr_enemy")
        {
            position.X = (GameEnvironment.Screen.X - 300) - (sprite.Width / 2);
            position.Y = 300;
            this.Mirror = true;
        }


        public override void Reset()
        {
            base.Reset();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}