using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects.Enemies
{
    class EnemyMap : SpriteGameObject
    {
        protected Vector2 locationOnGrid;
        public int health;
        public int damage;
        public int timeToKill;
        public int enemyID;
        public EnemyMap(string assetName, Vector2 positionOnGrid) : base(assetName)
        {
            this.locationOnGrid = positionOnGrid;
        }

        public Vector2 LocationOnGrid { get => locationOnGrid; set => locationOnGrid = value; }

        public virtual void Move(Map map, Player player)
        {
            
        }
    }
}
