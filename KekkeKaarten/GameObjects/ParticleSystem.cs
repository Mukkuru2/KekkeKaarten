using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten.GameObjects
{
    class ParticleSystem : GameObjectList
    {
        Random random = new Random();
        public ParticleSystem() : base()
        {

        }
        public override void Reset()
        {
            base.Reset();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.children.Count - 1 >= 0)
            {

                for (int i = this.children.Count - 1; i >= 0; i--)
                {
                    ParticlePosition yamum = (ParticlePosition)this.Children.ElementAt(i);

                    if (yamum.timer <= 0)
                    {
                        this.Remove(this.Children.ElementAt(i));
                    }
                }
            }

        }
        
        public void ParticleGeneration(int totalParticles, Vector2 partPos, string sprite)
        {
            this.Add(new ParticlePosition(partPos));
            ParticlePosition yamum = (ParticlePosition)this.Children.ElementAt(this.Children.Count - 1);
            for (int i = 0; i <= totalParticles; i++)
            {
                yamum.Add(new Particle(new Vector2(random.Next(-50, 50), random.Next(-50, 50)), sprite));
            }
        }
       
    }
}
