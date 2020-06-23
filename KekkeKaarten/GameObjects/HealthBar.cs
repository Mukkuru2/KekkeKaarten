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
        private float maxWidth = 1.0f;

        public HealthBar(Vector2 startposition, float maxWidth) : base("Sprites/health")
        {
            position = startposition;
            this.maxWidth = maxWidth;
        }

        public void UpdateHp(int hp) {
            scalar.X = hp / 100.0f * maxWidth;
            hpColor = new Color(hp / 100 * 255, 1 - (hp / 100 * 255), 0);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, hpColor, Angle - MathHelper.ToRadians(offsetDegrees), Origin, scalar, SpriteEffects.None, 0);

        }
    }
}
