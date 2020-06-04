using System;
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

                