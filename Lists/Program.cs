﻿using System;
using System.Collections.Generic;

namespace fundamentals_lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WorkWithString();

            void WorkWithString()
            {
                var names = new List<string> { "David", "Ana", "Felipe" };
                foreach (var name in names)
                {
                    Console.WriteLine($"Hello {name.ToUpper()}!");
                }

                Console.WriteLine();
                names.Add("Maria");
                names.Add("Bill");
                names.Remove("Ana");
                foreach (var name in names)
                {
                    Console.WriteLine($"Hello {name.ToUpper()}!");
                }

                Console.WriteLine($"My name is {names[0]}");
                Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");

                Console.WriteLine($"The list has {names.Count} people in it");

                var index = names.IndexOf("Felipe");
                if (index == -1)
                {
                    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
                }
                else
                {
                    Console.WriteLine($"The name {names[index]} is at index {index}");
                }

                i