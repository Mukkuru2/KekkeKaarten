using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using KekkeKaarten.GameObjects.MapObjects.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{

    class Map : GameObjectGrid
    {
        private GameObjectList enemies = new GameObjectList();

        private int[,] map;
        private Vector2 playerSpawn;
        public Map(int[,] mapData) : base(mapData.GetLength(0), mapData.GetLength(1))
        {
            this.map = mapData;
            cellWidth = 64;
            cellHeight = 64;
            Reset();
        }

        public Vector2 PlayerSpawn { get => playerSpawn; set => playerSpawn = value; }
        public GameObjectList Enemies { get => enemies; set => enemies = value; }

        public override void Reset()
        {
            visible = false;
            for (int yMap = 0; yMap < map.GetLength(0); yMap++)
            {
                for (int xMap = 0; xMap < map.GetLength(1); xMap++)
                {
                    Vector2 position = new Vector2(cellWidth * xMap, cellHeight * yMap);

                    //the ints on the map represent a gameobject, the specifics can be found in LoadMaps
                    switch (map[xMap, yMap])
                    {
                        case 0:
                            Add(new Wall("Sprites/Map/wall", position), xMap, yMap);
                            break;
                        case 1:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            break;
                        case 2:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            //Player.location = this location
                            playerSpawn = new Vector2(xMap, yMap);
                            break;
                        case 3:
                            Add(new GoldenStatue("Sprites/Map/statue", position), xMap, yMap);
                            break;
                        case 4:
                            Add(new BossRoomTeleport("Sprites/Map/teleporter", position), xMap, yMap);
                            break;
                        case 5:
                            Add(new Marshland("Sprites/Map/swamp", position), xMap, yMap);
                            break;
                        case 6:
                            Add(new ToxicFloor("Sprites/Map/toxic", position), xMap, yMap);
                            break;
                        case 7:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            enemies.Add(new ChessHorse(new Vector2(xMap, yMap)));
                            break;
                        case 8:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            enemies.Add(new Slime(new Vector2(xMap, yMap)));
                            break;
                        case 9:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            enemies.Add(new Harpy(new Vector2(xMap, yMap)));
                            break;
                        case 10:
                            Add(new Floor("Sprites/Map/grass", position), xMap, yMap);
                            enemies.Add(new Boss(new Vector2(xMap, yMap)));
                            break;
                        default:
                            Add(new Wall("Sprites/Map/wall", position), xMap, yMap);
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
