
﻿using System;

namespace Regenerate_spell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int warriorHP = random.Next(1, 101);
            Console.WriteLine($"Warrior HP: {warriorHP}");
            Console.WriteLine("The Regenerate spell is cast");
            if (warriorHP < 50)
            {
                while (warriorHP < 50)
                {
                    warriorHP += 10;
                    Console.WriteLine($"Warrior HP: {warriorHP}");
                }
                if (warriorHP > 50)
                {
                    Console.WriteLine("The Regenerate spell is complete");
                }
         
            }
            else
            {
                    Console.WriteLine("The Regenerate spell is complete");
            }
                
            

        }
    }
}