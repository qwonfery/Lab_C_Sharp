using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    public class ResearchTeamEnumerator : System.Collections.IEnumerator
    {
        System.Collections.ArrayList members;
        System.Collections.ArrayList papers;
        int position = -1;

        public ResearchTeamEnumerator(System.Collections.ArrayList _members, System.Collections.ArrayList _papers)
        {
            members = _members;
            papers = _papers;
        }

        public bool MoveNext()
        {
            while (true)
            {
                position++;
                if (position < members.Count)
                {
                    for (int j = 0; j < papers.Count; j++)
                    {
                        Paper PaperTemp = (Paper)papers[j];
                        if (PaperTemp.Author == Current)
                        {
                            return true;
                        }

                    }

                }
                else
                {
                    return false;
                }

            }
        }

        public void Reset()
        {
            position = -1;
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        Person Current
        {
            get
            {
                try
                {
                    return (Person)members[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
