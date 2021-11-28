using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace C_Sharp_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam RTeam1 = new ResearchTeam($"topic{1}", $"teamName{1}", TimeFrame.TwoYears, 1);
            ResearchTeam RTeam2 = new ResearchTeam($"topic{2}", $"teamName{2}", TimeFrame.TwoYears, 2);
            KeySelector<string> keySelector = (ResearchTeam rt) => rt.GetHashCode().ToString();
            ResearchTeamCollection<string> collection1 = new ResearchTeamCollection<string>(keySelector);
            collection1.AddDefaults();
            collection1.AddResearchTeams(RTeam1, RTeam2);
            collection1.Name = "Collection1";

            ResearchTeam RTeam4 = new ResearchTeam($"topic{4}", $"teamName{4}", TimeFrame.TwoYears, 3);
            ResearchTeam RTeam5 = new ResearchTeam($"topic{5}", $"teamName{5}", TimeFrame.TwoYears, 4);
            ResearchTeamCollection<string> collection2 = new ResearchTeamCollection<string>(keySelector);
            collection2.AddDefaults();
            collection2.AddResearchTeams(RTeam4, RTeam5);
            collection2.Name = "collection2";

            TeamsJournal ChangeJournal = new TeamsJournal();
            collection1.ResearchTeamsChanged += ChangeJournal.AddChange;
            collection2.ResearchTeamsChanged += ChangeJournal.AddChange;
            //вносим изменения
            //добавляем элементы
            collection1.AddResearchTeams(new ResearchTeam($"topic{3}", $"teamName{3}", TimeFrame.TwoYears, 5));
            collection2.AddResearchTeams(new ResearchTeam($"topic{6}", $"teamName{6}", TimeFrame.TwoYears, 6));
            //изименем значения
            RTeam1.Topic = "ChangedTopic";
            RTeam2.Duration = TimeFrame.Year;
            //удаляем элемент
            collection1.Remove(RTeam1);
            //измегнение в удаленном
            RTeam1.Duration = TimeFrame.Year;
            //замена
            collection2.Replace(RTeam5, RTeam1);
            //изменение в замененном
            RTeam5.Topic = "ChangedTopic";
            //выводим журнал
            Console.WriteLine(ChangeJournal);
        }


    }
}
