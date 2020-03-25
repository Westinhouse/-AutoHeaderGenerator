﻿using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ExploreIf();

            ExploreLoops();

            ChallengeAnswer();

            void ExploreIf()
            {
                int a = 5;
                int b = 3;
                if (a + b > 10)
                {
                    Console.WriteLine("The answer is greater than 10");
                }
                else
                {
                    Console.WriteLine("The answer is not greater than 10");
                }

                int c = 4;
                if ((a + b + c > 10) && (a > b))
                {
                    Console.WriteLine("The answer is greater than 10");
                    Console.WriteLine("And the first number is greater than the second");
                }
                else
                {
                    Console.WriteLine("The answer is not greater than 10");
                    Console.WriteLine("Or the first number is not greater than the second");
                }

                if ((a + b + c > 10) || (a > b))
                {
                    Console.WriteLine("The answer is greater than 10");
                    Console.WriteLine("Or the first number is greater than the second");
                }
                else
                {
                    Console.WriteLine("The answer is not greater than 10");
                    Console.WriteLine("And the first number is not greater than the second");
                }
            }

            void ExploreLoops()
            {
                int counter = 0;
                while (counter < 10)
                {
                    Console.WriteLine($"Hello World! The counter is {counter}");
                    counter++;
             