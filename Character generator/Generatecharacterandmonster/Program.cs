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

            int strengh