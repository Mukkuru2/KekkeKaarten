using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Kaart : RotatingSpriteGameObject
    {
        private float scalar = 1;
        private const float scaleIncrease = 1.2f;

        public Kaart() : base("kaart")
        {
            position.X = 500;
            position.Y = 500;
        }

        public float CardScalar
        {
            get { return scalar; }
            set { scalar = value; }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, Color.White, Angle - MathHelper.ToRadians(offsetDegrees), Origin, scalar, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            
        }
    }
}
