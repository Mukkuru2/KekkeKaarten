using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KekkeKaarten
{
    class PlayerFight : SpriteGameObject
    {
        public static int hp = 1;
        public static int HP { get => hp; set => hp = value; }
        public PlayerFight(Vector2 spawnposition) : base("Sprites/Map/player")
        {
            Position = spawnposition;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(hp <= 0)
            {
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
            }
        }
    }
}
