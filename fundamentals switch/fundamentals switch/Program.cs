
﻿using System;

namespace fundamentalsSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Intro greetings and instructions
            Console.WriteLine("Welcome! Please set the price using this format 'Number' 'Operand' 'Number': ");

            // Player inputs 
            string playerInput = Console.ReadLine();

            // Split player inputs
            string[] subs = playerInput.Split(' ');

            // set variables
            int x = int.Parse(subs[0]);
            int y = int.Parse(subs[subs.Length - 1]);
            int result = 0;

            // translate the operand into something the cpu can use and calculate the sum
            switch (subs[1])
            {
                case "*":
                case "times":
                case "multiplied":
                    result = x * y;
                    break;

                case "+":
                case "plus":
                    result = x + y;
                    break;

                case "-":
                case "minus":
                    result = x - y;
                    break;

                case "/":
                case "divided":
                    result = x / y;
                    break;

                default:
                    Console.WriteLine("I'm sorry, I didn't quite understand. Try using a different operand");
                    break;
            }

            // Print results
            Console.WriteLine($"The price was set to {result}");

        }
    }
}
