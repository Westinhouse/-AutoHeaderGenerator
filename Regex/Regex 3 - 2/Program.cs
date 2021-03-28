
﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regex_3___2
{
    internal class Program
    {
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus, out int[] rolls)
        {
            List<int> listOfRolls = new() { };

            var random = new Random();
            int sum = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                int result = random.Next(1, diceSides + 1);
                listOfRolls.Add(result);
                sum += result;
            }
            rolls = listOfRolls.ToArray();
            return sum += fixedBonus;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice simulator. Please enter in standard dice notation how many dice and of which kind to throw.");
            string diceNotation = Console.ReadLine();
            Match match = Regex.Match(diceNotation, @"(\d+)?d(\d+)([+-]\d+)?");
            int numberOfDice = match.Groups[1].Success ? Int32.Parse(match.Groups[1].Value) : 1;
            int sidesOfDice = Int32.Parse(match.Groups[2].Value);
            int fixedBonus = match.Groups[3].Success ? Int32.Parse(match.Groups[3].Value) : 0;
            int[] rolls;
            int sumOfRolls = DiceRoll(numberOfDice, sidesOfDice, fixedBonus, out rolls);

            Console.WriteLine("Here are the results of the dice thrown");
            Console.WriteLine(sumOfRolls);
            Console.WriteLine($"The individual rolls that where rolled were:{string.Join(",", rolls)}");
        }
    }
}