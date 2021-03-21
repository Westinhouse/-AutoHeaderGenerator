using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_3____1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] monsterManualLines = File.ReadAllLines("MonsterManual.txt");
            string monsterManual = File.ReadAllText("MonsterManual.txt");

            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();



            for (int axis1Index = 0; axis1Index < 3; axis1Index++)
            {
                for (int axis2Index = 0; axis2Index < 3; axis2Index++)
                {
                    namesByAlignment[axis1Index, axis2Index] = new List<string>();
                }
            }
            string[] axis1Values = new[] { "chaotic", "neutral", "lawful" };
            string[] axis2Values = new[] { "evil", "neutral", "good" };

            for (int i = 0; i < monsterManualLines.Length; i++)
            {
                Match match = Regex.Match(monsterManualLines[i], @"((chaotic|neutral|lawful) (evil|neutral|good)|neutral)");
                if (match.Success)
                {
                    string monsterName = monsterManualLines[i - 1];

                    if (match.Groups[1].Value == "neutral")
                    {
                        namesByAlignment[1, 1].Add(monsterName);
                    }
                    else
                    {
                        string axis1Text = match.Groups[2].Value;
                        string axis2Text = match.Groups[3].Value;
                        int axis1Index = Array.IndexOf(axis1Values, axis1Text);
                        int axis2Index = Array.IndexOf(axis2Values, axis2Text);
                        namesByAlignment[axis1Index, axis2Index].Add(monsterName);
                    }
                }
                else if (Regex.IsMatch(monsterManualLines[i], @"unaligned"))
                {
                    namesOfUnaligned.Add(monsterManualLines[i - 1]);
                }
                else if (Regex.IsMatch(monsterManualLines[i], @"any alignment"))
                {
                    namesOfAnyAlignment.Add(monsterManualLines[i - 1]);
                }
                else if (Regex.IsMatch(monsterManualLines[i], @"any.*alignment"))
                {
                    namesOfSpecialCases.Add(monsterManualLines[i - 1] + monsterManualLines[i].Substring(monsterManualLines[i].IndexOf(",")));
                }
            }


            for (int axis1Index = 0; axis1Index < 3; axis1Index++)
            {
                for (int axis2Index = 0; axis2Index < 3; axis2Index++)
                {
                    string aligmentName = $"{axis1Values[axis1Index]} {axis2Values[axis2Index]}";

                    if (aligmentName == "neutral neutral")
                    {
                        aligmentName = "true neutral";
                    }
                    Console.WriteLine($"The names of the monsters that are {aligmentName} are");
                    Console.WriteLine("---------------------------------------------");
                    foreach (string name in namesByAlignment[axis1Index, axis2Index])
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine();

                }
            }

            Console.WriteLine("The names of monsters that are unaligned are:");
            Console.WriteLine("---------------------------------------------");
            foreach (string name in namesOfUnaligned)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("The names of monsters that can be of any alignment are:");
            Console.WriteLine("-------------------------------------------------------");
            foreach (string name in namesOfAnyAlignment)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("The names of monsters with special cases are:");
            Console.WriteLine("-------------------------------------------------------");
            foreach (string name in namesOfSpecialCases)
            {
                Console.WriteLine(name);
            }


        }
    }
}


