
﻿using System;
using System.Collections.Generic;

namespace Algorithm_design_3
{

    enum CurveDirection
    {
        Left,
        Right,
        Straight,
    }

    internal class Program
    {
        // Setting the height and width of the map
        static int width = 120;
        static int height = 60;

        static ConsoleColor treeConsoleColor = ConsoleColor.Green;
        static ConsoleColor darkTreeConsoleColor = ConsoleColor.DarkGreen;

        static List<string> treeSymbolsList = new List<string> { "T", "X", "Z", "(", ")", "$", "C", "&", "@", "¤", "£" };

        static string mapTitle = ("ADVENTURE MAP");
        static string turretShape = ("[X]");

        //initializing lists that will store the values we will generate later. We use them for drawing the map.
        static List<int> roadLeftRightYPositionsList = new();
        static List<int> riverXPositionsList = new();
        static List<int> wallXPositionsList = new();

        static Random random = new Random();


        static CurveDirection GetRandomDirection(int curveChance)
        {
            int roll = random.Next(curveChance);

            switch (roll)
            {
                case 0:
                    return CurveDirection.Left;

                case 1:
                    return CurveDirection.Right;

                default:
                    return CurveDirection.Straight;
            }

        }

        /**
         * This section checks how a map element curves and ensures that the DrawMap method draws the appropriate symbol.
         */
        static void DrawCurve(List<int> curves, int position)
        {
            if (curves[position + 1] == curves[position] + 1)
            {
                Console.Write(@"\");
                return;
            }
            else if (curves[position + 1] == curves[position] - 1)
            {
                Console.Write("/");
                return;
            }
            else
            {
                Console.Write("|");
                return;
            }
        }
        static List<int> GenerateCurve(int position, int curveChance)
        {
            /* This method generates a list of integers that determine the curvature of a map element. 
             * The user should set the curve chance when they call the method.
             * a curve chance of 4 will mean that 50% of the time the road will not curve,
             * 25% of the time it curves left, 25% of the time it curves right.
             * only the two last digits in the chance range will cause the element to curve
             * so if you pass int 8 into curveChance, only on a 6 or 7 will the road curve
             * (8 is the exlusive upper bound of the random.Next method)*/

            int currentCurveX = position;
            var curveValues = new List<int>();