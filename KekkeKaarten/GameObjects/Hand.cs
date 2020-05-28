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
        private string wronganswers;

        private int randomWrongAnswer;
        private int randomRightAnswer;

        string[] answers = new string[7];

        int answernumber = 0;



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
            randomRightAnswer = GameEnvironment.Random.Next(0, 19);
                 
            whichCardIsCorrect = GameEnvironment.Random.Next(0, numberOfCards);

            correctanswer = questionarray[randomRightAnswer].Correctanswer;           
            question.Text = questionarray[randomRightAnswer].Question;

            answers[answernumber] = correctanswer;
            answernumber++;

            for (int i = 0; i < numberOfCards; i++)
            {
                
                randomWrongAnswer = GameEnvironment.Random.Next(0, 19);
                for (int x = 0; x < answernumber; x++)
                {
                    while(answers[x] == questionarray[randomWrongAnswer].Correctanswer)
                    {
                         randomWrongAnswer = GameEnvironment.Random.Next(0, 19);

                    }
                    
                }
                answers[answernumber] = questionarray[randomWrongAnswer].Correctanswer; ;
                answernumber++;

                wronganswers = questionarray[randomWrongAnswer].Correctanswer;



                if (i == whichCardIsCorrect)
                {
                    Cards.Add(new Card(correctanswer, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), true, i));
                    
                }
                else
                {
                    Cards.Add(new Card(wronganswers, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 500), false, i));
                }

            }



        }

        public void DeleteCards()
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                Cards.Remove(Cards.Children.ElementAt(Cards.Children.Count - 1));
          
            }
            for (int i = 0; i < answernumber; i++)
            {
                answers[i] = "";
                answernumber = 0;
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
