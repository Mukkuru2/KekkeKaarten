using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects.Enemies
{
    class Boss : EnemyMap
    {

        public Boss(Vector2 positionOnGrid) : base("Sprites/Map/boss", positionOnGrid)
        {
            damage = 20;
            health = 500;
            timeToKill = 10;
            enemyID = 3;
        }

        public override void Move(Map map, Player player)
        {
        }
    }
}
