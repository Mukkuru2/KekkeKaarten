using KekkeKaarten;
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
        private Vector2 throwPosition;
        private float maxHeight = 300;

        public SpriteSheet[] sprites;
        public int health;
        public int returnhp;
        public int damage;
        public int enemyID;
        public int previousenemyID;
        public bool running = true;
        public float toplocationY = 0;
        public float toplocationX = 0;

        public Vector2 ThrowPosition { get => throwPosition; set => throwPosition = value; }

        public Enemy() : base("Sprites/Map/slime")
        {
            position.X = (GameEnvironment.Screen.X - 300) - (sprite.Width / 2);
            position.Y = 500;
            returnPosition = position;
            returnhp = health;

            this.Mirror = true;
            RunToPlayer();
            sprites = new SpriteSheet[4];
            sprites[0] = new SpriteSheet("Sprites/Map/slime");
            sprites[1] = new SpriteSheet("Sprites/Map/harpy");
            sprites[2] = new SpriteSheet("Sprites/Map/horse");
            sprites[3] = new SpriteSheet("Sprites/Map/bossBlanc");
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

            if(!running)
            {
                float c = -throwPosition.X + returnPosition.X;
                position.X += 20;
                position.Y = 750.0f / (float)Math.Pow(c, 2) * (float)Math.Pow(position.X - (throwPosition.X + c / 2), 2) + maxHeight;

                if(position.X >= returnPosition.X)
                {
                    position.Y = 500;
                    RunToPlayer();
                    running = true;
                }
            }
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