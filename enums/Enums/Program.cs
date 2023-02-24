
﻿using System;

namespace Enums
{
    internal class Program
    {
        static void DrawAce(Suits suit)
        {



            string suitSymbols = "♥♠♦♣";
            char symbol = suitSymbols[(int)suit];


            Console.WriteLine($"╭───────╮");
            Console.WriteLine($"│A      │");
            Console.WriteLine($"│{symbol}      │");
            Console.WriteLine($"│   {symbol}   │");
            Console.WriteLine($"│      {symbol}│");
            Console.WriteLine($"│      A│");
            Console.WriteLine($"╰───────╯");
            Console.WriteLine("----");
        }
        enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DrawAce(Suits.Hearts);
            DrawAce(Suits.Spades);
            DrawAce(Suits.Clubs);
            DrawAce(Suits.Diamonds); 

        }
    }
}