using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_1
{
    internal class Program
    {

        static List<string> monsterNames = new List<string>();

        static void Main(string[] args)
        {

            string[] monsterManual = File.ReadAllLines("MonsterManual.txt");
            monsterNames.Add(monsterManual[0]);
            List<bool> CanFly = new List<bool>();
            List<bool> IsTenDiceOrMore = new List<bool>();


            for (int i = 0; i < monsterManual.Length; i++)
            {

                if (monsterManual[i] == "")
                {
                    monsterNames.Add(monsterManual[i + 1]);
                }

                if (monsterManual[i].Contains("Speed") && monsterManual[i].Contains("fly"))
                {
                    CanFly.Add(true);
                }
                else if (monsterManual[i].Contains("Speed"))
                {
                    CanFly.Add(false);
                }

                if (Regex.IsMatch(monsterManual[i], @"\d{2}d"))
                {
                    IsTenDiceOrMore.Add(true);
                }
                else if (Regex.IsMatch(monsterManual[i], @"Hit Points"))
                {
                    IsTenDiceOrMore.Add(false);
                }

            }

            Console.WriteLine("Monsters in the manual are:");

            for (int i = 0; i < monsterNames.Count; i++)
            {
                Console.WriteLine($"{monsterNames[i]} \n- Can fly: {CanFly[i]} \n- 10+ dice rolls: {IsTenDiceOrMore[i]}");
            }
        }
    }
}
