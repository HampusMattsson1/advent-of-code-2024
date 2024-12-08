using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Buffers;
using System.Numerics;
using System.Windows;

namespace AdventOfCode2024.Day8
{
    public class Day8
    {
        public void Main()
        {
            var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day8/Example.txt");
            // var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/PuzzleInputs/Day7.txt");
            // var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day6", "Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day6.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 8");

            Part1(input);
            //Part2(input);
        }


        void Part1(string[] rows)
        {
            long result = 0;

            List<KeyValuePair<char, Point>> antennas = new();

            for(int i = 0; i < rows.Length; i++)
            {
                var line = rows[i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] != '#' && line[j] != '.')
                    {
                        antennas.Add(new KeyValuePair<char, Point>(line[j], new Point(i, j)));
                    }
                }
            }

            var groupedAntennas = antennas.GroupBy(a => a.Key).ToList();

			Console.WriteLine("Part 1 result sum: " + result);
        }

        List<Point> FindAntinodes(Point antenna1, Point antenna2)
        {
            List<Point> result = new();



            return result;
        }
        
    }
}
