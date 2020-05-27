using System;
using System.Collections.Generic;

namespace Lists_mission_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var random = new Random();

                int roll(int diceSides)
                {
                    return random.Next(1, diceSides + 1);
                }
                var abilityScores = new List<int>();
                //To roll ability scores you roll 4d6 and discard the lowest
                // Lets do this by rolling 4d6, sorting them from lowest to highest 