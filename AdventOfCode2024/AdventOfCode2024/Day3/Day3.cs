using System;
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
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day3", "Example.txt");
            // var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day2.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 3");

            Part1(input);
            //Part2(input);
        }



        internal int Part1(string[]? input)
        {
            var regex = new Regex("xmul\\(\\d,\\d\\)", RegexOptions.IgnoreCase);

            foreach(var line in input)
            {
                var matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    Console.WriteLine("MATCH, " + match.ToString());
                }
            }

            return 0;
        }

        
    }
}
