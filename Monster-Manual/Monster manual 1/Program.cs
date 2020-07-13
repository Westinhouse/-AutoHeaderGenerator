
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Monster_manual_1
{
    internal class Program
    {
        static void DisplayMonster(MonsterEntry monster)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Name: {monster.Name}");
            Console.WriteLine($"Type: {monster.Description}");
            Console.WriteLine($"Aligment: {monster.Alignment}");
            Console.WriteLine($"Default HP: {monster.HPDefault}");
            Console.WriteLine($"Rolled HP: {monster.HPRoll}");
            Console.WriteLine($"Armor Class: {monster.Armor.Class}");

            if (armorTypeEntries.ContainsKey(monster.Armor.Type))
            {
                Console.WriteLine($"Armor type: {armorTypeEntries[monster.Armor.Type].Name}");
                Console.WriteLine($"Armor Category: {armorTypeEntries[monster.Armor.Type].Category}");
                Console.WriteLine($"Armor Weight: {armorTypeEntries[monster.Armor.Type].Weight} lbs.");
            }
            else
            {
                Console.WriteLine($"Armor type: {monster.Armor.Type}");
            }

            if (monster.Speed > 0)
            {
                Console.WriteLine($"Speed: {monster.Speed} ft.");
            }

            if (monster.BurrowingSpeed > 0)
            {
                Console.WriteLine($"Burrowing Speed: {monster.BurrowingSpeed} ft.");
            }

            if (monster.FlyingSpeed > 0)
            {
                Console.WriteLine($"Flying Speed: {monster.FlyingSpeed} ft.");
            }

            if (monster.SwimmingSpeed > 0)
            {
                Console.WriteLine($"Swimming Speed: {monster.SwimmingSpeed} ft.");
            }

            if (monster.ClimbingSpeed > 0)
            {
                Console.WriteLine($"Climbing Speed: {monster.ClimbingSpeed} ft.");
            }

            if (monster.Hover)
            {
                Console.WriteLine("Can Hover.");
            }

            Console.WriteLine($"Challenge Rating: {monster.ChallengeRating}");
            Console.WriteLine($"XP Value: {monster.XPValue}");
            Console.WriteLine();
            return;
        }

        static Dictionary<ArmorType, ArmorTypeEntry> armorTypeEntries = new();

        class MonsterEntry
        {
            public string Name;
            public string Description;
            public string Alignment;
            public int HPDefault;
            public string HPRoll;
            public int Speed;
            public int BurrowingSpeed;
            public int FlyingSpeed;
            public int SwimmingSpeed;
            public int ClimbingSpeed;
            public bool Hover;
            public double ChallengeRating;
            public int XPValue;
            public ArmorInformation Armor;
        }

        class ArmorInformation
        {
            public int Class;
            public ArmorType Type;
        }

        class ArmorTypeEntry
        {
            public string Name;
            public ArmorCategory Category;
            public int Weight;

        }

        enum ArmorCategory
        {
            Light,
            Medium,
            Heavy,
        }

        enum ArmorType
        {
            Unspecfied,
            Natural,
            Leather,
            StuddedLeather,
            Hide,
            ChainShirt,
            ChainMail,
            ScaleMail,
            Plate,
            Other
        }

        static void Main(string[] args)
        {
            /*Setting up the lists etc.*/
            string monsterManual = File.ReadAllText("MonsterManual.txt");
            string[] armorTypesArray = File.ReadAllLines("ArmorTypes.txt");
            string[] armorTypeNames = Enum.GetNames<ArmorType>();
            var monsters = new List<MonsterEntry>();

            /*Parsing the armor category and associated info*/
            for (int i = 0; i < armorTypesArray.Length; i++)
            {
                string armorTypesText = armorTypesArray[i];
                string[] armorTypeText = armorTypesText.Split(",");
                ArmorType armorType = Enum.Parse<ArmorType>(armorTypeText[0]);
                string armorName = armorTypeText[1];
                ArmorCategory armorCategory = Enum.Parse<ArmorCategory>(armorTypeText[2]);
                int armorWeight = Convert.ToInt32(armorTypeText[3]);

                /*Adding everything to the class */
                ArmorTypeEntry armorTypeEntry = new ArmorTypeEntry();
                armorTypeEntry.Name = armorName;
                armorTypeEntry.Category = armorCategory;
                armorTypeEntry.Weight = armorWeight;

                /*adding the info to the dictionary*/
                armorTypeEntries.Add(armorType, armorTypeEntry);
            }

            /*Setting up the Regex pattern */
            MatchCollection matches = Regex.Matches(monsterManual,
                @"(.*)\n" + /* Monster name*/
                @"(.*), (.*)\n" + /*Description and Alignment*/
                @"Hit Points: (\d*)(?: \((.*)\))? ?\n" + /*Hitpoints and then Rolled HitPoints*/
                @"Armor Class: (\d*)(?: \((.*)\))? ?\n" + /*Armor class and then eventual armor type*/
                @"Speed: (.*)\n" + /*Full line of speed(s), for now */
                @"Challenge Rating: (\d+)(?:\/(\d+))? \((\d*,?\d*?) XP\)\n" /*Challenge Rating and XP value */
                );

            /* Adding the data from the captures into the MonsterEntry class */
            foreach (Match match in matches)
            {
                MonsterEntry monster = new MonsterEntry
                {
                    Name = match.Groups[1].Value,
                    Description = match.Groups[2].Value,
                    Alignment = match.Groups[3].Value,
                    HPDefault = Convert.ToInt32(match.Groups[4].Value),
                    HPRoll = match.Groups[5].Value,
                    Armor = new ArmorInformation
                    {
                        Class = Convert.ToInt32(match.Groups[6].Value),
                    },
                    XPValue = Convert.ToInt32(match.Groups[11].Value.Replace(",", "")), //The replace is needed because XP sometimes includes a comma (ie 5,900).
                };
                monsters.Add(monster);

                /*Parsing armor types*/
                string armorTypeLine = match.Groups[7].Value;

                if (match.Groups[7].Success)
                {
                    if (Regex.IsMatch(armorTypeLine, "Studded Leather"))
                    {
                        monster.Armor.Type = ArmorType.StuddedLeather;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Leather"))
                    {
                        monster.Armor.Type = ArmorType.Leather;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Scale Mail"))
                    {
                        monster.Armor.Type = ArmorType.ScaleMail;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Chain Mail"))
                    {
                        monster.Armor.Type = ArmorType.ChainMail;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Chain Shirt"))
                    {
                        monster.Armor.Type = ArmorType.ChainShirt;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Natural"))
                    {
                        monster.Armor.Type = ArmorType.Natural;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Hide"))
                    {
                        monster.Armor.Type = ArmorType.Hide;
                    }
                    else if (Regex.IsMatch(armorTypeLine, "Plate"))
                    {
                        monster.Armor.Type = ArmorType.Plate;
                    }
                    else
                    {
                        monster.Armor.Type = ArmorType.Other;
                    }
                }
                else
                {
                    monster.Armor.Type = ArmorType.Unspecfied;
                }

                /* Parsing Speed(s) */
                string speedLine = match.Groups[8].Value;

                Match regularSpeedMatch = Regex.Match(speedLine, @"^(\d+)");
                if (regularSpeedMatch.Success)
                {
                    monster.Speed = Convert.ToInt32(regularSpeedMatch.Groups[1].Value);
                }

                Match burrowingSpeedMatch = Regex.Match(speedLine, @"burrow (\d+)");
                if (burrowingSpeedMatch.Success)