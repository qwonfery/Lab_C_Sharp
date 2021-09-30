using System;
using System.Diagnostics;

namespace C_Sharp_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Vasya = new Person("Vasya", "Pupkin", new DateTime(2000, 12, 30));
            Paper Konstitution = new Paper("kostitution", Vasya, new DateTime(1999, 5, 15));
            Paper Konstitution2 = new Paper("kostitution2", Vasya, new DateTime(1835, 5, 15));
            Paper Konstitution3 = new Paper("kostitution3", Vasya, new DateTime(2008, 5, 15));
            Paper Konstitution4 = new Paper("kostitution4", Vasya, new DateTime(1035, 5, 15));
            Paper Konstitution5 = new Paper("kostitution5", Vasya, new DateTime(1008, 5, 15));
            Paper[] konsts = { Konstitution, Konstitution2, Konstitution3 };
            Paper[] konsts2 = { Konstitution4, Konstitution5 };
            ResearchTeam Team = new ResearchTeam();
            Console.WriteLine(Team.ToShortString());
            Console.WriteLine(Team[TimeFrame.Year].ToString() + " " + Team[TimeFrame.TwoYears].ToString() + " " + Team[TimeFrame.Long].ToString() + '\n');
            Team.Name = "TestName";
            Team.Number = 123;
            Team.Topic = "TestTopic";
            Team.Duration = TimeFrame.Long;
            Team.Papers = konsts;
            Console.WriteLine(Team.ToString());

            Team.AddPapers(konsts2);
            Console.WriteLine(Team.ToString());

            Console.WriteLine(Team.lastPaper);

            //Сравнить время выполнения операций с элементами одномерного,
            //    двумерного прямоугольного и двумерного ступенчатого массивов
            //    с одинаковым числом элементов типа Paper.
            Console.WriteLine("Введите количество строк и колонок (разделители ' ','\t' )");
            string[] input = Console.ReadLine().Split(' ', '\t');
            int nrow = Convert.ToInt32(input[0]);
            int ncolumn = Convert.ToInt32(input[1]);
            Console.WriteLine("Количество строк = {0} Количество столбцов = {1}", input);

            ResearchTeam[] ArrayOneDimension = new ResearchTeam[nrow * ncolumn];
            for (int i = 0; i < nrow * ncolumn; i++)
            {
                ArrayOneDimension[i] = new ResearchTeam();
            }

            ResearchTeam[,] ArraySquare = new ResearchTeam[nrow, ncolumn];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                    ArraySquare[i, j] = new ResearchTeam();
            }

            ResearchTeam[][] ArrayStepped = new ResearchTeam[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                ArrayStepped[i] = new ResearchTeam[ncolumn];
                for (int j = 0; j < ncolumn; j++)
                    ArrayStepped[i][j] = new ResearchTeam();
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < nrow * ncolumn; i++)
            {
                ArrayOneDimension[i].Topic = "TOPIC";
            }
            sw.Stop();
            Console.WriteLine(" Time for OneDimensionalArray = {0}", sw.Elapsed);
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                    ArraySquare[i, j].Topic = "TOPIC";
            }
            sw.Stop();
            Console.WriteLine(" Time for SquareArray = {0}", sw.Elapsed);
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                    ArrayStepped[i][j].Topic = "TOPIC";
            }
            sw.Stop();
            Console.WriteLine(" Time for SteppedArray = {0}", sw.Elapsed);

        }
    }
}
