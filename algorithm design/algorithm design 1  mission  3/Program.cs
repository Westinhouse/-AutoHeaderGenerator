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

            if (lastDigit == 2