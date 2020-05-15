using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KekkeKaarten.GameObjects.MapObjects
{
    public class MapObject : SpriteGameObject
    {
        protected bool isSolid;
        public MapObject(string assetName) : base(assetName)
        {
        }
    }
}