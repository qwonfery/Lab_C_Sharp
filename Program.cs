using System;
using System.Diagnostics;

namespace C_Sharp_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Team T1 = new Team("team", 17);
            Team T2 = (Team)T1.DeepCopy();

        }
    }
}
