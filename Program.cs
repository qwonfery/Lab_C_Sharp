using System;
using System.Diagnostics;
using System.Collections;

namespace C_Sharp_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Номер 1 : ");
            Team T1 = new Team("team", 17);
            Team T2 = new Team("team", 17);
            Console.WriteLine("Равенство ссылок : {0}", ReferenceEquals(T1, T2));
            Console.WriteLine("Равенство по значению : {0}\n",Equals(T1, T2));
            Console.WriteLine("Номер 2 : ");
            try
            {
                T1.Number = -5;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("{0}\n", ex);
            }
            Console.WriteLine("Номер 3 : ");
            Person Person1 = new Person("Vladimir", "Putin", new DateTime(1932, 10, 6));
            Person Person2 = new Person("Viktor", "Tsoy", new DateTime(1979, 9, 5));
            Person Person3 = new Person("Michail", "Gorshenev", new DateTime(1999, 9, 9));
            Paper Paper1 = new Paper("publ1",Person1,new DateTime(2000,3,3));
            Paper Paper2 = new Paper("publ2", Person1, new DateTime(2010, 6, 6));
            Paper Paper3 = new Paper("publ3", new Person(), new DateTime(2021, 5, 5));
            ResearchTeam RTeam = new ResearchTeam("topic1","teamName1",TimeFrame.TwoYears,12);
            RTeam.AddPapers(new Paper[] {Paper1,Paper2,Paper3});
            RTeam.AddMembers(new Person[] { Person1, Person2, Person3,new Person()});
            Console.WriteLine(RTeam);
            Console.WriteLine("Номер 4 : ");
            Console.WriteLine(RTeam.BaseTeam);
            Console.WriteLine("\nНомер 5 : ");
            ResearchTeam RTeamCopy = (ResearchTeam)RTeam.DeepCopy();
            Console.WriteLine(RTeamCopy);
            Console.WriteLine("Номер 6 : ");
            foreach ( Person p in RTeam.NoPublication())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("\nНомер 7 : ");
            foreach (Paper p in RTeam.LastPublications(2))
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\nДопы : ");
            Console.WriteLine("Номер 8 : ");
            foreach (Person p in RTeam)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Номер 9 : ");
            foreach (Person p in RTeam.MoreThanOnePublication())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Номер 10 : ");
            foreach (Paper p in RTeam.LastYearPublications())
            {
                Console.WriteLine(p);
            }
        }
    }
}
