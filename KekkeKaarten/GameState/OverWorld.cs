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
                player.locationOnGrid = map.PlayerSpawn;
                CenterMap(map);
                player.Position = map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].GlobalPosition;
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
                    MapObject currentTile = (MapObject)map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)];
                    if (!currentTile.IsSolid)
                    {
                        CenterMap(map);
                        player.Position = map.Objects[(int)(player.locationOnGrid.X), (int)(player.locationOnGrid.Y)].GlobalPosition;
                        player.lastLocationOnGrid = player.locationOnGrid;
                    }
                    else {
                        player.locationOnGrid = player.lastLocationOnGrid; 
                    }
                }
            }


        }

        private void CenterMap(GameObjectGrid map)
        {
            map.Position = new Vector2(-(player.locationOnGrid.X - 10) * map.CellWidth, -(player.locationOnGrid.Y - 10) * map.CellHeight);
        }
    }
}
