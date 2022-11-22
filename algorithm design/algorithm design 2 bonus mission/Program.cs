using System;
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
        