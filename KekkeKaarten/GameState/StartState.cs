using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KekkeKaarten.CSVhandling;
using KekkeKaarten.GameManagement.MapLoading;
using KekkeKaarten.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten
{
    class StartState : GameObjectList
    {

        public StartState()
        {
            CSVimporter.GetCSV();
            this.Add(new SpriteGameObject("Backgrounds/startscreen"));

            
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("Overworld");
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }

        
    }
}
