using System;
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
                    Console.WriteLine($"The {monsterName} unleashes a deadly attack on {heroNames[attackTarget]}!");
                    Console.WriteLine($"{heroNames[attackTarget]} rolls a {save} and is saved from the attack!");
                }

                if (save <= savingThrowDC - 1 && monsterHP > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"The {monsterName} unleashes a deadly attack on {heroNames[attackTarget]}!");
                    Console.WriteLine($"{heroNames[attackTarget]} rolls a {save} and fails to be saved.\n{heroNames[attackTarget]} is slain!");
                    heroNames.RemoveAt(attackTarget);
                }

            }
        }

        static void Main(string[] args)
        {

            // Create a party of five warriors
            var heroNames = new List<string> { "Regal", "Dwyn", "Jyra", "Aska" };
            Console.WriteLine($"A Party of brave warriors ({String.Join(", ", heroNames)}) descends into the dungeon");

            // Create a monster and set their hp and attack DCs
            string monsterName = "Orc";
            int monsterHP = DiceRoll(2, 8, 6);
            int savingThrowDC = 12;

            SimulateBattle(heroNames, monsterName, monsterHP, savingThrowDC);

            //If the heroes are still alive, set a new monster on them
            

            if (heroNames.Count > 0)
            {
                monsterName = "Mage";
                monsterHP = DiceRoll(9, 8);
                savingThrowDC = 20;
                SimulateBattle(heroNames, monsterName, monsterHP, savingThrowDC);
                
                //If heroes are still alive send the final monster on them
                if (heroNames.Count > 0)
                {
                    monsterName = "Troll";
                    monsterHP = DiceRoll(8, 10, 40);
                    savingThrowDC = 18;
                    SimulateBattle(heroNames, monsterName, monsterHP, savingThrowDC);

                    if (heroNames.Count > 1)
                    {
                        Console.WriteLine($"The remaining heroes ({String.Join(", ", heroNames)}) emerge victorious from the dungeon!" +
                            $"\nThe people of the land rejoice!");
                        return;

                    }

                    if (heroNames.Count == 1)
                    {
                        Console.WriteLine($"The lone hero {heroNames[0]} returns from the dungeon, richer in gold but poorer in friends");
                        return;
                    }
                }
            }

        }
    }
}

