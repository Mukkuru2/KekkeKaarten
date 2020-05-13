using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Map : GameObjectGrid
    {
        int[,] map;
        public Map(int[,] mapData) : base(mapData.GetLength(0), mapData.GetLength(1))
        {
            this.map = mapData;
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            for (int yMap = 0; yMap < map.GetLength(0); yMap++)
            {
                for (int xMap = 0; xMap < map.GetLength(1); xMap++)
                {
                    switch (map[xMap, yMap]) {
                        case 0:
                            grid[xMap, yMap] = new Wall();
                            break;
                        case 1:
                            grid[xMap, yMap] = new Floor();
                            break;
                        case 2:
                            grid[xMap, yMap] = new Floor();
                            //Player.location = this location
                            break;
                        case 3:
                            grid[xMap, yMap] = new GoldenStatue();
                            break;
                        case 4:
                            grid[xMap, yMap] = new BossRoomTeleport();
                            break;
                        case 5:
                            grid[xMap, yMap] = new Marshland();
                            break;
                        case 6:
                            grid[xMap, yMap] = new ToxicFloor();
                            break;
                        default:
                            grid[xMap, yMap] = new Wall();
                            break;
                    }
                }
            }
        }
    }
}
