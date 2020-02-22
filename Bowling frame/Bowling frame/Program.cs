using System;

namespace Bowling_frame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int throw1 = random.Next(0, 11);
            int pinsLeft = (10 - throw1);
            if (throw1 == 0)
                    {
                Console.WriteLine("Your first throw: -");
                Console.WriteLine("Miss!");
            }
            if (pinsLeft == 0)
            {
                Console.WriteLine("Your first throw: X");
                Console.WriteLine("You scored a strike!");
            }
            else
            {
                Console.WriteLine($"Your first throw knocked down {throw1} pins!");
                int throw2 = random.Next(0, pinsLeft + 1);
                pinsLeft -= throw2;
                if (throw2 == 0)
                