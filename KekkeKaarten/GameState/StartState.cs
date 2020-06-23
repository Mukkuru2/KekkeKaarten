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
        static bool resetGame = false;
        public static bool ResetGame { get => resetGame; set => resetGame = value; }
        public StartState()
        {
            Reset();
            this.Add(new SpriteGameObject("Backgrounds/startscreen"));

        public override void Reset()
        {
            LoadMaps();
            base.Reset();
            PlayerFight.HP = 100;
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
            if (resetGame)
            {
                Reset();
                resetGame = false;
            }
            base.Update(gameTime);   
        }

        public void LoadMaps()
        {
            GameObjectList mapData = new GameObjectList();

            mapData.Add(new LoadMap("maps/mapdatanature", -1, "Overworld"));
            mapData.Add(new LoadMap("maps/mapdatabossroom", -1, "BossRoom"));

            foreach (LoadMap map in mapData.Children)
            {
                maps.Add(new Map(map.GetMap()));
            }
        }

    }
}
