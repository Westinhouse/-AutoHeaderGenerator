
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

            for (int y = 0; y < height; y++)
            {
                CurveDirection direction = GetRandomDirection(curveChance);

                if (direction != CurveDirection.Straight)
                {
                    if (direction == CurveDirection.Right)
                    {
                        ++currentCurveX;
                    }
                    else
                    {
                        --currentCurveX;
                    }
                }

                curveValues.Add(currentCurveX);

            }
            return curveValues;

        }
        static void CreateMap()
        {

            // Generating Wall
            wallXPositionsList = GenerateCurve(width * 1 / 4, 12);

            // Generating the river
            riverXPositionsList = GenerateCurve(width * 3 / 4, 3);


            // Generating the road that goes left to right
            int roadStartY = height / 2;
            int currentRoadY = roadStartY;
            for (int x = 0; x < width; x++)
            {

                /* This section checks if the current position is close to another map element,
                 * and if so, set a boolean to tell the later section that this position is close to another map element*/
                bool isCloseToMapElement = false;

                for (int n = -3; n <= 5; n++)
                {
                    if (riverXPositionsList.Contains(x + n) || wallXPositionsList.Contains(x + n))
                    {
                        isCloseToMapElement = true;
                        break;
                    }
                }

                CurveDirection roadDirection = GetRandomDirection(8);

                if (roadDirection != CurveDirection.Straight && !isCloseToMapElement) // if we are not close to an object, the road can curve.
                {
                    if (roadDirection == CurveDirection.Right)
                    {
                        ++currentRoadY;
                    }
                    else
                    {
                        --currentRoadY;
                    }
                }

                roadLeftRightYPositionsList.Add(currentRoadY);
            }
            return;
        }

        static void DrawMap()
        {

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    /*Drawing the borders by checking if the current position "x" is equal to 0 or the width. 
                     * similar with "y", is it 0 or the height?*/

                    if (x == 0 && y == 0 || x == width - 1 && y == height - 1 || x == width - 1 && y == 0 || x == 0 && y == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("+");
                        continue;
                    }
                    else if (x == 0 || x == width - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|");
                        continue;
                    }
                    else if (y == 0 || y == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                        continue;
                    }

                    /* Positioning and Drawing the title, and making sure that the title doesnt "push" 
                     * the map positions weirdly by moving the current x position in the algorithm
                     * forward based on the lenght of the string*/

                    if (x == width / 2 - mapTitle.Length / 2 && y == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(mapTitle);
                        x += mapTitle.Length - 1;
                        continue;
                    }

                    // Drawing the bridge, we check if the road and river are intersecting, or will intersect in the coming coordinates.
                    if (x >= riverXPositionsList[y] - 1 && x <= riverXPositionsList[y] + 3 && y + 1 == roadLeftRightYPositionsList[x] || x >= riverXPositionsList[y] - 1 && x <= riverXPositionsList[y] + 3 && y - 1 == roadLeftRightYPositionsList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("=");
                        continue;
                    }

                    //Drawing the road that leads down by checking if we are 5 steps before from the river and past the road on the y axis.
                    if (x == riverXPositionsList[y] - 5 && y > roadLeftRightYPositionsList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#");
                        continue;
                    }

                    //Drawing the road that goes left to right
                    if (roadLeftRightYPositionsList[x] == y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#");
                        continue;
                    }

                    //Drawing the turrets, using a similar technique as when drawing the title to ensure correct positioning.
                    if (x == wallXPositionsList[y] && y + 1 == roadLeftRightYPositionsList[x] || x == wallXPositionsList[y] && y - 1 == roadLeftRightYPositionsList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(turretShape);
                        x += turretShape.Length - 1;
                        continue;
                    }

                    //Drawing the wall
                    if (x >= wallXPositionsList[y] && x <= wallXPositionsList[y] + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        DrawCurve(wallXPositionsList, y);
                        continue;
                    }


                    // Drawing the trees
                    double treeDensity = (double)-x / (width / 4) + 1;
                    double treeRoll = random.NextDouble();
                    if (treeRoll < treeDensity)
                    {
                        int treeColor = random.Next(2);

                        if (treeColor == 1)
                        {
                            Console.ForegroundColor = treeConsoleColor;
                        }
                        else
                        {
                            Console.ForegroundColor = darkTreeConsoleColor;
                        }
                        Console.Write($"{treeSymbolsList[random.Next(treeSymbolsList.Count)]}");
                        continue;
                    }


                    //Drawing the river
                    if (x >= riverXPositionsList[y] && x <= riverXPositionsList[y] + 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        DrawCurve(riverXPositionsList, y);
                        continue;
                    }

                    // Drawing mountains
                    int mountain = random.Next(x);
                    if (mountain > width / 2 && y < roadLeftRightYPositionsList[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("^");
                        continue;
                    }




                    //Filling in space thats not drawn with blanks
                    Console.Write(" ");


                }
                Console.WriteLine(); //ensuring line breaks at the end of the x-axis
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateMap();
            DrawMap();
        }
    }
}


