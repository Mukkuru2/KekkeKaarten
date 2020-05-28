using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects
{
    class BossRoomTeleport : GameObjectList
    {
        SpriteGameObject cardNotCollected = new SpriteGameObject("Sprites/Map/statue");
        SpriteGameObject cardCollected = new SpriteGameObject("Sprites/Map/statue2");

        public BossRoomTeleport(String asset, Vector2 position) : base()
        {
            this.position = position;
            this.Add(cardNotCollected);
            this.Add(cardNotCollected);

        }
    }
}
