using System;
using System.Collections.Generic;

namespace Algothm_design_1_mission_2
{
    internal class Program
    {
        static string JoinWithAnd(List<string> heroes, bool commaFlag = false)
        {
            //count the number of heronames in list
            int count = heroes.Count;

            if (count == 0)
            {
                return (" ");
            }

            else if (count == 1)
            {
                return($"{heroes[0]}");
            }

            else if (count == 2)
            {
                return(String.Join(" and ", heroes));
            }

            else
            {
                //Generate new list as per flowchart
                List<string> newList = new List<string>(heroes);

                //Initialize variables for second to last and last for cleaner writing.
                int last = newList.Count - 1;
                int secondToLast = newList.Count - 2;

                if (commaFlag)
                {
                    newList[last] = "and " + newList[last];
                    return (String.Join(", ", newList )); 
                }
                else
                {
                    newList[secondToLast] = newList[secondToLast] + " and " + newList[last];
                    newList.RemoveAt(newList.Count - 1);
                    return String.Join(", ", newList);
                }
            }

        }
        static void Main(string[] args)
        {
            // Create the party
            var heroes = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };
            Console.WriteLine(JoinWithAnd(heroes, true));
            

        }
    }
}
