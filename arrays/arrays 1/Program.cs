using System;
using System.Collections.Generic;

namespace arrays_1
{
    internal class Program
    {
        static void CreateDayDescription(int day, int season, int year)
        {
            string[] days = {"1", "2", "3", "4"};
            string[] seasons = {"Spring", "Summer", "Fall", "Winter"};
            string[] years = {"130", "312", "241", "156"};
            Console.WriteLine($"It is the {days[day]} day of {seasons[season]} of the year {years[year]}");
           
        }
        static void Main(string[] args)
        {
            var random = new Random();
            for (int i = 0; i < 5; i++)
            CreateDayDescription(random.Next(0, 4), random.Next(0, 4), random.Next(0, 4));
        }
    }
}
