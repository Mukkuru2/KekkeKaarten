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
using KekkeKaarten.GameState;
using KekkeKaarten.GameObjects.MapObjects.Enemies;

namespace KekkeKaarten
{
    class PlayingState : GameObjectList
    {

        public MouseSprite mouseSprite = new MouseSprite();
        ParticleSystem particleSystem;
        public CardCollision cardcollision;

        HealthBar healthBar = new HealthBar(new Vector2(166, 65), 5.0f);

        static Enemy enemy;
        Hand hand;
        PlayerFight player;
        static TextGameObject hp = new TextGameObject("SpriteFonts/GameFont");
        static public TextGameObject HP { get => hp; set => hp = value; }
        public static Enemy Enemy { get => enemy; set => enemy = value; }

        public PlayingState()
        {
            this.Add(new SpriteGameObject("Backgrounds/battlescreen"));
            this.Add(player = new PlayerFight(new Vector2(300, 300)));
            this.Add(enemy = new Enemy());
            this.Add(healthBar);
            this.Add(particleSystem = new ParticleSystem());
            this.Add(hand = new Hand());




            this.Add(mouseSprite);
            cardcollision = new CardCollision(mouseSprite, enemy, hand, player, particleSystem);
            this.Add(cardcollision);
            this.Add(hp);
            hp.Text = "" + PlayerFight.HP;

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

            healthBar.UpdateHp(PlayerFight.HP);

            if (PlayingState.HP.Text != "" + PlayerFight.HP){
                PlayingState.HP.Text = "" + PlayerFight.HP;
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            
            
        }

        public static void SetCollisionMask(CardTexture card)
        {
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