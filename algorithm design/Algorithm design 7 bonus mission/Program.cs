
﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Algorithm_design_7_bonus_mission
{
    internal class Program
    {
        static void DisplayData(List<int> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)