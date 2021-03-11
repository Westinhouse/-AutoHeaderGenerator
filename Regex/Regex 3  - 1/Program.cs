using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_3____1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] monsterManualLines = File.ReadAllLines("MonsterManual.txt");
            string monsterManual = File.ReadAllText("MonsterManual.txt");

            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();



            for (int axis1Index = 0; axis1Index < 3; axis1Index++)
            {
                for (int axis2Index = 0; axis2Index < 3; axis2Index++)
                {
                    namesByAlignment[axis1Index, axis2Index] = new List<string>();
                }
            }
            string[] axis1Values = new[] { "chaotic", "neutral", "lawful" };
            string[] axis2Values = new[] { "evil", "neutral", "good" };

            for (int i = 0; i < monsterManualLines.Length; i++)
            {
                Match match = Regex.Match(monsterManualLines[i], @"((chaotic|neutral|lawful) (evil|neutral|good)|neutral)");
                if (match.Success)
                {
                    string monsterName = monsterManualLines[i - 1];

                    if (match.Groups[1].Value == "neutral")
                    {
                        namesByAlignm