using KekkeKaarten.GameState;
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

        private int walkTimer;
        private int walk = 12;
        private int stepsTaken = 0;

        private int cardStatuesTaken = 0;
        private bool canFightBoss = false;

        private Vector2 locationOnGrid, lastLocationOnGrid;

        public int CardStatuesTaken { get => cardStatuesTaken; set => cardStatuesTaken = value; }
        public Vector2 LocationOnGrid { get => locationOnGrid; set => locationOnGrid = value; }
        public Vector2 LastLocationOnGrid { get => lastLocationOnGrid; set => lastLocationOnGrid = value; }
        public bool CanFightBoss { get => canFightBoss; set => canFightBoss = value; }
        public int StepsTaken { get => stepsTaken; set => stepsTaken = value; }
        public int Walk { get => walk; set => walk = value; }

        public Player() : base(1) // in front of everything else
        {
            this.Add(up);
            this.Add(down);
            this.Add(left);
            this.Add(right);

            up.Visible = false;
            left.Visible = false;
            right.Visible = false;

            MovementDict.Add(Keys.Up, new Vector2(0, -1));
            MovementDict.Add(Keys.Down, new Vector2(0, 1));
            MovementDict.Add(Keys.Left, new Vector2(-1, 0));
            MovementDict.Add(Keys.Right, new Vector2(1, 0));

            walkTimer = walk;

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (walkTimer >= walk)
            {

                for (int i = 0; i < MovementDict.Count; i++)
                {
                    KeyValuePair<Keys, Vector2> kvp = MovementDict.ElementAt(i);
                    if (inputHelper.IsKeyDown(kvp.Key))
                    {
                        lastLocationOnGrid = locationOnGrid;
                        locationOnGrid += kvp.Value;
                        walkTimer = 0;
                        stepsTaken = 0;
                        OverWorld.Particle.ParticleGeneration(40, new Vector2(Position.X + 30, Position.Y + 30), "Sprites/particlegreen");
                        foreach (SpriteGameObject dir in this.children)
                        {
                            dir.Visible = false;
                        }

                        this.children.ElementAt(i).Visible = true;

                        break;
                    }
                }

                if (inputHelper.IsKeyDown(Keys.LeftShift))
                {
                    walk = 12;
                }
                else
                {
                    walk = 24;
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
