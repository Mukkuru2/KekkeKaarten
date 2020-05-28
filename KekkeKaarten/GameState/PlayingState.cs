using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using KekkeKaarten.GameObjects;
using KekkeKaarten.Collisions;

namespace KekkeKaarten
{
    class PlayingState : GameObjectList
    {
  
        public MouseSprite mouseSprite = new MouseSprite();
    
        public CardCollision cardcollision;

        Enemy enemy;
        Hand hand;
        PlayerFight player;
        
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Backgrounds/battlescreen"));
            this.Add(player = new PlayerFight(new Vector2(300,300)));
            this.Add(enemy = new Enemy());;
            this.Add(new HealthBar(new Vector2(166, 65)));

            this.Add(hand = new Hand());



            this.Add(mouseSprite);
            cardcollision = new CardCollision(mouseSprite, enemy, hand, player);
            this.Add(cardcollision);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
            }

       


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            

        }

        public static void SetCollisionMask(CardTexture card) {
            Color[] colorData = new Color[card.Sprite.Sprite.Width * card.Sprite.Sprite.Height];
            bool[] tempCollisionMask = new bool[(int)(card.Sprite.Sprite.Width * card.Sprite.Sprite.Height * Math.Pow(card.CardScalar, 2))];
            card.Sprite.Sprite.GetData(colorData);
            for (int i = 0; i < colorData.Length; ++i)
            {
                tempCollisionMask[(int)(i * card.CardScalar)] = colorData[i].A != 0;
            }
            card.Sprite.CollisionMask = tempCollisionMask;
        }
    }
}