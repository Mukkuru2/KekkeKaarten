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
        Player player = new Player();
        GameObjectList maps = StartState.Maps;

        public OverWorld() : base()
        {

            this.Add(maps);
            this.Add(player);
            foreach (Map map in maps.Children)
            {
                player.locationOnGrid = map.Spawn;
                player.lastLocationOnGrid = player.locationOnGrid;

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
            if (!(player.lastLocationOnGrid == player.locationOnGrid))
            {
                foreach (Map map in maps.Children)
                {
                    if (map.map.GetLength(0) >= player.locationOnGrid.X && map.map.GetLength(1) >= player.locationOnGrid.Y && 0 <= player.locationOnGrid.X && 0 <= player.locationOnGrid.Y)
                    {
                        player.Position = map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].Position;
                        player.lastLocationOnGrid = player.locationOnGrid;
                    }
                }
            }

            foreach (Map map in maps.Children)
            {
                CenterMap(map);
            }
        }

        private void CenterMap(GameObjectGrid map)
        {
            /*for (int yMap = 0; yMap < map..GetLength(0); yMap++)
            {
                for (int xMap = 0; xMap < grid.GetLength(1); xMap++)
                {
                    Vector2 position = new Vector2(tileLength * xMap, tileLength * yMap);
                    grid[xMap, yMap].Position = new Vector2(position + tileLength * );
                }
            }*/
        }
    }
}
