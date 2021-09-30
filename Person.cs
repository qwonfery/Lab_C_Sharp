using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Person
    {
        string name;
        string surname;
        DateTime date;

        public Person(string nameValue, string surnameValue, DateTime dateValue)
        {
            name = nameValue;
            surname = surnameValue;
            date = dateValue;
        }
        public Person() : this(" Dima ", "Pupkin ", new DateTime(2002, 12, 5))
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Year
        {
            get { return Date.Year; }
            set { Date = new DateTime(value, Date.Month, Date.Day); }
        }

        public override string ToString() {
            return "Person: " + Name + " "  +  Surname + " " + Date;
        }

        public string ToShortString()
        {
            return "Person: " + Name + " " + Surname;
        }




    }
}