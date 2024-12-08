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
            //var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day8/Example.txt");
            // var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/PuzzleInputs/Day7.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day8", "Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day8.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 8");

            Part1(input);
            //Part2(input);
        }


        void Part1(string[] rows)
        {
            List<KeyValuePair<char, Point>> antennas = new();

            // Find all antennas
            for(int i = 0; i < rows.Length; i++)
            {
                var line = rows[i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] != '#' && line[j] != '.')
                    {
                        antennas.Add(new KeyValuePair<char, Point>(line[j], new Point(j, i)));
                    }
                }
            }

            List<Point> antiNodeLocations = new();

            var groupedAntennas = antennas.GroupBy(a => a.Key).ToList();

            // Loop through all antennas and find antinodes for each combination
            foreach (var antennaType in groupedAntennas)
            {
                var processedPairs = new HashSet<(Point, Point)>();

				foreach (var antenna in antennaType)
                {
                    // Find all other antennas
                    foreach (var otherAntenna in antennaType)
                    {
						if (antenna.Value == otherAntenna.Value)
							continue;

						var pair = (antenna.Value, otherAntenna.Value);
						var reversePair = (otherAntenna.Value, antenna.Value);

						if (processedPairs.Contains(pair) || processedPairs.Contains(reversePair))
							continue;

						processedPairs.Add(pair);

						var antiNodes = FindAntinodes(antenna.Value, otherAntenna.Value);

                        foreach (Point antiNode in antiNodes)
                        {
                            if (CreateAntiNode(rows, antiNode))
                            {
								StringBuilder sb = new StringBuilder(rows[antiNode.Y]);
								sb[antiNode.X] = '#';
								rows[antiNode.Y] = sb.ToString();
								antiNodeLocations.Add(antiNode);
							}
						}
                    }
                }
            }

			Console.WriteLine("Part 1 result sum: " + antiNodeLocations.Distinct().Count());

            //File.WriteAllLines(@"C:\Temp\Day8Result.txt", rows);
        }

        List<Point> FindAntinodes(Point antenna1, Point antenna2)
        {
            List<Point> result = new();

            Point distance = new();
            
            distance.X = Math.Abs(antenna1.X - antenna2.X);
            distance.Y = Math.Abs(antenna1.Y - antenna2.Y);

            Point antiNode1 = new();
            Point antiNode2 = new();

            if (antenna1.X + distance.X == antenna2.X)
            {
                antiNode1.X = antenna1.X - distance.X;
			}
            else
            {
				antiNode1.X = antenna1.X + distance.X;
			}

			if (antenna2.X + distance.X == antenna1.X)
			{
				antiNode2.X = antenna2.X - distance.X;
			}
            else
            {
				antiNode2.X = antenna2.X + distance.X;
			}

			if (antenna1.Y + distance.Y == antenna2.Y)
			{
				antiNode1.Y = antenna1.Y - distance.Y;
			}
			else
			{
				antiNode1.Y = antenna1.Y + distance.Y;
			}

			if (antenna2.Y + distance.Y == antenna1.Y)
			{
				antiNode2.Y = antenna2.Y - distance.Y;
			}
			else
			{
				antiNode2.Y = antenna2.Y + distance.Y;
			}

			result.Add(antiNode1);
            result.Add(antiNode2);

            return result;
        }

        bool CreateAntiNode(string[] rows, Point antiNode)
        {
            if (antiNode.X >= 0 && antiNode.X < rows[0].Length && antiNode.Y >= 0 && antiNode.Y < rows.Length)
            {
                return true;
			}

            return false;
		}
        
    }
}
