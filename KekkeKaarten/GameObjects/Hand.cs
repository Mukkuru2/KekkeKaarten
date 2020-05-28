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
    
        public string[] numbers = new string[] { "1", "3", "4" };
        bool right = false;
        public static bool addcard = false;

        public int RightAnswer;
        public int NextAnswer;
        public static int numberOfCards = 3;

        int random = GameEnvironment.Random.Next(0, 20);
        int randomNext = GameEnvironment.Random.Next(0, 20);

        string rightanswer;
        string wronganswer;

        Question question;

        List<GameQuestion> questionnaam = CSVimporter.GetCSV(20);
        GameQuestion[] questionarray = new GameQuestion[20];

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
            RightAnswer = GameEnvironment.Random.Next(0, numberOfCards);
            NextAnswer = GameEnvironment.Random.Next(0, 20);
            question.Text = questionarray[NextAnswer].Question; 

            

            
     



            for (int i = 0; i < numberOfCards; i++)
            {

                randomNext = GameEnvironment.Random.Next(0, 20);

                if (rightanswer == wronganswer)
                {
                    randomNext = GameEnvironment.Random.Next(0, 20);
                }
                rightanswer = questionarray[NextAnswer].Correctanswer;
                wronganswer = questionarray[randomNext].Correctanswer;


                if (i == RightAnswer)
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
