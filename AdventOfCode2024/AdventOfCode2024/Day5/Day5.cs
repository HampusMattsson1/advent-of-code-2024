using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day5
{
    public class Day5
    {
        public void Main()
        {
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day5", "Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day5.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 5");

            Part1(input);
            //Part2(input);
        }


        void Part1(string[] rows)
        {
            var tableRows = rows.TakeWhile(r => r != "").ToList();

            var inputRows = rows.Where((e, i) => i > tableRows.Count).ToList();

            foreach (var row in inputRows)
            {
                var pages = row.Split(',');

                foreach (var page in pages)
                {

                }
            }
        }

    }
}
