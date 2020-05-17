using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KekkeKaarten.GameManagement.MapLoading
{
    class LoadMap : SpriteGameObject
    {

        //Dictionary<Color, int> gameObjectList;
        public LoadMap(string assetName) : base(assetName)
        {
            position = new Vector2(0, 0);
            //visible = false;
        }

        public int[,] GetMap()
        {
            Color[] colorData = new Color[sprite.Width * sprite.Height];
            sprite.Sprite.GetData(colorData);
            int[,] map = new int[sprite.Width, sprite.Height];

            Console.WriteLine(colorData[105 + 104 * Height]);

            for (int yMap = 0; yMap < sprite.Width; yMap++)
            {
                for (int xMap = 0; xMap < sprite.Height; xMap++)
                {
                    Color color = colorData[xMap + yMap * Height];


                    //color black : wall : 0
                    if (color == new Color(0, 0, 0))
                    {
                        map[xMap, yMap] = 0;
                    }
                    //color white: normal tile : 1
                    if (color == new Color(255, 255, 255))
                    {
                        map[xMap, yMap] = 1;
                    }
                    //color purple : player spawn : 2
                    if (color == new Color(254, 0, 254))
                    {
                        map[xMap, yMap] = 2;
                    }
                    //color red : golden statue : 3
                    if (color == new Color(255, 0, 0))
                    {
                        map[xMap, yMap] = 3;
                    }
                    //color blue : boss room entrance : 4
                    if (color == new Color(0, 0, 255))
                    {
                        map[xMap, yMap] = 4;
                    }
                    //color green : marshland : 5
                    if (color == new Color(0, 255, 0))
                    {
                        map[xMap, yMap] = 5;
                    }
                    //color darkgreen : toxic gas : 6
                    if (color == new Color(0, 85, 0))
                    {
                        map[xMap, yMap] = 6;
                    }

                }
            }


            return map;
        }
    }
}
