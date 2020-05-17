using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KekkeKaarten.GameObjects.MapObjects
{
    public class MapObject : SpriteGameObject
    {
        private bool isSolid;
        public MapObject(string assetName) : base(assetName)
        {
        }

        public bool IsSolid { get => isSolid; set => isSolid = value; }
    }
}