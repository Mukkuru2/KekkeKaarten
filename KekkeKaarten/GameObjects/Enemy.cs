﻿using KekkeKaarten;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Enemy : SpriteGameObject
    {
        public  int timeToKill = 5;
        public Vector2 returnPosition;
        public SpriteSheet[] sprites;
        public int health;
        public int returnhp;
        public int damage;
        public int enemyID;
        public int previousenemyID;

        public Enemy() : base("Sprites/Map/slime")
        {
            position.X = (GameEnvironment.Screen.X - 300) - (sprite.Width / 2);
            position.Y = 300;
            returnPosition = position;
            returnhp = health;

            this.Mirror = true;
            RunToPlayer();
            sprites = new SpriteSheet[4];
            sprites[0] = new SpriteSheet("Sprites/Map/slime");
            sprites[1] = new SpriteSheet("Sprites/Map/harpy");
            sprites[2] = new SpriteSheet("Sprites/Map/horse");
            sprites[3] = new SpriteSheet("Sprites/Map/boss");
        }

        public override void Reset()
        {
            base.Reset();
        }

        public void RunToPlayer()
        {
            velocity.X = (300 - position.X) / timeToKill;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (previousenemyID != enemyID)
            {
                RunToPlayer();
                sprite = sprites[enemyID];
                previousenemyID = enemyID;
            }
            if(health <= 0)
            {
                if (enemyID == 3)
                {
                    GameEnvironment.GameStateManager.SwitchTo("Winstate");
                }
                else
                {
                    GameEnvironment.GameStateManager.SwitchTo("Overworld");
                    health = returnhp;
                }
            }
    }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.O)) {
                GameEnvironment.GameStateManager.SwitchTo("Overworld");
                health = returnhp;
            }
        }
    }
}