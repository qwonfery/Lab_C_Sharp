using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class ResearchTeam : Team
    {
        private string topic;
        TimeFrame duration;
        System.Collections.ArrayList participants;
        System.Collections.ArrayList papers;

        public ResearchTeam() : this("topicDefault","nameDefault",TimeFrame.Year,0)
        {

        }


        public ResearchTeam(string topicValue,string nameValue,TimeFrame durationValue,int numberValue)
        {
            topic = topicValue;
            duration = durationValue;
            name = nameValue;
            number = numberValue;
        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public TimeFrame Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        
        public Paper lastPaper
        {
            get {
                if (this.papers.GetLength(0) == 0)
                {
                    return null;
                }
                else
                {
                    Paper PaperSought = Papers[0];
                    for (int i = 0 ; i < Papers.Length ; i++)
                    {
                        PaperSought = Papers[i].PublicationDate.CompareTo(PaperSought.PublicationDate) >= 0 ? Papers[i] : PaperSought; 
                    }
                    return PaperSought;
                }
            }

        }
        public bool this[TimeFrame index]
        {
            get
            {
                return Duration.CompareTo(index) == 0; 
            }
        }
        public void AddPapers(params Paper[] PapersValue)
        {
            Paper[] PapersNew = new Paper[Papers.Length + PapersValue.Length];
            Papers.CopyTo(PapersNew,0);
            Array.ConstrainedCopy(PapersValue,0,PapersNew,Papers.Length, PapersValue.Length);
            Papers = PapersNew;
        }


        public override string ToString()
        {
            string PapersString = new string("Papers: \n");
            PapersString += Papers[0].ToString();
            if (Papers.Length > 0)
            {
                for (int i = 1; i < Papers.Length; i++)
                {
                    PapersString += Papers[i].ToString();
                }
            }
            return "Topic: " + Topic + "\n"
                + "Name: " + Name + '\n'
                + "Number: " + Number + '\n'
                + "Duration: " + Duration + '\n'
                + PapersString;
        }
        public string ToShortString()
        {
            return "Topic: " + Topic + "\n"
                + "Name: " + Name + '\n'
                + "Number: " + Number + '\n'
                + "Duration: " + Duration + '\n';
        }


    }
}
