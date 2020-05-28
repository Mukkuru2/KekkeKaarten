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
    

      
        public static int numberOfCards = 3;
        Question question;

        List<GameQuestion> questionnaam = CSVimporter.GetCSV(20);
        GameQuestion[] questionarray = new GameQuestion[20];

        private int whichCardIsCorrect;
        private string correctanswer;
        private string wrongAnswers;

        private int randomWrongAnswer;
        private int randomRightAnswer;

        string[] answers = new string[7];

        int answerNumber = 0;



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
            randomRightAnswer = GameEnvironment.Random.Next(0, questionarray.Length);
                 
            whichCardIsCorrect = GameEnvironment.Random.Next(0, numberOfCards);

            correctanswer = questionarray[randomRightAnswer].Correctanswer;           
            question.Text = questionarray[randomRightAnswer].Question;

            answers[answerNumber] = correctanswer;
            answerNumber++;

            for (int i = 0; i < numberOfCards; i++)
            {
                
                randomWrongAnswer = GameEnvironment.Random.Next(0, questionarray.Length);
                for (int x = 0; x < numberOfCards; x++)
                {
                    while(answers[x] == questionarray[randomWrongAnswer].Correctanswer)
                    {
                         randomWrongAnswer = GameEnvironment.Random.Next(0, questionarray.Length);
                    }
                    
                }

                answers[answerNumber] = questionarray[randomWrongAnswer].Correctanswer; ;
                answerNumber++;

                wrongAnswers = questionarray[randomWrongAnswer].Correctanswer;



                if (i == whichCardIsCorrect)
                {
                    Cards.Add(new Card(correctanswer, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), true, i));
                    
                }
                else
                {
                    Cards.Add(new Card(wrongAnswers, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), false, i));
                }

            }



        }

        public void DeleteCards()
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                Cards.Remove(Cards.Children.ElementAt(Cards.Children.Count - 1));
          
            }
            for (int i = 0; i < answerNumber; i++)
            {
                answers[i] = "";
                answerNumber = 0;
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
