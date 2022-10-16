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

               