using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class TeamsJournal
    {
        private List<TeamsJournalEntry> ChangeList = new List<TeamsJournalEntry>();

        public void AddChange(object o,ResearchTeamsChangedEventArgs<string> Args)
        {
            ChangeList.Add(new TeamsJournalEntry(Args.Name, Args.WhatHappend, Args.PropertyName, Args.Number));
        }
        public override string ToString()
        {
            string str = "Change list:\n";
            foreach (TeamsJournalEntry change in ChangeList)
            {
                str += $"Name : {change.Name}|WhatHappend : {change.WhatHappend}|Property : {change.PropertyName}|Number : {change.Number}\n";
            }
            return str;
        }




    }
}
