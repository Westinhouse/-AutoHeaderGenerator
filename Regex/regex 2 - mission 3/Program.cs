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
            char[] deli