using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Slime : Enemy
    {
        public Slime() : base()
        {
            //HP = 75;
            //attack = 5;
            //second for attack = 6
        }
        public void Direction(GameObject player)
        {
            if (player.Position.X >= position.X)
            {
                velocity.X = 64;
            }
            if (player.Position.X < position.X)
            {
                velocity.X = -64;
            }
            if (player.Position.Y >= position.Y)
            {
                velocity.Y = 64;
            }
            if (player.Position.Y < position.Y)
            {
                velocity.Y = -64;
            }
        }
    }
}
