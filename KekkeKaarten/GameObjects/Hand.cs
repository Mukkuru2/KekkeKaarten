using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using KekkeKaarten.Collisions;
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
     
        private string[] wrongAnswers = new string[6];

        
        private int randomRightAnswer;
        private int otherRightAnwer;

        string[] answers = new string[100];

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
            otherRightAnwer = GameEnvironment.Random.Next(0, questionarray.Length);

            while(randomRightAnswer == otherRightAnwer)
            {
                otherRightAnwer = GameEnvironment.Random.Next(0, questionarray.Length);
            }
            whichCardIsCorrect = GameEnvironment.Random.Next(0, numberOfCards);
            correctanswer = questionarray[randomRightAnswer].Correctanswer;
            question.Text = questionarray[randomRightAnswer].Question;
            //verwijder deze nu eens niet alsjeblieft
            CardCollision.Difficulty = questionarray[randomRightAnswer].Difficulty;
            // ff mooi gemarkeert zo
            for (int i = 0; i < numberOfCards; i++)
            {
                if (i <= 2)
                {
                    wrongAnswers[i] = questionarray[randomRightAnswer].WrongAnswers[i];
                }
                if (i > 2)
                {
                    wrongAnswers[i] = questionarray[otherRightAnwer].WrongAnswers[i-3];
                }



                if (i == whichCardIsCorrect)
                {
                    Cards.Add(new Card(correctanswer, new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 700), true, i));

                }
                else
                {
                    Cards.Add(new Card(wrongAnswers[i], new Vector2(GameEnvironment.Screen.X / 3 + (200 * i), 700), false, i));
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
                wrongAnswers[i] = "";
;                answerNumber = 0;
            }

            
        }

        public void cardDelete() 
        {
           for (int i = 0; i < numberOfCards; i++)
		    {
                Card card = (Card)Cards.Children.ElementAt(i);
                Console.WriteLine("2");
                if (card.remove) 
                {
                    Console.WriteLine("1");
                    Cards.Children.Remove(card);
                    break;
                }

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
