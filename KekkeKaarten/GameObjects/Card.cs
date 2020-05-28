using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects
{
    class Card : GameObjectList
    {
        public GameObjectList cardTextures = new GameObjectList();
        public GameObjectList cardText = new GameObjectList();
        public CardText text;
        public Vector2 ReturnLocation;
        public bool drag = false;
        public bool rightAnswer;
        public bool kill = false;
        private int cardID;
        public Card(string nummer, Vector2 position, bool Rightanswer, int id) : base()
        {
          

            this.position = position;
      
            this.Add(cardTextures);
            this.Add(cardText);

            cardID = id;
            cardTextures.Add(new CardTexture(new Vector2(0, 0)));
            cardText.Add(text = new CardText(nummer, new Vector2(0, 0)));
            this.rightAnswer = Rightanswer;
            ChangeLocation();
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public void ChangeLocation()
        {
            if (Hand.numberOfCards == 3)
            {
                ReturnLocation = new Vector2((GameEnvironment.Screen.X / Hand.numberOfCards) + (224 * cardID), 500);
            }
            else if (Hand.numberOfCards == 4)
            {
                ReturnLocation = new Vector2((584) + (224 * cardID), 500);
            }
            else if (Hand.numberOfCards == 5)
            {
                ReturnLocation = new Vector2((GameEnvironment.Screen.X / Hand.numberOfCards) + (224 * cardID), 500);
            }
            else
            {
                ReturnLocation = new Vector2((GameEnvironment.Screen.X / Hand.numberOfCards) + (224 * cardID), 500);
            }


            position = ReturnLocation;
        }

   

      
    }
}
