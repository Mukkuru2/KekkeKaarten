using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.FileIO;


namespace KekkeKaarten.CSVhandling
{
    public static class CSVimporter
    {
        static readonly string path = @"CSVhandling/missions_rekenen_export.csv";
        static TextFieldParser csvParser = new TextFieldParser(path);
        static Random random = new Random();

        public static List<GameQuestion> GetCSV(int questionAmount)
        {

            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { ";" });
            csvParser.HasFieldsEnclosedInQuotes = true;

            List<GameQuestion> QuestionList = new List<GameQuestion>();

            //The provided CSV files are structures like this:
            //mission_id;id;Question type;Question;Did you know?;Difficulty level;Display type;Verification status;Comments;Answers

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                string[] values = csvParser.ReadFields();
                if (values[2] == "select")
                {
                    string[] wrongAnswers = new string[3];
                    try
                    {
                        wrongAnswers[0] = values[10];
                        wrongAnswers[1] = values[11];
                        wrongAnswers[2] = values[12];
                    }
                    catch 
                    { 
                    //TODO: what if values don't exist? make a way to get other values here
                    }

                    QuestionList.Add(new GameQuestion(values[0], values[1], values[3], values[4], values[5], values[8], values[9], wrongAnswers));

                }
            }

            while (QuestionList.Count > questionAmount)
            {
                QuestionList.RemoveAt(random.Next(0, QuestionList.Count));
            }

            return QuestionList;
        }
    }
}
