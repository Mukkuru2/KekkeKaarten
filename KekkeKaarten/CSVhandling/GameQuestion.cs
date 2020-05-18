using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.CSVhandling
{
    public class GameQuestion
    {
        private string missionID;
        private string id;
        private string question;
        private string didYouKnow;
        private string difficulty;
        private string comments;
        private string correctanswer;

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

        public string MissionID { get => missionID; set => missionID = value; }
        public string Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string DidYouKnow { get => didYouKnow; set => didYouKnow = value; }
        public string Difficulty { get => difficulty; set => difficulty = value; }
        public string Comments { get => comments; set => comments = value; }
        public string Correctanswer { get => correctanswer; set => correctanswer = value; }
    }
}
