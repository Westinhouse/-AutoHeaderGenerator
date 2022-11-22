﻿using System;
using System.Collections.Generic;

namespace algorithm_design_2_bonus_mission
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            PrintResult(
                Permute(new int[] { 1, 2, 3 })
            );
        }

        static IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            return DoPermute(nums, 0, nums.Length - 1, list);
        }

        static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list)
        {
            if (start == end)
            {
                // We have one of our possible n! solutions,
                //