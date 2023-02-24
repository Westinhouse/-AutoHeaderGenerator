
﻿using System;
using System.IO;

namespace files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playerNamePath = "player-name.txt";
            string playerName;
            string[] backers = File.ReadAllLines("backers.txt");
            bool backerAcess = false;

            if (File.Exists(playerNamePath))
            {
                playerName = File.ReadAllText("player-name.txt");
                Console.WriteLine($"Welcome back {playerName}! Let's continue!");
            }
            else
            {
                Console.WriteLine("Welcome Player! What is your name?");
                playerName = Console.ReadLine();
                File.WriteAllText("player-name.txt", playerName);
                Console.WriteLine($"Nice to met you {playerName}! Let's begin!");
            }

            foreach (string backer in backers)
            {
                if (backer == playerName)
                {
                    backerAcess = true;
                }
            }

            if (backerAcess)
            {
                Console.WriteLine("You soccessfully enter Dr. Fred's secret laboratory and are greeted with a warm welcome for backing the games Kickstarter!");
            }
            else
            {
                Console.WriteLine("Unfortunately I cannot let you into Dr. Fred's secret laboratory.");
            }
        }
    }
}