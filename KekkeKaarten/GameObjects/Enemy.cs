using KekkeKaarten;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Enemy : RotatingSpriteGameObject
    {
        private int timeToKill = 5;
        public Vector2 returnPosition;
       
        public Enemy() : base("Sprites/enemy")
        {
            position.X = (GameEnvironment.Screen.X - 300) - (sprite.Width / 2);
            position.Y = 300;
            returnPosition = position;

            this.Mirror = true;
            RunToPlayer();
         
        }

        public override void Reset()
        {
            base.Reset();
        }

        public void RunToPlayer()
        {
            velocity.X = (300 - position.X) / timeToKill;
        }

       

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}