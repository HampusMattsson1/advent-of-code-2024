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
            //var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day2\Example.txt");
            var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day2.txt");

            var input = File.ReadAllLines(Day1Path);

            Console.WriteLine("DAY 2");

            Part1(input);
        }


        internal int Part1(string[]? input)
        {
            int safeReports = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var report = input[i].Split(' ').Select(i => Int32.Parse(i)).ToArray();

                bool safeReport = true;

                if (IsSequence(report) == false)
                    safeReport = false;

                int currentValue = report[0];
                int difference = 0;

                for (int j = 1; j < report.Length; j++)
                {
                    difference += Math.Abs(currentValue - report[j]);

                    if (Math.Abs(currentValue - report[j]) > 2)
                    {
                        safeReport = false;
                    }

                    currentValue = report[j];
                }

                if (safeReport)
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);

            return 0;
        }

        internal bool IsSequence(int[] report)
        {
            int lastElement = report[0];
            //int currentElement = report[1];

            bool validIncrease = false;
            bool validDecrease = false;

            for (int i = 1; i < report.Length; i++)
            {
                if (report[i] >= lastElement)
                {
                    validIncrease = true;
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
