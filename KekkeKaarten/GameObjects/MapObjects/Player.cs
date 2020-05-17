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
        
        int walkTimer = 10;
        int walk = 10;
        public Vector2 locationOnGrid, lastLocationOnGrid;

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
            if (walkTimer == walk)
            {
                if (inputHelper.IsKeyDown(Keys.Up))
                {
                    lastLocationOnGrid = locationOnGrid;
                    locationOnGrid.Y--;
                    up.Visible = true;
                    down.Visible = false;
                    left.Visible = false;
                    right.Visible = false;
                    walkTimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Down))
                {
                    lastLocationOnGrid = locationOnGrid;
                    locationOnGrid.Y++;
                    up.Visible = false;
                    down.Visible = true;
                    left.Visible = false;
                    right.Visible = false;
                    walkTimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Left))
                {
                    lastLocationOnGrid = locationOnGrid;
                    locationOnGrid.X--;
                    up.Visible = false;
                    down.Visible = false;
                    left.Visible = true;
                    right.Visible = false;
                    walkTimer = 0;
                }
                if (inputHelper.IsKeyDown(Keys.Right))
                {
                    lastLocationOnGrid = locationOnGrid;
                    locationOnGrid.X++;
                    up.Visible = false;
                    down.Visible = false;
                    left.Visible = false;
                    right.Visible = true;
                    walkTimer = 0;
                }
            }
            else walkTimer++;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
