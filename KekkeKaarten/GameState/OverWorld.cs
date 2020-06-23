using KekkeKaarten.GameManagement.MapLoading;
using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using KekkeKaarten.GameObjects.MapObjects.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameState
{
    class OverWorld : GameObjectList
    {
        private static ParticleSystem particle = new ParticleSystem();
        public static ParticleSystem Particle { get => particle; set => particle = value; }
        Player player = new Player();
        GameObjectList enemies;

        GameObjectList maps = StartState.Maps;
        Map currentMap;

        private Random _r = new Random();

        private bool enemyTurn = false;
        private float scrollspeed = 8.0f;

        public OverWorld() : base()
        {
            Reset();
            this.Add(enemies);
            this.Add(player);
            this.Add(particle);
        }

        public override void Reset()
        {
            base.Reset();
            SetMap("Overworld");
            GameEnvironment.AssetManager.SetVolume(0.4f);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
            if (inputHelper.KeyPressed(Keys.NumPad9))
            {
                GameEnvironment.GameStateManager.SwitchTo("Winstate");
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            scrollspeed = (float)player.Walk / 3 * 2;


            PlayerEnemyColision();
            CenterMap();
            PlayerWalk();

            PlayerEnemyColision();
        }
        private void PlayerEnemyColision()
        {
            for (int i = 0; i < enemies.Children.Count; i++)
            {
                EnemyMap enemy = (EnemyMap)enemies.Children[i];
                if (player.LocationOnGrid == enemy.LocationOnGrid)
                {
                    PlayingState.Enemy.timeToKill = enemy.timeToKill;
                    PlayingState.Enemy.damage = enemy.damage;
                    PlayingState.Enemy.health = enemy.health;
                    PlayingState.Enemy.enemyID = enemy.enemyID;

                    GameEnvironment.GameStateManager.SwitchTo("PlayingState");

                    GameEnvironment.AssetManager.PlaySound("Audio/Effects/roar");

                    enemies.Remove(enemy);
                    break;
                }
            }
        }

        private void SetMap(String id)
        {
            if (currentMap != null)
            {
                this.Remove(currentMap);
                this.Remove(enemies);
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

            enemies = new GameObjectList();
            enemies = currentMap.Enemies;
            foreach (EnemyMap enemy in enemies.Children)
            {
                enemy.Position = currentMap.Objects[(int)enemy.LocationOnGrid.X, (int)enemy.LocationOnGrid.Y].GlobalPosition;
            }

            this.Add(enemies);
            this.Add(currentMap);
        }

        private void FullCenterMap()
        {
            currentMap.Position = new Vector2(-(player.LocationOnGrid.X) * currentMap.CellWidth + GameEnvironment.Screen.X / 2, -(player.LocationOnGrid.Y) * currentMap.CellHeight + GameEnvironment.Screen.Y / 2);
        }

        private void CenterMap()
        {
            if (player.GlobalPosition.X <= 600)
            {
                MoveScreen(new Vector2(currentMap.CellWidth / scrollspeed, 0));
            }
            if (player.GlobalPosition.X >= GameEnvironment.Screen.X - 600)
            {
                MoveScreen(new Vector2(-currentMap.CellWidth / scrollspeed, 0));
            }
            if (player.GlobalPosition.Y <= 400)
            {
                MoveScreen(new Vector2(0, currentMap.CellWidth / scrollspeed));
            }
            if (player.GlobalPosition.Y >= GameEnvironment.Screen.Y - 400)
            {
                MoveScreen(new Vector2(0, -currentMap.CellWidth / scrollspeed));
            }
        }

        private void MoveScreen(Vector2 move)
        {foreach(ParticlePosition p in particle.Children)
            {
                p.Position += move;
            }
            
            currentMap.Position = currentMap.Position + move;
            player.Position = player.Position + move;
            foreach (EnemyMap enemy in enemies.Children)
            {
                enemy.Position = enemy.Position + move;
            }
        }

        private void PlayerWalk()
        {
            MapObject currentTile = (MapObject)currentMap.Objects[(int)(player.LocationOnGrid.X), (int)(player.LocationOnGrid.Y)];
            if (!currentTile.IsSolid)
            {
                if (player.StepsTaken == 0)
                {
                    if (_r.NextDouble() < 0.5)
                    {
                        GameEnvironment.AssetManager.PlaySound("Audio/Effects/walk1");
                    }
                    else
                    {
                        GameEnvironment.AssetManager.PlaySound("Audio/Effects/walk2");
                    }
                }
                if (player.StepsTaken < scrollspeed)
                {
                    player.Position = currentTile.GlobalPosition - (player.LocationOnGrid - player.LastLocationOnGrid) * (1 - ((player.StepsTaken + 1) / scrollspeed)) * currentMap.CellWidth;
                    player.StepsTaken++;
                    enemyTurn = true;
                }
                else
                {
                    EnemyMovement();
                }

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
        }

        private void EnemyMovement()
        {
            if (enemyTurn)
            {
                foreach (EnemyMap enemy in enemies.Children)
                {
                    enemy.StepsTaken = 0;
                    if (enemy.GlobalPosition.X + enemy.Sprite.Width > 0
                        && enemy.GlobalPosition.X - enemy.Sprite.Width < GameEnvironment.Screen.X
                        && enemy.GlobalPosition.Y + enemy.Sprite.Height > 0
                        && enemy.GlobalPosition.Y - enemy.Sprite.Height < GameEnvironment.Screen.X)
                    {
                        enemy.Move(currentMap, player);
                    }
                }
                enemyTurn = false;
            }
            foreach (EnemyMap enemy in enemies.Children)
            {
                if (enemy.StepsTaken < scrollspeed / 2)
                {
                    MapObject currentTile = (MapObject)currentMap.Objects[(int)(enemy.LocationOnGrid.X), (int)(enemy.LocationOnGrid.Y)];
                    enemy.Position = currentTile.GlobalPosition - (enemy.LocationOnGrid - enemy.LastLocationOnGrid) * (1 - ((enemy.StepsTaken + 1) / (scrollspeed / 2))) * currentMap.CellWidth;
                    enemy.StepsTaken++;
                }
            }
        }
    }
}
