﻿using Microsoft.Xna.Framework;
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
        public Vector2 ReturnLocation;
        public bool drag = false;
        public bool rightAnswer;
        public Card(string nummer, Vector2 position, bool Rightanswer) : base()
        {
            this.position = position;
            ReturnLocation = position;
            this.Add(cardTextures);
            cardTextures.Add(new CardTexture(new Vector2(0, 0)));
            this.Add(new CardText(nummer, new Vector2(0, 0)));
            this.rightAnswer = Rightanswer;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
