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
                // Lets do this by rolling 4d6, sorting them from lowest to highest and then summing up the rolls, skipping the first index.
                // lets do that 6 times
                for (int i = 0; i < 6; i++)
                {
                    var rolls = new List<int>();

                    for (int j = 0; j < 4; j++)
        