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
        GameObjectList maps = new GameObjectList();

        public StartState()
        {
            CSVimporter.GetCSV();
            this.Add(new SpriteGameObject("Backgrounds/startscreen"));

            LoadMaps();
            this.Add(maps);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }

        public void LoadMaps() {
            GameObjectList mapData = new GameObjectList();

            mapData.Add(new LoadMap("maps/mapdatanature"));

            foreach (LoadMap map in mapData.Children) {
                maps.Add(new Map(map.GetMap()));
            }
        }
    }
}
