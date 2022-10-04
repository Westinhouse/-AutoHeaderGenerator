
﻿using System;

namespace Tank_battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // introductory text
            Console.WriteLine("World war 1.\nA tank is making its way across the scorched battlefield..." +
                "\nYou are in control of an artillery unit, trying to destroy the advancing hunk of metal." +
                "\nYou need to aim your gun well to hit the advancing enemy in the distance, and you have only 5 shells left");

            // Create input for username
            Console.WriteLine("What is your name, commander?");
            string userName = Console.ReadLine();
            Console.WriteLine($"-Artillery Sgt. {userName}!");

            // Call to action
            Console.WriteLine("-DANGER! A tank is approaching our position. Your artillery unit is our only hope!");
            Console.WriteLine("\nHere is the map of the battlefield:");

            //Create a distance variable and set it to a random value, draw battlefield and display positions
            var random = new Random();
            int tankDistance = random.Next(40, 71);
            Console.Write($"\n_/");

           for (int i = 0; i < 78; i++)
            {
                if (i == tankDistance)
                {
                    Console.Write("T");
                }
                else
                {
                    Console.Write("_");
                }
            }

            //Shell counter
            int ammo = 5;

            // Game over flag
            bool gameOver = false;

            //Start asking for where to shoot
            while (ammo > 0 && gameOver == false)
            {
                Console.WriteLine($"\nAim your shot, {userName}!");
                Console.Write("Enter distance:");
                int shotDistance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Distance fired: {shotDistance}");

                //Print result of the shot that was fired (to short, hit or too long) and how many shells remain
                if (shotDistance == tankDistance)
                {
                    Console.WriteLine("Direct hit! Target explodes in a screaming inferno of fire and scrap metal!");
                    ammo -= 1;
                    gameOver = true;
                }

                if (shotDistance > tankDistance)
                {
                    Console.WriteLine("Too Far! The shell flies past and strikes the destroyed ground behind the advancing enemy!");
                    ammo -= 1;
                }

                if (shotDistance < tankDistance)
                {
                    Console.WriteLine("Too short! The shell strikes the ground and explodes ahead of the enemy position!");
                    ammo -= 1;
                }

                //Draw where the shell hit, and if a number greater than the lenght of the battlefield is input, write message.
                for (int i = 0; i < 80; i++)
                {
                    if (i == shotDistance)
                    {
                        Console.Write("*");
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }
                if (shotDistance > 80)
                {
                    Console.WriteLine("\nThe shell flies past your visual range and lands somewhere in the smog behind the battlefield");
                }

                //Print game over screen if ammo runs out or victory screen if enemy hit, otherwise display how many shots remain
                if (ammo == 0 && gameOver == false)
                {
                    Console.WriteLine("\nThe enemy captures your position! \nYou and your unit are killed! \nGAME OVER");
                }

                if (gameOver == true)
                {
                    Console.WriteLine("\nYou saved your unit and destroyed the enemy!\n YOU WIN!");
                }

                else
                {
                    Console.WriteLine($"\nShells remaining: {ammo}");
                }
            }
          

        }
    }
}