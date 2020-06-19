using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class ParticlePosition : GameObjectList
    {
        public int timer = 50;
        public ParticlePosition(Vector2 position) : base()
        {

            this.position = position;

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(timer > 0)
            {
                timer--;
            }
        }
    }
}
