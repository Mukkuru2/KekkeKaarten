using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects
{
    class GoldenStatueOff : MapObject
    {
        public GoldenStatueOff(Vector2 position) : base("Sprites/Map/statue2")
        {
            this.position = position;
        }
    }
}
