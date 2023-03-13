using System;

namespace arrays_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            //Print the array
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }
            string[] dayNumbers = new string[30] {"1: Thursday ", "2: Friday ", "3: Saturday ", "4: Sunday ", "5: Monday ", "6: Tuesday ", "7: Wednesday ", "8: Thu