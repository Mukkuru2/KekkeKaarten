using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten.GameObjects
{
    class HealthBar : RotatingSpriteGameObject
    {
        private Vector2 scalar = Vector2.One;
        private Color hpColor = new Color(255, 0, 0);
        private float maxHeight = 1.0f;

        public HealthBar(Vector2 startposition, float maxheight) : base("Sprites/health")
        {
            position = startposition;
            this.maxHeight = maxheight;
            origin = new Vector2(0, sprite.Height);
        }

        public void UpdateHp(float hp) {
            scalar.Y = hp / 100.0f * maxHeight;
            int red = (int)((100 - hp) / 50.0f * 255);
            int green = (int)((hp) / 50.0f * 255);
            hpColor = new Color(red,green,0);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, hpColor, Angle - MathHelper.ToRadians(offsetDegrees), Origin, scalar, SpriteEffects.None, 0);

        }
    }
}
