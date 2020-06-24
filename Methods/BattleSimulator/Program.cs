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
                    int 