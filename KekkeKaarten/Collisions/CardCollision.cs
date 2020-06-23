using KekkeKaarten.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using KekkeKaarten.CSVhandling;
using KekkeKaarten.GameState;

namespace KekkeKaarten.Collisions
{
    class CardCollision : GameObjectList
    {
        public bool drag = false;
        public bool hold = false;
        public bool StopHolding = false; // i dont know why
        bool hit = false;
        bool wronghit = false;

        MouseSprite mouse;
        Enemy enemy;
        Hand hand;
        PlayerFight player;
        ParticleSystem particleSystem;
        QuestionCounter answeredcorrectly;  
        
        private static string difficulty;
        public static string Difficulty { get => difficulty; set => difficulty = value; }
        public CardCollision(MouseSprite mouse, Enemy enemy, Hand hand, PlayerFight player, ParticleSystem particleSystem, QuestionCounter answeredcorrectly)
        {

            this.mouse = mouse;
            this.enemy = enemy;
            this.hand = hand;
            this.player = player;
            this.particleSystem = particleSystem;
            this.answeredcorrectly = answeredcorrectly;
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

            if (player.CollidesWith(enemy))
            {
                PlayerFight.HP -= enemy.damage;
                
                enemy.Position = enemy.returnPosition;
                particleSystem.ParticleGeneration(40, new Vector2(player.Position.X +(player.Width/2), player.Position.Y + (player.Height / 2)), "Sprites/particlered");

            }
            foreach (Card card in Hand.Cards.Children)
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
                    else
                    {
                        card.Position = card.ReturnLocation;

                    }

                    if (card.drag)
                    {
                        if (card.rightAnswer)
                        {
                            if (enemy.CollidesWith(cardTexture))
                            {
                                //enemy.Position = new Vector2(0, -1000);
                                card.Position = card.ReturnLocation;
                                Console.WriteLine(cardTexture.Position);
                                card.drag = false;
                                hit = true;
                                card.ChangeLocation();
                                enemy.running = false;
                                enemy.ThrowPosition = enemy.Position;
                                //enemy.toplocationX = (enemy.returnPosition.X + enemy.Position.X) / 2;
                                //enemy.Velocity = new Vector2(20, 0);
                                answeredcorrectly.getScore++;   
                                int multiplier = int.Parse(Difficulty);
                                WinState.Correct = "" + answeredcorrectly.getScore;
                                WinState.Points += multiplier * 10;
                            }
                        }
                        if (!card.rightAnswer)
                        {
                            if (enemy.CollidesWith(cardTexture))
                            {
                                card.drag = false;
                                card.remove = true;
                                if (Hand.numberOfCards == 3)
                                {
                                    PlayerFight.hp -= enemy.damage;
                                    wronghit = false;


                                }
                                else
                                {
                                    wronghit = true;
                                }

                                enemy.running = false;
                                enemy.Velocity = new Vector2(20, 0);
                                enemy.ThrowPosition = enemy.Position;



                            }
                        }
                    }

                }


            }
            if (hit)
            {
                hand.DeleteCards();
                if (Hand.numberOfCards < 6)
                {
                    Hand.numberOfCards++;
                }
                enemy.health -= 25;

                hand.ChangeCards();
                foreach (Card card in Hand.Cards.Children)
                {
                    particleSystem.ParticleGeneration(40, new Vector2(card.Position.X, card.Position.Y), "Sprites/particlegray");
                }
                hit = false;
            }
            if (wronghit)
            {
                
                hand.cardDelete();
                Hand.numberOfCards--;
              

                wronghit = false;
            }
        }
    }
}
