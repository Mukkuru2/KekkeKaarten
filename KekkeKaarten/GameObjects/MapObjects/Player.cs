using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten.GameObjects.MapObjects
{
    class Player : GameObjectList
    {
        SpriteGameObject up = new SpriteGameObject("Sprites/playerup");
        SpriteGameObject down = new SpriteGameObject("Sprites/player");
        SpriteGameObject left = new SpriteGameObject("Sprites/playerleft");
        SpriteGameObject right = new SpriteGameObject("Sprites/playerright");
        int walktimer = 10;
        int walk = 10;
        public Vector2 loca;

        public Player() : base()
        {
            this.Add(up);
            this.Add(down);
            this.Add(left);
            this.Add(right);

            up.Visible = false;
            left.Visible = false;
            right.Visible = false;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (walktimer == walk)
            {
                if (inputHelper.IsKeyDown(Keys.Up))
                {
                    loca.Y--;
                    //position.Y -= 20;
                    up.Visible = true;
                    down.Visible = false;
                    left.Visible = false;
                    right.Visible = false;
                    walktimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Down))
                {
                    loca.Y++;
                    //position.Y += 20;
                    up.Visible = false;
                    down.Visible = true;
                    left.Visible = false;
                    right.Visible = false;
                    walktimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Left))
                {
                    loca.X--;
                    //position.X -= 20;
                    up.Visible = false;
                    down.Visible = false;
                    left.Visible = true;
                    right.Visible = false;
                    walktimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Right))
                {
                    loca.X++;
                    //position.X += 20;
                    up.Visible = false;
                    down.Visible = false;
                    left.Visible = false;
                    right.Visible = true;
                    walktimer = 0;
                }
            }
            else walktimer++;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
