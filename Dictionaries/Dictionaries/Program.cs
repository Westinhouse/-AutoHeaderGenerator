
﻿using System;
using System.Collections.Generic;

namespace Dictionaries
{
    internal class Program
    {
        static Random random = new Random();
        static void Ask(Dictionary<int, string> games, string gamesType)
        {
            var years = new List<int>(games.Keys);
            int yearIndex = random.Next(games.Count);
            int year = years[yearIndex];
            Console.WriteLine($"Which country hosted the olympic {gamesType} games in {year}?");
            string answer = Console.ReadLine();
            string correctAnswer = games[year];

            if (answer.ToLowerInvariant() == correctAnswer.ToLowerInvariant())
            {
                Console.WriteLine("Correct!");
            }

            else
            {
                Console.WriteLine($"Incorrect! The olympic {gamesType} games in {year} where hosted in {correctAnswer}");
            }
            games.Remove(year);
        }

        static void GenerateQuestion(Dictionary<int, string> summerGames, Dictionary<int, string> winterGames)
        {
            //Randomize question (summer or winter?)
            int type = random.Next(2);

            if (type == 1)
            {
                

                Ask(summerGames, "summer");
            }
            else
            {
                

                Ask(winterGames, "winter");
            }


        }


        static void Main(string[] args)
        {
            var winterGames = new Dictionary<int, string>()
            {
                {2002, "United States"},
                {2006, "Italy" },
                {2010, "Canada" },
                {2014, "Russia" },
                {2018, "South Korea" },
                {2022, "China" },
            };

            var summerGames = new Dictionary<int, string>()
            {
                {2000, "Australia"},
                {2004, "Greece"},