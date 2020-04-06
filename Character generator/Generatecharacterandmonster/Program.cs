using System;

namespace Generatecharacterandmonster
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

            int strenght = 0;
            for(int counter = 0; counter < 3; counter++) //Roll a d6 three times and store the value, set it as the characters strenght and print the result
            {
                strenght += roll(6);
            } 
            Console.WriteLine($"A character with stren