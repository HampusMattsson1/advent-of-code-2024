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
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day2\Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day2.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 2");

            //Part1(input);
            Part2(input);
        }


        internal int Part1(string[]? input)
        {
            int safeReports = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var report = input[i].Split(' ').Select(i => Int32.Parse(i)).ToArray();

                if (SafeReport(report))
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);

            return 0;
        }

        void Part2(string[]? input)
        {
            int safeReports = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var report = input[i].Split(' ').Select(i => Int32.Parse(i)).ToArray();

                bool safeReport = SafeReport(report);

                // If it's not a safe report, try removing each element and see if it is safe
                if (safeReport == false)
                {
                    for (int j = 0; j <  report.Length; j++)
                    {
                        int[] newReport = report.Where((_, i) => i != j).ToArray();

                        if (SafeReport(newReport))
                        {
                            safeReport = true;
                            break;
                        }
                    }
                }

                if (safeReport)
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);
        }

        bool SafeReport(int[] report)
        {
            if (IsSequence(report) == false)
                return false;

            if (ValidDiff(report) == false)
                return false;

            return true;
        }

        bool ValidDiff(int[] report)
        {
            for (int j = 1; j < report.Length; j++)
            {
                if (Math.Abs(report[j - 1] - report[j]) > 3)
                {
                    return false;
                }
            }

            return true;
        }

        internal bool IsSequence(int[] report)
        {
            bool validIncrease = false;
            bool validDecrease = false;

            for (int i = 1; i < report.Length; i++)
            {
                if (report[i - 1] > report[i])
                {
                    validIncrease = true;
                }
                else if (report[i - 1] == report[i])
                {
                    return false;
                }
                else
                {
                    validDecrease = true;
                }
            }

            if (validIncrease == validDecrease)
            {
                return false;
            }

            return true;
        }
    }
}
