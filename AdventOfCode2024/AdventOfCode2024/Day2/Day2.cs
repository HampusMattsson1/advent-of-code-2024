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
            var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day2\Example.txt");
            //var Day1Path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day2.txt");

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

                if (report.Length >= 2)
                {
                    bool increase = false;

                    if (report[0] < report[1])
                    {
                        increase = true;
                    }

                    int current = report[0];

                    for (int j = 1; j < report.Length; j++)
                    {
                        if (increase)
                        {
                            if (report[j] <= current)
                                safeReport = false;
                        }
                        else
                        {
                            if (report[j] >= current)
                                safeReport = false;
                        }

                        
                    }
                }
                else
                {
                    safeReport = false;
                }

                if (safeReport)
                    safeReports++;
            }

            Console.WriteLine("SAFE REPORTS: " + safeReports);

            return 0;
        }
    }
}
