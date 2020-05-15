﻿using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using Microsoft.Xna.Framework;
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

        private const int tileLength = 64;

        public int[,] map;
        private Vector2 spawn;
        public Map(int[,] mapData) : base(mapData.GetLength(0), mapData.GetLength(1))
        {
            this.map = mapData;
            Reset();
        }

        public Vector2 Spawn { get => spawn; set => spawn = value; }

        public override void Reset()
        {
            for (int yMap = 0; yMap < map.GetLength(0); yMap++)
            {
                for (int xMap = 0; xMap < map.GetLength(1); xMap++)
                {
                    Vector2 position = new Vector2(tileLength * xMap, tileLength * yMap);

                    //the ints on the map represent a gameobject, the specifics 
                    switch (map[xMap, yMap])
                    {
                        case 0:
                            grid[xMap, yMap] = new Wall("Sprites/Map/wall", position);
                            break;
                        case 1:
                            grid[xMap, yMap] = new Floor("Sprites/Map/floor", position);
                            break;
                        case 2:
                            grid[xMap, yMap] = new Floor("Sprites/Map/floor", position);
                            //Player.location = this location
                            spawn = new Vector2(xMap, yMap);
                            break;
                        case 3:
                            grid[xMap, yMap] = new GoldenStatue("Sprites/Map/floor", position);
                            break;
                        case 4:
                            grid[xMap, yMap] = new BossRoomTeleport("Sprites/Map/floor", position);
                            break;
                        case 5:
                            grid[xMap, yMap] = new Marshland("Sprites/Map/floor", position);
                            break;
                        case 6:
                            grid[xMap, yMap] = new ToxicFloor("Sprites/Map/floor", position);
                            break;
                        default:
                            grid[xMap, yMap] = new Wall("Sprites/Map/wall", position);
                            break;
                    }
                }
            }
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
