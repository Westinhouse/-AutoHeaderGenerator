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
            string[] games = { "https://store.steampowered.com/app/553420/TUNIC/", "https://store.steampowered.com/app/1657630/Slime_Rancher_2/", "https://store.steampowered.com/app