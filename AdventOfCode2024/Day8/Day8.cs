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

            // Part 1
			//Solution(input);

            // Part 2
			Solution(input, true);
		}


        void Solution(string[] rows, bool part2 = false)
        {
            int height = rows.Length;
            int width = rows[0].Length;

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

						var antiNodes = FindAntinodes(antenna.Value, otherAntenna.Value, width, height, part2);

                        foreach (Point antiNode in antiNodes)
                        {
                            if (ValidAntiNode(antiNode, width, height))
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

			Console.WriteLine("Result: " + antiNodeLocations.Distinct().Count());

            File.WriteAllLines(@"C:\Temp\Day8Result.txt", rows);
        }

        List<Point> FindAntinodes(Point antenna1, Point antenna2, int width, int height, bool part2)
        {
            List<Point> result = new();

            Point distance = new();
            
            distance.X = Math.Abs(antenna1.X - antenna2.X);
            distance.Y = Math.Abs(antenna1.Y - antenna2.Y);

			// First direction
			Point antiNode = antenna1;
            Point compareNode = antenna2;

			while (ValidAntiNode(antiNode, width, height))
			{
                Point antiNodeBefore = new();
				antiNodeBefore.X = antiNode.X;
				antiNodeBefore.Y = antiNode.Y;
				antiNode = GetAntiNode(antiNode, compareNode, distance);
				compareNode = antiNodeBefore;

				result.Add(new Point(antiNode.X, antiNode.Y));

                if (part2 == false)
                    break;
			}

			// Second direction
			antiNode = antenna2;
			compareNode = antenna1;

			while (ValidAntiNode(antiNode, width, height))
			{
				Point antiNodeBefore = new();
				antiNodeBefore.X = antiNode.X;
				antiNodeBefore.Y = antiNode.Y;
				antiNode = GetAntiNode(antiNode, compareNode, distance);
                compareNode = antiNodeBefore;

				result.Add(new Point(antiNode.X, antiNode.Y));

				if (part2 == false)
					break;
			}

            if (part2)
            {
				result.Add(new Point(antenna1.X, antenna1.Y));
				result.Add(new Point(antenna2.X, antenna2.Y));
			}

			return result;
        }

        Point GetAntiNode(Point antiNode, Point antenna2, Point distance)
        {

			if (antiNode.X + distance.X == antenna2.X)
			{
				antiNode.X = antiNode.X - distance.X;
			}
			else
			{
				antiNode.X = antiNode.X + distance.X;
			}

			if (antiNode.Y + distance.Y == antenna2.Y)
			{
				antiNode.Y = antiNode.Y - distance.Y;
			}
			else
			{
				antiNode.Y = antiNode.Y + distance.Y;
			}

            return antiNode;
		}

        bool ValidAntiNode(Point antiNode, int width, int height)
        {
            if (antiNode.X >= 0 && antiNode.X < width && antiNode.Y >= 0 && antiNode.Y < height)
            {
                return true;
			}

            return false;
		}
        
    }
}
