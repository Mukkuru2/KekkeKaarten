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
        Map currentMap;

        int currentMove, enemyTotal = 0;

        public OverWorld() : base()
        {
            SetMap("Overworld");
            this.Add(player);

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
            base.Update(gameTime);

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

                MapObject currentTile = (MapObject)currentMap.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)];
                if (!currentTile.IsSolid)
                {
                    player.Position = currentTile.GlobalPosition;
                    player.lastLocationOnGrid = player.locationOnGrid;

                    if (currentTile is GoldenStatue)
                    {
                        //set bool taken for that specific statue to true, add +1 golden card to player
                    }
                    if (currentTile is BossRoomTeleport)
                    {
                        SetMap("BossRoom");
                    }
                }
                else
                {
                    player.locationOnGrid = player.lastLocationOnGrid;
                }
                CenterMap();

            }


        }

        private void SetMap(String id)
        {
            if (currentMap != null)
            {
                this.Remove(currentMap);
            }
            switch (id)
            {
                case "Overworld":
                    currentMap = (Map)maps.Children.ElementAt(0);
                    break;
                case "BossRoom":
                    currentMap = (Map)maps.Children.ElementAt(1);
                    break;
                default:
                    break;

            }
            player.locationOnGrid = currentMap.PlayerSpawn;
            FullCenterMap();
            player.Position = currentMap.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].GlobalPosition;
            player.lastLocationOnGrid = player.locationOnGrid;
            this.Add(currentMap);
        }

        private void FullCenterMap()
        {
            currentMap.Position = new Vector2(-(player.locationOnGrid.X) * currentMap.CellWidth + GameEnvironment.Screen.X / 2, -(player.locationOnGrid.Y) * currentMap.CellHeight + GameEnvironment.Screen.Y / 2);
        }

        private void CenterMap()
        {
            while (player.GlobalPosition.X <= 600)
            {
                currentMap.Position = currentMap.Position + new Vector2(currentMap.CellWidth, 0);
                player.Position = player.Position + new Vector2(currentMap.CellWidth, 0);
            }
            while (player.GlobalPosition.X >= GameEnvironment.Screen.X - 600)
            {
                currentMap.Position = currentMap.Position + new Vector2(-currentMap.CellWidth, 0);
                player.Position = player.Position + new Vector2(-currentMap.CellWidth, 0);
            }
            while (player.GlobalPosition.Y <= 400)
            {
                currentMap.Position = currentMap.Position + new Vector2(0, currentMap.CellHeight);
                player.Position = player.Position + new Vector2(0, currentMap.CellHeight);
            }
            while (player.GlobalPosition.Y >= GameEnvironment.Screen.Y - 400)
            {
                currentMap.Position = currentMap.Position + new Vector2(0, -currentMap.CellHeight);
                player.Position = player.Position + new Vector2(0, -currentMap.CellHeight);
            }
        }
    }
}
