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
        public PlayingState()
        {
            this.Add(new SpriteGameObject("BackGround"));

            this.Add(new Enemy());

            this.Add(Cards);
            this.Add(cardText);
            for (int i = 0; i < 3; i++)
            {
                Cards.Add(new Card(new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500)));
                cardText.Add(new CardText(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500)));
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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Card card in Cards.Children) {
                if (card.CollidesWith(mouseSprite) &&
                    !card.CardEnlarged)
                {
                    card.CardEnlarged = true;
                    card.CardScalar = 1.2f;
                    Vector2 tempPos = card.Position;
                    tempPos.X -= card.Sprite.Width * 0.1f;
                    tempPos.Y -= card.Sprite.Height * 0.1f;
                    card.Position = tempPos;
                }
                else if (!card.CollidesWith(mouseSprite) &&
                    card.CardEnlarged) 
                {
                    card.CardEnlarged = false;
                    card.CardScalar = 1;
                    Vector2 tempPos = card.Position;
                    tempPos.X += card.Sprite.Width * 0.1f;
                    tempPos.Y += card.Sprite.Height * 0.1f;
                    card.Position = tempPos;
                }
            }
        }
    }
}