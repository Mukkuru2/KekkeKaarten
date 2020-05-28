using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects
{
    class ToxicFloor : MapObject
    {
        public ToxicFloor(String asset, Vector2 position) : base(asset)
        {
            this.position = position;
            IsSolid = true;
        }
    }
}
