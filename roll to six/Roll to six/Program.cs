
﻿using System;

namespace Roll_to_six
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int throwDice;
            int score = 0;
            do
            {
                throwDice = random.Next(1, 7);
                score += throwDice; 
                Console.WriteLine($"The player rolls: {throwDice}");
            } while (throwDice != 6);
            Console.WriteLine($"Total score {score}"); 
        }
    }
}