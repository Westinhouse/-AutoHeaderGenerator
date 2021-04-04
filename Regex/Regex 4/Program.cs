using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Regex_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            string[] games = { "https://store.steampowered.com/app/553420/TUNIC/", "https://store.steampowered.com/app/1657630/Slime_Rancher_2/", "https://store.steampowered.com/app/1811260/EA_SPORTS_FIFA_23/", "https://store.steampowered.com/app/1954200/Kena_Bridge_of_Spirits/" };

            for (int i = 0; i < games.Length; i++)
            {
                string htmlCode = httpClient.GetStringAsync(games[i]).Result;
                Match name = Regex.Match(htmlCode, @"<title>(.*) on Steam<");
                Match review = Regex.Match(htmlCode, @"game_review_summary \w*"">(.*)<");
                string score = review.Groups[1].Value;
                string title = name.Groups[1].Value.Trim();
                Console.WriteLine($"The current rating of the game {title} is {score}");
            }

        }
    }
}
