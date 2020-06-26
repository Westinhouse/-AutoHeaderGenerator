﻿using System;
using System.Collections.Generic;

namespace BattleSimulator
{
    internal class Program
    {
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int sum = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                sum += random.Next(1, diceSides + 1);
            }
             return sum += fixedBonus;

        }

        static void SimulateBattle(List<string> heroNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            var random = new Random();
            Console.WriteLine($"A fearsome {monsterName} with {monsterHP}HP appears!");
            while (monsterHP > 0)
            {
                foreach (string name in heroNames)
                {
                    int Attack = (DiceRoll(2, 6));
                    Console.WriteLine($"\n{name} strikes the {monsterName} for {Attack} damage.");
                    monsterHP -= Attack;

                    if (monsterHP <= 0)
                    {
                        Console.WriteLine($"The {monsterName} has 0 HP left.\nThe {monsterName} collapses.");
                        Console.WriteLine("Our heroes celebrate their victory!");
                        Console.WriteLine();
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"The {monsterName} has {monsterHP}HP remaining");
                    }
                }
                // The Monster attacks a random hero with its attack, if its alive.

                int save = DiceRoll(1, 20, 5);
                int attackTarget = random.Next(heroNames.Count);

                if (heroNames.Count == 0)
                {
                    Console.WriteLine("The party has failed and the evil continues to cause turmoil and misery in the lands");
                    Console.WriteLine("G A M E O V E R");
                    return;
                }

                if (save >= savingThrowDC && monsterHP > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"The {monsterName} unleashes a