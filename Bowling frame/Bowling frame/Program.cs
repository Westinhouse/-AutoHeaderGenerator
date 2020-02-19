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
