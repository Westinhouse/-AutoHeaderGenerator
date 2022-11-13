using System;

namespace algorithm_design_1__mission__3
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        {
            int lastDigit = number % 10;
            int secondToLastDigit = number / 10 % 10;

            if (secondToLastDigit == 1)
            {
               string result = ($"{number}th");
                return result;
            }

            if (lastDigit == 1)
            {
                string result = ($"{number}st");
                return result;
            }

            if (lastDigit == 2 )
            {
                string result = ($"{number}nd");
                return result;
            }

            if (lastDigit == 3)
            {
                string result = ($"{number}rd");
                return result;
            }

            else
            {
                string result = ($"{number}th");
                return result;
            }
        }
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("Hello! im going to take whatever integer you give me and t