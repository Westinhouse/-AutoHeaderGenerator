
﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Chart
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<double>();
            var random = new Random();
            for (int i = 0; i < 70; i++)
            {
                data.Add(random.Next(20));
                DisplayData(data);
            }
        }

        static void DisplayData(List<double> data)
        {
            Console.CursorVisible = false;