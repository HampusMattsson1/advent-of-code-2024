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

            //Dictionary<string, string> tableLookup = tableRows.ToDictionary(r => r.Split('|')[0], r => r.Split('|')[1]);
            List<KeyValuePair<string, string>> tableLookup = tableRows.Select(r => new KeyValuePair<string, string>(r.Split('|')[0], r.Split('|')[1])).ToList();

            var inputRows = rows.Where((e, i) => i > tableRows.Count).ToList();

            int correctRows = 0;

            foreach (var row in inputRows)
            {
                var pages = row.Split(',');

                bool correct = true;

                //foreach (var page in pages)
                for (int i = 0; i < pages.Length; i++)
                {
                    string page = pages[i];

                    // Lookup
                    var lookup = tableLookup.Where(t => t.Key == page).Select(t => t.Value).ToList();

                    var followingPages = pages.Skip(i+1).ToList();

                    // Check if correct pages are behind

                    // Check if correct pages are in front

                    // Check each lookup
                    foreach (var look in lookup)
                    {
                        correct = LookupContainsValue(page, followingPages, tableLookup);
                    }

                    //if (1 == 1)
                    //{
                    //    correct = false;
                    //}
                }

                if (correct)
                    correctRows++;
            }

            Console.WriteLine("Day 5 Part 1 result: " + correctRows);
        }

        bool LookupContainsValue(string page, List<string> followingPages, List<KeyValuePair<string, string>> tableLookup)
        {
            bool valid = true;

            foreach (var followingPage in followingPages)
            {
                var followingPageLookup = tableLookup.Where(t => t.Key == followingPage).Select(t => t.Value).ToList();

                if (followingPageLookup.Contains(page))
                {
                    valid = false;
                }
            }

            return valid;
        }

    }
}
