﻿using System;
using System.Collections.Generic;

namespace algorithm_design_2_mission_1
{
    internal class Program
    {
        static string ShuffleList(List<string> names)
        {
            var random = new Random();
            for (int i = names.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                string temp = names[i];
                names[i] = names[k];
                names[k] = temp;
            }
            
            return String.Join(", ", names);
        }
        static string JoinWithAnd(List<string> names)
        {
            List<string> newList = new List<string>(names);

            //Initialize variables for second to last and last for cleaner writing.
            int last = newList.Count - 1;
            int secondToLast = newList.Count - 2;


            newList[secondToLast] = newLi