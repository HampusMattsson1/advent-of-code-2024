using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2024.Day2
{
    public class Day2
    {
        public void Main()
        {
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day2", "Example.txt");
            // var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day2.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 2");

            // Part1(input);
            Part2(input);
        }

        internal int Part2(string[] input)
        {
            int safeReports = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var report = input[i].Split(' ').Select(i => Int32.Parse(i)).ToList();

                int errorsInReport = 0;

                bool safeReport = true;

                bool usedTolerance = false;

                if (IsSequence(report.ToArray()) > -1)
                {
                    // Remove number from report
                    report.RemoveAt(IsSequence(report.ToArray()));
                    usedTolerance = true;
                    //errorsInReport++;
                }

                if (IsSequence(report.ToArray()) > -1)
                {
                    safeReport = false;
                }

                // Right check
                if (ValidDiff(report, usedTolerance) == false)
                {
                    safeReport = false;
                }

                Console.WriteLine("REPORT SAFE: " + safeReport);

                if (safeReport)
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);

            return 0;
        }

        bool ValidDiff(List<int> report, bool usedTolerance)
        {
            for (int j = 1; j < report.Count; j++)
            {
                if (Math.Abs(report[j - 1] - report[j]) > 3)
                {
                    int index;

                    // check which number is the issue (and it's not the last element in the loop)
                    if (j != report.Count - 1 && Math.Abs(report[j] - report[j+1]) > 3)
                    {
                        // This element is the issue
                        index = j;
                    }
                    else
                    {
                        // Previous element is the issue
                        index = j - 1;
                    }

                    if (usedTolerance == false)
                    {
                        report.RemoveAt(index);
                        usedTolerance = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal int Part1(string[]? input)
        {
            int safeReports = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var report = input[i].Split(' ').Select(i => Int32.Parse(i)).ToArray();

                bool safeReport = true;

                if (IsSequence(report) > -1)
                    safeReport = false;

                for (int j = 1; j < report.Length; j++)
                {
                    if (Math.Abs(report[j-1] - report[j]) > 3)
                    {
                        var compare = report[j - 1].ToString() + " " + report[j].ToString();
                        safeReport = false;
                    }
                }

                if (safeReport)
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);

            return 0;
        }

        internal int IsSequence(int[] report)
        {
            int increases = 0;
            int decreases = 0;
            int equals = 0;

            for (int i = 1; i < report.Length; i++)
            {
                if (report[i - 1] > report[i])
                {
                    increases++;
                }
                else if (report[i - 1] == report[i])
                {
                    equals++;
                }
                else
                {
                    decreases++;
                }

                if ((increases > 0 && decreases > 0) || equals > 0)
                {
                    //return Math.Min(increases, decreases) + equals;
                    return i;
                }
            }

            return -1;
        }
    }
}
