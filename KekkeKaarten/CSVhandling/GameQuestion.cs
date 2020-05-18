using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.CSVhandling
{
    public class GameQuestion
    {
        string missionID;
        string id;
        string question;
        string didYouKnow;
        string difficulty;
        string comments;
        string correctanswer;

        public GameQuestion(string missionID, string id, string question, string didYouKnow, string difficulty, string comments, string correctanswer)
        {
            this.missionID = missionID;
            this.id = id;
            this.question = question;
            this.didYouKnow = didYouKnow;
            this.difficulty = difficulty;
            this.comments = comments;
            this.correctanswer = correctanswer;
        }
    }
}
