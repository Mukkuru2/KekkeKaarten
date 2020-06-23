using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KekkeKaarten.GameObjects
{
    class QuestionCounter : TextGameObject
    {
        public int score = 0;
        public QuestionCounter(Vector2 startPosition) : base("SpriteFonts/GameFont")
        {
            //Text = score.ToString();
            Text = "o";
            position.X = startPosition.X;
            position.Y = startPosition.Y;
            Color = Color.Black;    
            Reset();
      
        }

        public override void Reset()
        {
            base.Reset();
            score = 0;
        }
        public override void Update(GameTime gameTime)
        {

            this.text = score.ToString();


        }

        public int getScore
        {
            get { return score; }
            set { score = value; }
        }

    }
}
