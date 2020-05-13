using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects;

namespace KekkeKaarten
{
    class PlayingState : GameObjectList
    {
        public static GameObjectList Cards = new GameObjectList();
        public MouseSprite mouseSprite = new MouseSprite();
        public string[] numbers = new string[] { "1", "3", "4" };
        public CardCollision cardcollision;
        Enemy enemy;
        
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Backgrounds/battlescreen"));

            this.Add(enemy = new Enemy());
            this.Add(new HealthBar(new Vector2(166, 65)));

            this.Add(Cards);
            
            for (int i = 0; i < 3; i++)
            {
                Cards.Add(new Card(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500)));
                
            }

            this.Add(mouseSprite);
            cardcollision = new CardCollision(mouseSprite, enemy);
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