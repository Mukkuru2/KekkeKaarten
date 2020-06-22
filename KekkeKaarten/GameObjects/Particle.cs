using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Particle : SpriteGameObject
    {
        
        public Particle(Vector2 velocity) : base("Sprites/particle")
        {
            this.velocity = velocity;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
