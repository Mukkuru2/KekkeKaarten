﻿using KekkeKaarten.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten.Collisions
{
    class CardCollision : GameObjectList
    {
        public bool drag = false;
        public bool hold = false;
        MouseSprite mouse;
        Enemy enemy;
        public CardCollision(MouseSprite mouse, Enemy enemy)
        {
            
            this.mouse = mouse;
            this.enemy = enemy;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.MouseLeftButtonDown())
            {
                drag = true;
            }
            else { drag = false; }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Card card in PlayingState.Cards.Children)
            {
                foreach (CardTexture cardTexture in card.cardTextures.Children)
                {

                    if (cardTexture.CollidesWith(mouse))
                    {

                        if (drag)
                        {
                            if (!hold)
                            {
                                card.drag = true;
                                hold = true;
                            }
                        }
                        else { card.drag = false; hold = false; }




                        if (!cardTexture.CardEnlarged)
                        {
                            cardTexture.CardEnlarged = true;
                            cardTexture.CardScalar = 1.2f;

                            PlayingState.SetCollisionMask(cardTexture);

                            Vector2 tempPos = cardTexture.Position;
                            tempPos.X -= cardTexture.Sprite.Width * 0.1f;
                            tempPos.Y -= cardTexture.Sprite.Height * 0.1f;
                            cardTexture.Position = tempPos;
                        }
                    }
                    else if (!cardTexture.CollidesWith(mouse))
                    {

                        if (cardTexture.CardEnlarged)
                        {
                            cardTexture.CardEnlarged = false;
                            cardTexture.CardScalar = 1;

                            PlayingState.SetCollisionMask(cardTexture);

                            Vector2 tempPos = cardTexture.Position;
                            tempPos.X += cardTexture.Sprite.Width * 0.1f;
                            tempPos.Y += cardTexture.Sprite.Height * 0.1f;
                            cardTexture.Position = tempPos;

                        }
                    }
                    if (card.drag)
                    {
                        card.Position = mouse.Position - new Vector2(40, 100);
                    }
                    else card.Position = card.ReturnLocation;

                    if (card.drag)
                    {
                        if (enemy.CollidesWith(cardTexture))
                        {
                            enemy.Position = new Vector2(0, -1000);
                            cardTexture.Position = cardTexture.ReturnLocation;
                            Console.WriteLine(cardTexture.Position);

                        }
                    }

                }


            }

        }
    }
}
