using KekkeKaarten.GameManagement.MapLoading;
using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameState
{
    class OverWorld : GameObjectList
    {
        Player player = new Player();
        GameObjectList maps = StartState.Maps;
        int currentMove , enemyTotal = 0;
        
        public OverWorld() : base()
        {

            this.Add(maps);
            this.Add(player);

            foreach (Map map in maps.Children)
            {
                player.locationOnGrid = map.PlayerSpawn;
                FullCenterMap(map);
                player.Position = map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].GlobalPosition;
                player.lastLocationOnGrid = player.locationOnGrid;
            }
            foreach (GameObject obj in children)
            {
                if (obj is Player || obj is Enemy)
                {
                    enemyTotal++;
                }
            }
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }
        public override void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            int movementCounter = 0;
            bool canMove = true;

            foreach (GameObject obj in children)
            {
                if (obj is Player || obj is Enemy)
                {
                    if (movementCounter == currentMove && canMove == true)
                    {
                        canMove = false;
                        currentMove++;
                    }
                    movementCounter++;

                }
                else
                {
                    obj.Update(gameTime);
                }
            }
            if (currentMove == enemyTotal)
            {
                currentMove = 0;
            }

            if (!(player.lastLocationOnGrid == player.locationOnGrid))
            {
                foreach (Map map in maps.Children)
                {
                    MapObject currentTile = (MapObject)map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)];
                    if (!currentTile.IsSolid)
                    {
                        player.Position = map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].GlobalPosition;
                        player.lastLocationOnGrid = player.locationOnGrid;
                    }
                    else
                    {
                        player.locationOnGrid = player.lastLocationOnGrid;
                    }
                    CenterMap(map);
                }

            }


        }

        private void FullCenterMap(GameObjectGrid map)
        {
            map.Position = new Vector2(-(player.locationOnGrid.X - 10) * map.CellWidth, -(player.locationOnGrid.Y - 10) * map.CellHeight);
        }

        private void CenterMap(GameObjectGrid map)
        {
            if (player.GlobalPosition.X <= 600)
            {
                map.Position = map.Position + new Vector2(map.CellWidth, 0);
                player.Position = player.Position + new Vector2(map.CellWidth, 0);
            }
            else if (player.GlobalPosition.X >= GameEnvironment.Screen.X - 600)
            {
                map.Position = map.Position + new Vector2(-map.CellWidth, 0);
                player.Position = player.Position + new Vector2(-map.CellWidth, 0);
            }
            else if (player.GlobalPosition.Y <= 400)
            {
                map.Position = map.Position + new Vector2(0, map.CellHeight);
                player.Position = player.Position + new Vector2(0, map.CellHeight);
            }
            else if (player.GlobalPosition.Y >= GameEnvironment.Screen.Y - 400)
            {
                map.Position = map.Position + new Vector2(0, -map.CellHeight);
                player.Position = player.Position + new Vector2(0, -map.CellHeight);
            }
        }
    }
}
