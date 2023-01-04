
﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace algorithm_design_7___mission_3
{
    internal class Program
    {
        static void DisplayData(List<int> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(1);
        }
        static void Main(string[] args)
        {
            var data = new List<int>();
            var random = new Random();

            for (int i = 0; i < 70; i++)
            {
                data.Add(random.Next(20));
                DisplayData(data);
            }

            // Bubble sort

            // Go through the list number by number and compare it to its next neighbor.
            // If the next neighbor is smaller than the previous one, swap them!
            // Continue until we reach the end.
            // Each time we go through the list, the highest neighbor will 'bubble' to the end.
            // This means we have to sort a smaller and smaller part of the list as we go on.
            // We'll decrease our sorting range one by one until the whole list is sorted.

            for (int sortingRange = data.Count; sortingRange > 0; sortingRange--)
            {
                int counter = 0;
                // Now we go from the start of the list to the end of the sorting range.
                while (counter < sortingRange - 1)
                {

                    // Look at the next neighbor and see if it's smaller.
                    while (data[counter + 1] < data[counter])
                    {
                        // It is smaller! We need to switch them.
                        int smallerNumber = data[counter + 1];
                        int biggerNumber = data[counter];
                        data[counter] = smallerNumber;
                        data[counter + 1] = biggerNumber;
                    }

                    // Display data for diagnostic purposes.
                    DisplayData(data);
                    counter++;
                }
            }
        }
    }
}