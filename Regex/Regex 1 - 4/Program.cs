
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_1
{
    internal class Program
    {

        static List<string> monsterNames = new List<string>();
        static List<string> slowFlyers = new List<string>();

        static void Main(string[] args)
        {

            string[] monsterManual = File.ReadAllLines("MonsterManual.txt");
            monsterNames.Add(monsterManual[0]);


            for (int i = 0; i < monsterManual.Length; i++)
            {
                if (Regex.IsMatch(monsterManual[i], @"fly [1-4]\d "))
                {
                    slowFlyers.Add(monsterManual[i - 4]);
                }
            }

            Console.WriteLine("Monsters that can fly 10-49 feet per turn:");

            for (int i = 0; i < slowFlyers.Count; i++)
            {
                Console.WriteLine($"{slowFlyers[i]}");
            }
        }
    }
}