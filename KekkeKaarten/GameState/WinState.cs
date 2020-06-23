using KekkeKaarten.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameState
{
    class WinState:GameObjectList
    {
        public TextGameObject endPoints = new TextGameObject("SpriteFonts/GameFont");
        static public TextGameObject correct = new TextGameObject("SpriteFonts/GameFont");
        static public string Correct{ get => correct.Text; set => correct.Text = value; }
        private static int points = 0;
        public static int Points { get => points; set => points = value; }
        public WinState() : base()
        {
            this.Add(new SpriteGameObject("Backgrounds/winscreen"));
            this.Add(endPoints);
            this.Add(correct);
            endPoints.Text = "" + Points;
            correct.Text = "0";
            
            endPoints.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 3 * 2 + 60);
            correct.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y - 160);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("StartState");
                StartState.ResetGame = true;
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (endPoints.Text != "" + Points)
            {
                endPoints.Text = "" + Points;
            }
        }
    }
}
