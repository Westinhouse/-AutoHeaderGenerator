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
            string monsterManual = File.ReadAllText("