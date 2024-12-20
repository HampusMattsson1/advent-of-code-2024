﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3
{
    public class Day3
    {
        public void Main()
        {
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day3", "Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day3.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 3");

            //Part1(input);
            Part2(input);
        }



        internal int Part1(string[]? input)
        {
            var regex = new Regex("mul\\(\\d+,\\d+\\)", RegexOptions.IgnoreCase);

            int result = 0;

            foreach(var line in input)
            {
                var matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    string expression = match.ToString();

                    int leftDigit = Int32.Parse(new Regex("\\d+").Matches(expression)[0].ToString());
                    int rightDigit = Int32.Parse(new Regex("\\d+").Matches(expression)[1].ToString());

                    result += leftDigit * rightDigit;

                    //Console.WriteLine("MATCH, " + match.ToString());
                }
            }

            Console.WriteLine("DAY 1 Part 1 Result: " + result);

            return 0;
        }

        internal int Part2(string[] input)
        {
            var regex = new Regex("mul\\(\\d+,\\d+\\)", RegexOptions.IgnoreCase);

            int result = 0;

            bool performMultiplication = true;

            foreach (var line in input)
            {
                var matches = regex.Matches(line);
                //var doMatches = new Regex("do\\(\\)").Matches(line);
                //var dontMatches = new Regex("don't\\(\\)").Matches(line);

                var performMatches = new Regex("do\\(\\)|don't\\(\\)").Matches(line);

                foreach (Match match in matches)
                {
                    // Check if the expression should be calculated
                    int matchIndex = match.Index;
                    Match? closestPerform = performMatches.Where(m => m.Index < matchIndex).OrderByDescending(v => v.Index).FirstOrDefault();

                    if (performMultiplication)
                    {
                        // Look for don'ts
                        if (closestPerform?.ToString() == "don't()")
                        {
                            performMultiplication = false;
                        }
                    }
                    else
                    {
                        // Look for do's
                        if (closestPerform?.ToString() == "do()")
                        {
                            performMultiplication = true;
                        }
                    }

                    
                    if (performMultiplication)
                    {
                        string expression = match.ToString();

                        int leftDigit = Int32.Parse(new Regex("\\d+").Matches(expression)[0].ToString());
                        int rightDigit = Int32.Parse(new Regex("\\d+").Matches(expression)[1].ToString());

                        result += leftDigit * rightDigit;
                    }
                    //Console.WriteLine("MATCH, " + match.ToString());
                }
            }

            Console.WriteLine("DAY 1 Part 2 Result: " + result);

            return 0;
        }
    }
}
