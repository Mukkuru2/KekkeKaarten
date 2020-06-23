using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Objectives : TextGameObject
    {
        private int currentObjective = 0;
        private String[] objectives = {
        "Collect three golden card statues!",
        "Go through to portals to defeat the demon lord!"
        };

        public int CurrentObjective { get => currentObjective; set => currentObjective = value; }

        public Objectives() : base("SpriteFonts/GameFont")
        {
            position.X = 50;
            position.Y = 50;
            Color = new Color(247, 152, 98);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Text = objectives[currentObjective];
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.DrawString(spriteFont, text, GlobalPosition, color, 0.0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
