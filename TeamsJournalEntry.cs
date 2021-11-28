using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class TeamsJournalEntry
    {
        public string Name { get; set; }
        public Revision WhatHappend { get; set; }
        public string PropertyName { get; set; }
        public int Number { get; set; }

        public TeamsJournalEntry(string nameValue, Revision whatHappendValue, string propertyValue, int numberValue)
        {
            Name = nameValue;
            WhatHappend = whatHappendValue;
            PropertyName = propertyValue;
            Number = numberValue;
        }

        public override string ToString()
        {
            return $"Name : {Name}|WhatHappend : {WhatHappend}|Property : {PropertyName}|Number : {Number}";
        }
    }
}
