
﻿using System;

namespace Arrays_mission_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] monsters = new int[100];

            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i] = random.Next(1, 51);
            }
            Array.Sort(monsters);
            Console.Write("Number of monsters in levels: ");
            foreach (int monster in monsters)
            {
                Console.Write($"{monster}, ");
            }

            
            
        }
    }
}