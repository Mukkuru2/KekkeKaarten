using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace KekkeKaarten.GameObjects.MapObjects
{
    class Player : GameObjectList
    {
        private readonly Dictionary<Keys, Vector2> MovementDict = new Dictionary<Keys, Vector2>();

        SpriteGameObject up = new SpriteGameObject("Sprites/Map/playerup");
        SpriteGameObject down = new SpriteGameObject("Sprites/Map/player");
        SpriteGameObject left = new SpriteGameObject("Sprites/Map/playerleft");
        SpriteGameObject right = new SpriteGameObject("Sprites/Map/playerright");
        
        private int walkTimer = 10;
        private int walk = 10;

        private int cardStatuesTaken = 0;
        private bool canFightBoss = false;

        private Vector2 locationOnGrid, lastLocationOnGrid;

        public int CardStatuesTaken { get => cardStatuesTaken; set => cardStatuesTaken = value; }
        public Vector2 LocationOnGrid { get => locationOnGrid; set => locationOnGrid = value; }
        public Vector2 LastLocationOnGrid { get => lastLocationOnGrid; set => lastLocationOnGrid = value; }
        public bool CanFightBoss { get => canFightBoss; set => canFightBoss = value; }

        public Player() : base(1) // in front of everything else
        {
            this.Add(up);
            this.Add(down);
            this.Add(left);
            this.Add(right);

            up.Visible = false;
            left.Visible = false;
            right.Visible = false;

            MovementDict.Add(Keys.Up, new Vector2(0 , -1));
            MovementDict.Add(Keys.Down, new Vector2(0 , 1));
            MovementDict.Add(Keys.Left, new Vector2(-1, 0));
            MovementDict.Add(Keys.Right, new Vector2(1 , 0));
            
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (walkTimer == walk)
            {

                for(int i = 0; i < MovementDict.Count; i++)
                {
                    KeyValuePair<Keys, Vector2> kvp = MovementDict.ElementAt(i);
                    if (inputHelper.IsKeyDown(kvp.Key))
                    {
                        lastLocationOnGrid = locationOnGrid;
                        locationOnGrid += kvp.Value;
                        walkTimer = 0;

                        foreach (SpriteGameObject dir in this.children) {
                            dir.Visible = false;
                        }

                        this.children.ElementAt(i).Visible = true;

                        break;
                    }
                }

                /*
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
                */
            }
            else walkTimer++;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
