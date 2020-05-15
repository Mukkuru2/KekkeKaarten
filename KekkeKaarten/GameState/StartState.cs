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

        private static GameObjectList maps = new GameObjectList();

        public static GameObjectList Maps { get => maps; set => maps = value; }

        public StartState()
        {
            CSVimporter.GetCSV();
            LoadMaps();
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

        public void LoadMaps()
        {
            GameObjectList mapData = new GameObjectList();

            mapData.Add(new LoadMap("maps/mapdatanature"));

            foreach (LoadMap map in mapData.Children)
            {
                maps.Add(new Map(map.GetMap()));
            }
        }

    }
}
