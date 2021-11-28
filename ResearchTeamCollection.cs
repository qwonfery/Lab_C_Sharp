using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C_Sharp_Lab
{
    delegate void ResearchTeamsChangedHandler<TKey>(object source, ResearchTeamsChangedEventArgs<TKey> args);

    delegate TKey KeySelector<TKey>(ResearchTeam rt);
    class ResearchTeamCollection<TKey>
    {

        private Dictionary<TKey, ResearchTeam> collection = new Dictionary<TKey, ResearchTeam>();
        private KeySelector<TKey> keySelector;
        public string Name { get; set; }

        public ResearchTeamCollection(KeySelector<TKey> keySelectorValue)
        {
            keySelector = keySelectorValue;
        }

        public DateTime LastDate
        {
            get
            {
                List<DateTime> lastDates = new List<DateTime>();
                lastDates.Add(new DateTime());
                foreach (ResearchTeam rt in collection.Values)
                {
                    if (rt.lastPaper != null)
                    {
                        lastDates.Add(rt.lastPaper.PublicationDate);
                    }
                }
                return lastDates.Max();
            }
        }

        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> GroupByDuration
        {
            get
            {
                IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> result = collection.GroupBy(
                   group => group.Value.Duration);
                return result;
            }
        }

        public void AddDefaults()
        {
            ResearchTeam defaultRT = new ResearchTeam();
            collection.Add(keySelector(defaultRT), defaultRT);
            defaultRT.PropertyChanged += HandlerPropertyChanged;
        }

        public void AddResearchTeams(params ResearchTeam[] paramsValue)
        {
            foreach (ResearchTeam param in paramsValue)
            {
                collection.Add(keySelector(param), param);
                param.PropertyChanged += HandlerPropertyChanged; 
            }
        }

        public override string ToString()
        {
            string str = $"This collection contains {collection.Count} research teams: \n";
            str += "\n----------------------------------------------\n";
            foreach (ResearchTeam value in collection.Values)
            {
                str += value.ToString() + "\n----------------------------------------------\n";
            }
            return str;
        }

        public string ToShortString()
        {
            string str = $"This collection contains {collection.Count} research teams: \n";
            foreach (ResearchTeam value in collection.Values)
            {
                str += value.ToShortString();
            }
            return str;
        }

        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            return collection.Where(group => group.Value.Duration == value);
        }


        //LAB 4

        public event ResearchTeamsChangedHandler<TKey> ResearchTeamsChanged;
        private void HandlerPropertyChanged(object o, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ResearchTeam rt = (ResearchTeam)o;
            ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(Name, Revision.Property, e.PropertyName, rt.Number));
        }
        private void NotifyResearchTeamsChanged(Revision revisionValue, string propertyValue, int numberValue)
        {
            ResearchTeamsChanged?.Invoke(this,new ResearchTeamsChangedEventArgs<TKey>(Name,revisionValue,propertyValue,numberValue));
        }
        public bool Remove(ResearchTeam rt)
        {
            if (collection.ContainsValue(rt))
            {
                foreach (KeyValuePair<TKey, ResearchTeam> kvp in collection)
                {
                    if (kvp.Value == rt)
                    {
                        collection.Remove(kvp.Key);
                        kvp.Value.PropertyChanged -= HandlerPropertyChanged;
                        NotifyResearchTeamsChanged(Revision.Remove, "", rt.Number);

                        return true;
                    }
                }
            }
            return false;
        }
        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            if (collection.ContainsValue(rtold))
            {
                foreach (KeyValuePair<TKey, ResearchTeam> kvp in collection)
                {
                    if (kvp.Value == rtold)
                    {
                        collection[kvp.Key] = (ResearchTeam)rtnew.DeepCopy();
                        rtold.PropertyChanged -= HandlerPropertyChanged;
                        NotifyResearchTeamsChanged(Revision.Replace, "", rtold.Number);
                        rtnew.PropertyChanged += HandlerPropertyChanged;
                        return true;
                    }
                }
            }
            return false;
        }

     

    }
}
