
﻿using System;
using System.Collections.Generic;
namespace Dictionaries2
{
    internal class Program
    {
        static Random random = new Random();

        static void Ask(SortedList<string, string> capitals)
        {
            var countries = new List<string> (capitals.Keys);
            int countryIndex = random.Next (countries.Count);
            string country = countries[countryIndex];
            Console.WriteLine($"What is the capital of {country}?");
            string answer = Console.ReadLine();
            string correctAnswer = capitals[country];

            if (answer.ToLowerInvariant() == correctAnswer.ToLowerInvariant())
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect! Wrong! No, no, no, the capital of {country} is {capitals[country]}");
            }

        }
        static void Main(string[] args)
        {
            var capitals = new SortedList<string, string>()
            {
                {"China", "Bejing" },
                {"Japan", "Tokyo" },
                {"Democratic Republic of Kongo", "Kinshasa" },
                {"Indonesia", "Jakarta"},
                {"Egypt", "Cairo"},
                {"South Korea", "Seoul"},
                {"Mexico", "Mexico City"},
                {"United Kingdom", "London"},
                {"Bangladesh", "Dhaka"},
                {"Peru", "Lima"},
                {"Iran", "Theran"},
                {"Thailand", "Bangkok"},
                {"Vietnam", "Hanoi"},
                {"Iraq", "Baghdad"},
                {"Saudi Arabia", "Riyadh"},
                {"Colombia", "Bogota"},
                {"Chile", "Santiago"},
                {"Turkey", "Ankara"},
            };
            Ask(capitals);
        }
    }
}