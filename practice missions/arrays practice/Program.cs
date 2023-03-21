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
            string[] dayNumbers = new string[30] {"1: Thursday ", "2: Friday ", "3: Saturday ", "4: Sunday ", "5: Monday ", "6: Tuesday ", "7: Wednesday ", "8: Thursday ", "9: Friday ", "10: Saturday ", "11: Sunday ", "12: Monday ", "13: Tuesday ", "14: Wednesday ", "15: Thursday ", "16: Friday ", "17: Saturday ", "18: Sunday ", "19: Monday ", "20: Tuesday ", "21: Wednesday ", "22: Thursday ", "23: Friday ", "24: Saturday ", "25: Sunday ", "26: Monday ", "27: Tuesday ", "28: Wednesday ", "29: Thursday ", "30: Friday " };

            //print the months days and numbers

            //for (int i = 0; i < dayNumbers.Length; i++)
            //{
            //    Console.Write(dayNumbers[i]);
            //}

            var random = new Random();
            int[] numbers = new int[random.Next(5, 11)];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
            }
            Console.Write($"{numbers.Length} numbers are:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }
        }
    }
}
