using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Card : RotatingSpriteGameObject
    {
        private float scalar = 1;
        private bool enlarged = false;

        public Card(Vector2 startPosition) : base("Spr_Cards")
        {
            position = startPosition;
        }

        public float CardScalar
        {
            get { return scalar; }
            set { scalar = value; }
        }

        public bool CardEnlarged {
            get { return enlarged; }
            set { enlarged = value; }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, Color.White, Angle - MathHelper.ToRadians(offsetDegrees), Origin, scalar, SpriteEffects.None, 0);
        }

        public override Rectangle BoundingBox
        {
            get
            {
                int left = (int)(GlobalPosition.X - origin.X);
                int top = (int)(GlobalPosition.Y - origin.Y);
                return new Rectangle(left, top, (int)(Width * scalar), (int)(Height * scalar));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            
        }
    }
}
