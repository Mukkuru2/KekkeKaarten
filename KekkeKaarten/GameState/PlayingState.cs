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
        private GameObjectList Cards = new GameObjectList();
        private MouseSprite mouseSprite = new MouseSprite();
        public string[] numbers = new string[] { "1", "3", "4" };
        public bool drag = false;
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Backgrounds/battlescreen"));

            this.Add(new Enemy());
            this.Add(new HealthBar(new Vector2(166, 65)));

            this.Add(Cards);
            
            for (int i = 0; i < 3; i++)
            {
                Cards.Add(new Card(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500)));
                
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
            foreach (Card card in Cards.Children)
            {
                foreach (CardTexture cardTexture in card.cardTextures.Children)
                {
                    
                    if (cardTexture.CollidesWith(mouseSprite))
                    {
                         
                        if (drag)
                        {
                            card.drag = true;
                            
                        }
                        else { card.drag = false; }


                        if (!cardTexture.CardEnlarged)
                        {
                            cardTexture.CardEnlarged = true;
                            cardTexture.CardScalar = 1.2f;

                            SetCollisionMask(cardTexture);

                            Vector2 tempPos = cardTexture.Position;
                            tempPos.X -= cardTexture.Sprite.Width * 0.1f;
                            tempPos.Y -= cardTexture.Sprite.Height * 0.1f;
                            cardTexture.Position = tempPos;
                        }
                    }
                    else if (!cardTexture.CollidesWith(mouseSprite))
                    {
                        
                        if (cardTexture.CardEnlarged)
                        {
                            cardTexture.CardEnlarged = false;
                            cardTexture.CardScalar = 1;

                            SetCollisionMask(cardTexture);

                            Vector2 tempPos = cardTexture.Position;
                            tempPos.X += cardTexture.Sprite.Width * 0.1f;
                            tempPos.Y += cardTexture.Sprite.Height * 0.1f;
                            cardTexture.Position = tempPos;
                        }
                    }
                    if (card.drag)
                    {
                        card.Position = mouseSprite.Position - new Vector2(40, 100);
                    }
                    else card.Position = card.ReturnLocation;
                }
            }
        }
        private void SetCollisionMask(CardTexture card) {
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