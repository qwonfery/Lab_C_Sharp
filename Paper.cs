using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Paper
    {
        //string title;
        //Person author;
        //DateTime publicationDate;
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public Paper(string titleValue,Person authorValue,DateTime publicationDateValue)
        {
            Title = titleValue;
            Author = authorValue;
            PublicationDate = publicationDateValue;

        }
        public Paper() : this("publ", new Person(), new DateTime(2000,12,12))
        {

        }

        public override string ToString()
        {
            return "Paper: " + Title + " | " + Author.ToShortString() + " | " + PublicationDate + '\n';
        }


    }
}
