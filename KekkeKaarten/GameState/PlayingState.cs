using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using KekkeKaarten.GameObjects;
using Centipede.GameObjects;

namespace KekkeKaarten
{
    class PlayingState : GameObjectList
    {
        private GameObjectList Cards = new GameObjectList();
        private GameObjectList cardText = new GameObjectList();
        private MouseSprite mouseSprite = new MouseSprite();
        public string[] numbers = new string[] { "1", "3", "4" };
        public bool drag = false;
        public PlayingState()
        {
            this.Add(new SpriteGameObject("spr_battle_screen"));

            this.Add(new Enemy());
            this.Add(new HealthBar(new Vector2(166, 65)));

            this.Add(Cards);
            this.Add(cardText);
            for (int i = 0; i < 3; i++)
            {
                Cards.Add(new Card(new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 800)));
                cardText.Add(new CardText(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 800)));
            }

            this.Add(mouseSprite);


        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
            }

            if (inputHelper.MouseLeftButtonDown())
            {
                drag = true;
            }
            else { drag = false; }


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Card card in Cards.Children) {
                if (card.CollidesWith(mouseSprite)) 
                    
                {
                    if(drag)
                    {
                        card.Position = mouseSprite.Position - new Vector2(40,200);
                    } 
                    else { card.Position = card.ReturnLocation;  }
                   
                    
                    if(!card.CardEnlarged)
                    {
                        card.CardEnlarged = true;
                        card.CardScalar = 1.2f;

                        SetCollisionMask(card);

                        Vector2 tempPos = card.Position;
                        tempPos.X -= card.Sprite.Width * 0.1f;
                        tempPos.Y -= card.Sprite.Height * 0.1f;
                       
                    }
                    
                    
                }
                else if(!card.CollidesWith(mouseSprite))
                    
                    {
                    if(card.CardEnlarged)
                    {
                        card.CardEnlarged = false;
                        card.CardScalar = 1;

                        SetCollisionMask(card);

                        Vector2 tempPos = card.Position;
                        tempPos.X += card.Sprite.Width * 0.1f;
                        tempPos.Y += card.Sprite.Height * 0.1f;
                        card.Position = card.ReturnLocation;
                    }
                }
            }


        }
        private void SetCollisionMask(Card card) {
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