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
                    Console.WriteLine("The answer is gr