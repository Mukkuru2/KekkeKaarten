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
        public TextGameObject Victory = new TextGameObject("SpriteFonts/GameFont");
        private static int points = 0;
        public static int Points { get => points; set => points = value; }
        public WinState() : base()
        {
            this.Add(Victory);
            this.Add(endPoints);
            Victory.Text = "you win";
            endPoints.Text = "" + Points;
            Victory.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2 - 200);
            endPoints.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2);
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
