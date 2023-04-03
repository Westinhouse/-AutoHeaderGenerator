
﻿using System;

namespace fundamentalsSwitch
{
    internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome! Please set the price using this format 'Number' 'Operand' 'Number': ");
        string playerInput = Console.ReadLine();
        string[] subs = playerInput.Split(' ');
        int sum = Int32.Parse(subs[0]) + Int32.Parse(subs[1]) + Int32.Parse(subs[2]);

        Console.WriteLine($"The price was set to {sum}");

    }
}
}
