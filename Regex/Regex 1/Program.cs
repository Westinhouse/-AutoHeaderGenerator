using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Regex_1
{
    internal class Program
    {

        static List<string> monsterNames = new List<string>();

        static void Main(string[] args)
        {

            string[] monsterManual = File.ReadAllLines("MonsterManual.txt");
            monsterNames.Add(monsterManual[0]);
            List<bool> CanFly = new List<bool>();
            List<bool> IsTenDiceOrMore = new List<bool>();


            for (int i = 0; i < monsterManual.Length; i++)
            {

                if (monsterManual[i] == "")
      