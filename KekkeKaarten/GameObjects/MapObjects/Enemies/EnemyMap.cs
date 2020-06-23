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
        
        public int health;
        public int damage;
        public int timeToKill;
        public int enemyID;
        private int stepsTaken = 0;
        protected Vector2 locationOnGrid, lastLocationOnGrid;

        public EnemyMap(string assetName, Vector2 positionOnGrid) : base(assetName, 1)
        {
            this.locationOnGrid = positionOnGrid;
            this.lastLocationOnGrid = locationOnGrid;
        }

        public Vector2 LocationOnGrid { get => locationOnGrid; set => locationOnGrid = value; }
        public Vector2 LastLocationOnGrid { get => lastLocationOnGrid; set => lastLocationOnGrid = value; }
        public int StepsTaken { get => stepsTaken; set => stepsTaken = value; }

        public virtual void Move(Map map, Player player) {
            lastLocationOnGrid = locationOnGrid;
        }
    }
}
