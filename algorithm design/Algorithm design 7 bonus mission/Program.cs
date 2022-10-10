
﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Algorithm_design_7_bonus_mission
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

            Thread.Sleep(10);
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


            // Merge sort

            // Divide a list into two halves. First, sort each half separately.
            // Merge the sorted halves together by choosing the smallest number from one of the two lists.
            // Continue choosing until you've used all numbers from both lists.
            // We start the sort by simply trying to sort the full list.
            SortSublist(data, 0, data.Count - 1);

            // Display data for diagnostic purposes.
            DisplayData(data);
        }

        static void SortSublist(List<int> data, int startIndex, int endIndex)
        {
            // If our list has one element or less, the sublist is already sorted.
            if (startIndex >= endIndex)
                return;

            // Split the list in half.
            int middleIndex = (startIndex + endIndex) / 2;

            // Sort left half.
            SortSublist(data, startIndex, middleIndex);

            // Sort right half.
            SortSublist(data, middleIndex + 1, endIndex);

            // Merge both lists together into a temporary list.
            int leftSublistIndex = startIndex;
            int rightSublistIndex = middleIndex + 1;
            var mergedList = new List<int>();

            while (leftSublistIndex <= middleIndex || rightSublistIndex <= endIndex)
            {
                // See if the number from the left side is smaller, or if there are no numbers left on the right.
                if (rightSublistIndex > endIndex || leftSublistIndex <= middleIndex && data[leftSublistIndex] < data[rightSublistIndex])
                {
                    // Add the left number to the merged list.
                    mergedList.Add(data[leftSublistIndex]);
                    leftSublistIndex++;
                }
                else
                {
                    // Add the right number to the merged list.
                    mergedList.Add(data[rightSublistIndex]);
                    rightSublistIndex++;
                }

                // Display data for diagnostic purposes.
                DisplayData(data);
            }

            // Place numbers from the temporary list back into the main list.
            for (int i = 0; i < mergedList.Count; i++)
            {
                data[startIndex + i] = mergedList[i];

                // Display data for diagnostic purposes.
                DisplayData(data);
            }
        }
    }
}
