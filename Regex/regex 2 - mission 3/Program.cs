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
                if (Regex.IsMatch(monsterManual[i], "(chaotic|neutral|lawful) (good|neutral|evil)"))
                {
                    //Store the whole line in a string
                    string text = monsterManual[i];

                    // Split the string using the comma(s)
                    string[] words = text.Split(delimiterChars);

                    //Go up one line to find the name of the monster, add it to the list of names
                    monsterNames.Add(monsterManual[i - 1]);

                    //Add the alignment. We want to trim the whitespace after the comma, and in some cases (shapeshifters) there are multiple commas in the line
                    //So we need to make sure to just grab the last part of the string and add it to the list of alignments
                    alignment.Add(words[words.Length - 1].Trim());

                }
            }
            //Print both lists (monster names and alignments)
            Console.WriteLine("Aligned monsters in the manual are:");

            for (int i = 0; i < monsterNames.Count; i++)
            {
                Console.WriteLine($"{monsterNames[i]} ({alignment[i]})");
                Console.WriteLine();
            }
        }
    }
}