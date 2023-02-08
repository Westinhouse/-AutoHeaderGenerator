
﻿using System;

namespace Boss_level_part_1
{
    internal class Program
    {
        static void GenerateIntersection(bool[,] roadPieces, int x, int y)
        {
            var random = new Random();
           
            for (int i = 0; i < 4; i++)
            {
                int chance = random.Next(100);

                if (chance < 70)
                {
                    GenerateRoad(roadPieces, x, y, i);
                }
            }
           
        }
        static void GenerateRoad(bool[,] roadPieces, int startX, int startY, int direction)
        {
            if (direction == 0)
            {
                for (int x = startX; x <= roadPieces.GetLength(0) - 1; x++)
                {
                    roadPieces[x, startY] = true;
                }
            }
            else if (direction == 1)
            {
                for (int y = startY; y <= roadPieces.GetLength(1) - 1; y++)
                {
                    roadPieces[startX, y] = true;
                }
            }
            else if (direction == 2)
            {
                for (int x = startX; x >= 0; x--)
                {
                    roadPieces[x, startY] = true;
                }
            }
            else
            {
                for (int y = startY; y >= 0; y--)
                {
                    roadPieces[startX, y] = true;
                }
            }
        }
        static void Main(string[] args)
        {
            var random = new Random();

            //Set map dimensions
            int width = 80;
            int height = 20;

            //Declare map
            bool[,] roadPieces = new bool[width, height];

            //Generate roads
            for (int i = 0; i < 3; i++)
            {
                GenerateIntersection(roadPieces, random.Next(width), random.Next(height));
            }
            
            //Draw map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (roadPieces[x, y] && roadPieces[x, y])
                    {
                        Console.Write("═");
                    }


                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            } 
        } // if (roadPieces[x, y] && roadPieces[x + 1, y]

    }
}