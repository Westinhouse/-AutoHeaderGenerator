using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace regex_2___mission_3
{
    internal class Program
    {

        static List<string> monsterNames = new List<string>();

        static void Main(string[] args)
        {
            //Setting up the list of strings that is the monster manual
            string[] monsterManual = File.ReadAllLines("MonsterManual.txt");

            //Initalizing the list that will store the alignments
            List<string> alignment = new List<string>();

            //Setting which character we will split the string at later
            char[] delimiterChars = { ',' };

            //Let's go trough the list line by line
            for (int i = 0; i < monsterManual.Length; i++)
            {
                //If we find a line that contains a specified alignment, do the following
                if (Regex.IsMatch(monsterManual[i], 