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
        public GameObjectList KillList = new GameObjectList();
    

        bool right = false;  
        public static int numberOfCards = 3;
        Question question;

        List<GameQuestion> questionnaam = CSVimporter.GetCSV(20);
        GameQuestion[] questionarray = new GameQuestion[20];

        private string rightanswer;
        private string wronganswer;
        private int goodCard;
        private int rightAnswerNumber;
        private int wrongAnswerNumber;


        public Hand()
        {
            
            this.Add(Cards);
            this.Add(KillList);
            this.Add(question = new Question(""));


            ChangeCards();



            
        }

        public void ChangeCards()
        {
            
            questionarray = questionnaam.ToArray();
            goodCard = GameEnvironment.Random.Next(0, numberOfCards);
            rightAnswerNumber = GameEnvironment.Random.Next(0, 20);
            question.Text = questionarray[rightAnswerNumber].Question;
            wrongAnswerNumber = GameEnvironment.Random.Next(0, 20);

            if(rightAnswerNumber == wrongAnswerNumber)
            {
                wrongAnswerNumber = GameEnvironment.Random.Next(0, 20);
            }

            
            rightanswer = questionarray[rightAnswerNumber].Correctanswer;
            wronganswer = questionarray[wrongAnswerNumber].Correctanswer;




            for (int i = 0; i < numberOfCards; i++)
            {

            
                if (i == goodCard)
                {
                    Cards.Add(new Card(rightanswer, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), true,i));
                    right = true;
                }
                else
                {
                    Cards.Add(new Card(wronganswer, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), false,i));
                }

            }

         



        }

        public void DeleteCards()
        {
            for (int i = 0; i < 3; i++)
            {
                Cards.Remove(Cards.Children.ElementAt(Cards.Children.Count - 1));
            }
            
        }


       
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (var aObject in KillList.Children)
            {
                Cards.Remove(aObject);
            }
   
        }
    }
}
