using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace KekkeKaarten.CSVhandling
{
    public static class CSVimporter
    {
        static readonly string path = @"CSVhandling/missions_rekenen_export.csv";
        static TextFieldParser csvParser = new TextFieldParser(path);

        public static List<List<string>> GetCSV()
        {

            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { ";" });
            csvParser.HasFieldsEnclosedInQuotes = true;

            List<List<string>> fullList = new List<List<string>>(); ;

            //mission_id;id;Question type;Question;Did you know?;Difficulty level;Display type;Verification status;Comments;Answers
            List<string> missionID = new List<string>();
            List<string> id = new List<string>();
            List<string> question = new List<string>();
            List<string> didYouKnow = new List<string>();
            List<string> difficulty = new List<string>();
            List<string> comments = new List<string>();
            List<string> correctanswer = new List<string>();

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                string[] values = csvParser.ReadFields();

                missionID.Add(values[0]);
                id.Add(values[1]);
                question.Add(values[3]);
                didYouKnow.Add(values[4]);
                difficulty.Add(values[5]);
                comments.Add(values[8]);
                correctanswer.Add(values[9]);
            
            }

            fullList.Add(missionID);
            fullList.Add(id);
            fullList.Add(question);
            fullList.Add(didYouKnow);
            fullList.Add(difficulty);
            fullList.Add(comments);
            fullList.Add(correctanswer);
            return fullList;
        }
    }
}
