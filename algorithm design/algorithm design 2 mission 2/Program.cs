
﻿using System;

namespace algorithm_design_2_mission_2
{
    internal class Program
    {
        static int Factorial(int n)
        {

            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1); 
            }
        }
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine(Factorial(n));
            n = 1;
            Console.WriteLine(Factorial(n));
            n = 2;
            Console.WriteLine(Factorial(n));
            n = 3;
            Console.WriteLine(Factorial(n));
            n = 4;
            Console.WriteLine(Factorial(n));
            n = 5;
            Console.WriteLine(Factorial(n));
            n = 6;
            Console.WriteLine(Factorial(n));

        }
    }
}