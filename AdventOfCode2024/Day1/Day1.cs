using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2024.Day1
{
    public class Day1
    {
        public void Main()
        {
            //var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day1\Example.txt");
            var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day1.txt");

            var input = File.ReadAllLines(Day1Path);

            Part2(input);
        }

        int Part2(string[]? input)
        {
            var leftSideTotal = input.Select(x => { return Int32.Parse(x.Split("   ")[0]); }).ToArray();
            var rightSideTotal = input.Select(x => { return Int32.Parse(x.Split("   ")[1]); }).ToArray();

            int totalSimilarity = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int left = leftSideTotal[i];

                int rightEquivallents = rightSideTotal.Count(x => x == left);

                int similarity = left * rightEquivallents;

                totalSimilarity += similarity;
                //Console.WriteLine(similarity);
            }

            Console.WriteLine("TOTAL SIMILARITY: " + totalSimilarity);

            return totalSimilarity;
        }


        internal int Part1(string[]? input)
        {
            var leftSideTotal = input.Select(x => { return Int32.Parse(x.Split("   ")[0]); }).OrderBy(x => x).ToArray();
            var rightSideTotal = input.Select(x => { return Int32.Parse(x.Split("   ")[1]); }).OrderBy(x => x).ToArray();

            int totalDiff = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var left = leftSideTotal[i];
                var right = rightSideTotal[i];

                int diff = left - right;

                if (diff < 0)
                {
                    diff = diff * -1;
                }

                totalDiff += diff;
            }

            Console.WriteLine("TOTAL DIFF: " + totalDiff);
            return totalDiff;
        }
    }
}
