using KekkeKaarten.GameManagement.MapLoading;
using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using KekkeKaarten.GameObjects.MapObjects.Enemies;
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
        GameObjectList enemies;

        GameObjectList maps = StartState.Maps;
        Map currentMap;

        private bool enemyTurn = false;

        public OverWorld() : base()
        {
            Reset();
            this.Add(enemies);
            this.Add(player);

        }

        public override void Reset()
        {
            base.Reset();
            SetMap("BossRoom");
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

            playerEnemyColision();


            if (enemyTurn == true)
            {
                foreach (EnemyMap enemy in enemies.Children)
                {
                    if (enemy.GlobalPosition.X + enemy.Sprite.Width > 0
                        && enemy.GlobalPosition.X - enemy.Sprite.Width < GameEnvironment.Screen.X
                        && enemy.GlobalPosition.Y + enemy.Sprite.Height > 0
                        && enemy.GlobalPosition.Y - enemy.Sprite.Height < GameEnvironment.Screen.X)
                    {
                        enemy.Move(currentMap, player);
                    }
                    enemy.Position = currentMap.Objects[(int)enemy.LocationOnGrid.X, (int)enemy.LocationOnGrid.Y].GlobalPosition;
                }
                enemyTurn = false;
            }

            if (!(player.LastLocationOnGrid == player.LocationOnGrid))
            {

                MapObject currentTile = (MapObject)currentMap.Objects[(int)(player.LocationOnGrid.X), (int)(player.LocationOnGrid.Y)];
                if (!currentTile.IsSolid)
                {
                    player.Position = currentTile.GlobalPosition;
                    player.LastLocationOnGrid = player.LocationOnGrid;

                    enemyTurn = true;

                    if (currentTile is GoldenStatue)
                    {
                        player.CardStatuesTaken++;
                        GoldenStatue statue = (GoldenStatue)currentTile;
                        statue.Taken = true;
                        if (player.CardStatuesTaken >= 3)
                        {
                            player.CardStatuesTaken = 0;
                            player.CanFightBoss = true;
                        }
                    }
                    if (currentTile is BossRoomTeleport)
                    {
                        if (player.CanFightBoss)
                        {
                            SetMap("BossRoom");
                        }
                    }
                }
                else
                {
                    player.LocationOnGrid = player.LastLocationOnGrid;
                }
                CenterMap();
            }
            playerEnemyColision();
        }
        private void playerEnemyColision()
        {
            for (int i = 0; i < enemies.Children.Count; i++)
            {
                EnemyMap enemy = (EnemyMap)enemies.Children[i];
                foreach (SpriteGameObject player in player.Children)
                {
                    if (player.CollidesWith(enemy))
                    {

                        

                        if (PlayingState.Enemy.enemyID != enemy.enemyID)
                        {
                            PlayingState.Enemy.timeToKill = enemy.timeToKill;
                            PlayingState.Enemy.damage = enemy.damage;
                            PlayingState.Enemy.health = enemy.health;
                            PlayingState.Enemy.enemyID = enemy.enemyID;

                        }
                        GameEnvironment.GameStateManager.SwitchTo("PlayingState");

                        enemies.Remove(enemy);
                        break;
                    }
                }
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

            player.LocationOnGrid = currentMap.PlayerSpawn;
            FullCenterMap();
            player.Position = currentMap.Objects[(int)(player.LocationOnGrid.X), (int)(player.LocationOnGrid.Y)].GlobalPosition;
            player.LastLocationOnGrid = player.LocationOnGrid;

            enemies = currentMap.Enemies;
            foreach (EnemyMap enemy in enemies.Children)
            {
                enemy.Position = currentMap.Objects[(int)enemy.LocationOnGrid.X, (int)enemy.LocationOnGrid.Y].GlobalPosition;
            }

            this.Add(currentMap);
        }

        private void FullCenterMap()
        {
            currentMap.Position = new Vector2(-(player.LocationOnGrid.X) * currentMap.CellWidth + GameEnvironment.Screen.X / 2, -(player.LocationOnGrid.Y) * currentMap.CellHeight + GameEnvironment.Screen.Y / 2);
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
