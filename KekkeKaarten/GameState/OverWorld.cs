using KekkeKaarten.GameManagement.MapLoading;
using KekkeKaarten.GameObjects;
using KekkeKaarten.GameObjects.MapObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameState
{
    class OverWorld : GameObjectList
    {
        GameObjectList maps = new GameObjectList();
        Player player = new Player();
        public OverWorld() : base()
        {
            LoadMaps();
            this.Add(maps);
            this.Add(player);
            foreach (Map map in maps.Children)
            {
                player.loca = map.spawn;
                player.preloca = player.loca;
                player.Position = map.Objects[(int)(player.loca.X), (int)(player.loca.Y)].Position;

            }
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!(player.preloca == player.loca))
            {
                foreach (Map map in maps.Children)
                {
                    if (map.map.GetLength(0) >= player.loca.X && map.map.GetLength(1) >= player.loca.Y && 0 <= player.loca.X && 0 <= player.loca.Y)
                    {
                        player.Position = map.Objects[(int)(player.loca.X), (int)(player.loca.Y)].Position;
                        player.preloca = player.loca;
                    }
                }
            }
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
