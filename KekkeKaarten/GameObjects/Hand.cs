using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using KekkeKaarten.CSVhandling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KekkeKaarten.GameObjects
{
    class Hand : GameObjectList
    {
         
        public static GameObjectList Cards = new GameObjectList();
        public string[] numbers = new string[] { "1", "3", "4" };
        bool right = false;
        public static bool addcard = false;

        public Hand()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!right)
                {
                    Cards.Add(new Card(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), true));
                    right = true;
                }
                else Cards.Add(new Card(numbers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), false));

                this.Add(Cards);
            }



            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (addcard)
            {
                Cards.Add(new Card("4", new Vector2(GameEnvironment.Screen.X / 3 + (200 * 3), 500), false));
                addcard = false;
            }
        }
    }
}
