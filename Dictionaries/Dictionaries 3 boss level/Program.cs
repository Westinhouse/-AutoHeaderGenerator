using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries_3_boss_level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scores = new Dictionary<string, int>();
            bool quit = false;
            while (quit == false)
            {
                //ask who won
                
                Console.WriteLine("Who won this round?");
                string playerName = Console.ReadLine();
                playerName = playerName.ToLowerInvariant