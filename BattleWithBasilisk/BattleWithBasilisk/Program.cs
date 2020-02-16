
﻿using System;
using System.Collections.Generic;

namespace BattleWithBasilisk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int roll(int diceSides)
            {
                return random.Next(1, diceSides + 1);
            }
            
            // Create a party of five warriors
            var names = new List<string> {"Regal", "Dwyn", "Jyra", "Aska"};
            Console.WriteLine($"A Part of brave warriors ({String.Join(", ", names)}) descends into the dungeon");

            // Create a Basilisk and set its HP
            int basiliskHp = 0;
            for (int counter = 0; counter < 8; counter++)
            {
                basiliskHp += roll(8);
            }
            basiliskHp += 16;
            Console.WriteLine($"A fearsome Basilisk with {basiliskHp} HP appears!\nAvoid its dreadful gaze!");

            //While the basilisk is alive, our heroes strike their foe!
            while (basiliskHp > 0)
            {
                foreach (string name in names)
                {
                    int Attack = (roll(4));
                    Console.WriteLine($"\n{name} strikes the basilisk for {Attack} damage.");
                    basiliskHp -= Attack;

                    if (basiliskHp <= 0)
                    {
                        Console.WriteLine("The basilisk has 0 HP left.\nThe basilisk collapses and the heroes celebrate their victory!");
                        return;
                    }

                    else
                    {
                        Console.WriteLine($"The basilisk has {basiliskHp}HP remaining");
                    }
                }
                // The basilisk attacks a random hero with its petrifying gaze, if its alive.
                
                int save = roll(20) + 5;
                int gazeTarget = random.Next(names.Count);

                if (names.Count == 0)
                {
                    Console.WriteLine("The party has failed and the basilisks continues to turn unsuspecting adventurers to stone");
                    Console.WriteLine("G A M E O V E R");
                    return;
                }

                if (save >= 12)
                {
                    Console.WriteLine();
                    Console.WriteLine($"The basilisk uses its petrifying gaze on {names[gazeTarget]}!");
                    Console.WriteLine($"{names[gazeTarget]} rolls a {save} and is saved from the attack!");
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"The basilisk uses its petrifying gaze on {names[gazeTarget]}!");
                    Console.WriteLine($"{names[gazeTarget]} rolls a {save} and fails to be saved.\n{names[gazeTarget]} is turned to stone!");