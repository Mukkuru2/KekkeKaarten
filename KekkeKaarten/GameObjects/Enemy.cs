using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameObjects
{
    class Enemy : SpriteGameObject
    {
        public Enemy() : base("spr_Enemy")
        {
            position.X = (GameEnvironment.Screen.X / 2) - (sprite.Width / 2);
            position.Y = 300;
        }


        public override void Reset()
        {
            base.Reset();
        }
    }
}