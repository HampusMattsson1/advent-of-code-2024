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

            // Find all antennas
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

            // Loop through all antennas and find antinodes for each combination
            foreach (var antennaType in groupedAntennas)
            {
                foreach(var antenna in antennaType)
                {
                    // Find all other antennas
                    foreach (var otherAntenna in antennaType.Where(a => a.Value != antenna.Value))
                    {
                        var antinodes = FindAntinodes(antenna.Value, otherAntenna.Value);
                        
                        Point antiNode1 = antinodes[0];
                        Point antiNode2 = antinodes[1];

                        // rows[antiNode1.Y][antiNode1.X] = '#';
                        string newRow;

                        newRow = rows[antiNode1.Y].Substring(0, antiNode1.X - 1) + '#' + rows[antiNode1.Y].Substring(antiNode1.X + 1);
                        rows[antiNode1.Y] = newRow;

                        newRow = rows[antiNode2.Y].Substring(0, antiNode2.X - 1) + '#' + rows[antiNode2.Y].Substring(antiNode2.X + 1);
                        rows[antiNode2.Y] = newRow;
                    }
                }
                var a = 2;
            }

			Console.WriteLine("Part 1 result sum: " + result);
        }

        List<Point> FindAntinodes(Point antenna1, Point antenna2)
        {
            List<Point> result = new();

            Point distance = new();
            
            distance.X = Math.Abs(antenna1.X - antenna2.X);
            distance.Y = Math.Abs(antenna1.Y - antenna2.Y);

            Point antiNode1 = new Point(antenna1.X + distance.X, antenna1.Y + distance.Y);
            Point antiNode2 = new Point(antenna2.X + distance.X, antenna2.Y + distance.Y);

            result.Add(antiNode1);
            result.Add(antiNode2);

            return result;
        }
        
    }
}
