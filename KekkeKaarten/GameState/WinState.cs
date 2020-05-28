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
        private static int points = 0;
        public static int Points { get => points; set => points = value; }
        public WinState() : base()
        {
            this.Add(endPoints);
            endPoints.Text = "" + Points;
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
