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
            var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day5/Example.txt");
            // var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/PuzzleInputs/Day5.txt");
            // var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day5", "Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day5.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 5");

            Part1(input);
            //Part2(input);
        }


        void Part1(string[] rows)
        {
            var tableRows = rows.TakeWhile(r => r != "").ToList();

            List<KeyValuePair<string, string>> tableLookupBefore = tableRows.Select(r => new KeyValuePair<string, string>(r.Split('|')[1], r.Split('|')[0])).ToList();
            List<KeyValuePair<string, string>> tableLookupAfter = tableRows.Select(r => new KeyValuePair<string, string>(r.Split('|')[0], r.Split('|')[1])).ToList();

            var inputRows = rows.Where((e, i) => i > tableRows.Count).ToList();

            int correctRows = 0;
            int result = 0;

            foreach (var row in inputRows)
            {
                var pages = row.Split(',');

                bool correct = true;

                for (int i = 0; i < pages.Length; i++)
                {
                    string page = pages[i];

                    var followingPages = pages.Skip(i+1).ToList();
                    var previousPages = pages.Take(i+1).ToList();

                    // Ingen page framför får ha nuvarande page framför sig
                    if (LookupContainsValue(page, followingPages, tableLookupAfter))
                        correct = false;

                    // Ingen page bakom får ha nuvarande page bakom sig
                    if (LookupContainsValue(page, previousPages, tableLookupBefore))
                        correct = false;
                }

                if (correct)
                {
                    correctRows++;
                    result += Int32.Parse(pages[pages.Length/2]);
                }
            }

            Console.WriteLine("Day 5 Part 1 correctRows: " + correctRows);
            Console.WriteLine("Day 5 Part 1 result: " + result);
        }

        bool LookupContainsValue(string page, List<string> pages, List<KeyValuePair<string, string>> tableLookup)
        {
            bool valid = false;

            foreach (var checkPage in pages)
            {
                var followingPageLookup = tableLookup.Where(t => t.Key == checkPage).Select(t => t.Value).ToList();

                if (followingPageLookup.Contains(page))
                {
                    valid = true;
                }
            }

            return valid;
        }

    }
}
