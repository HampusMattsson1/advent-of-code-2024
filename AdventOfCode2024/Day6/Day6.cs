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

namespace AdventOfCode2024.Day6
{
    public class Day6
    {
        public class Guard
        {
            public Point position = new Point();
            public char guard;
		};

        public void Main()
        {
            //var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day6/Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day6", "Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day6.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 6");

            Part1(input);
            //Part2(input);
        }

        void Part2(string[] rows)
        {
			int height = rows.Length;
			int width = rows[0].Length;

			// Create 2D array
			char[,] array = Create2dArray(rows, height, width);

			var guard = new Guard();

			guard.position = GetInitialGuardPosition(array, height, width);
			guard.guard = array[guard.position.Y, guard.position.X];

			List<Point> positions = new();

            // Testa lägga obstacles och se ifall det blir oändlighetsloop
            int possibleLoopCombinations = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = '#';
                    if (InfiniteLoop(array, guard))
                        possibleLoopCombinations++;
                }
            }

			while (guard.position.X != -1 && guard.position.Y != -1)
			{
				guard = UpdateGuard(array, guard, height, width);

				positions.Add(guard.position);
			}

			Console.WriteLine("Total positions: " + positions.Count);
			Console.WriteLine("Total distinct positions: " + positions.Distinct().Count());
		}

        bool InfiniteLoop(char[,] array, Guard guard)
		{

        }

        void Part1(string[] rows)
        {
            int height = rows.Length;
            int width = rows[0].Length;

            // Create 2D array
            char[,] array = Create2dArray(rows, height, width);

            var guard = new Guard();

            guard.position = GetInitialGuardPosition(array, height, width);
            guard.guard = array[guard.position.Y, guard.position.X];

            List<Point> positions = new();

            while (guard.position.X != -1 && guard.position.Y != -1)
            {
                guard = UpdateGuard(array, guard, height, width);

                positions.Add(guard.position);
            }

			Console.WriteLine("Total positions: " + positions.Count);
			Console.WriteLine("Total distinct positions: " + positions.Distinct().Count());
		}

		Guard UpdateGuard(char[,] array, Guard guard, int height, int width)
        {
            Point position = guard.position;

            Point vector = new Point(guard.position.X, guard.position.Y);

			// Check if out of bounds == end
			if (vector.X < 0 || vector.X >= width || vector.Y < 0 || vector.Y >= height)
			{
				guard.position = new Point(-1, -1);
                return guard;
			}

            try
            {
                switch (guard.guard)
                {
                    case '^':
                        if (array[position.Y - 1, position.X] == '#')
                        {
                            vector.X += 1;
							guard.guard = '>';
						}
                        else
                        {
                            vector.Y -= 1;
                        }
                        break;
                    case 'v':
                        if (array[position.Y + 1, position.X] == '#')
                        {
                            vector.X -= 1;
							guard.guard = '<';
						}
                        else
                        {
                            vector.Y += 1;
                        }
                        break;
                    case '<':
                        if (array[position.Y, position.X - 1] == '#')
                        {
                            vector.Y -= 1;
							guard.guard = '^';
						}
                        else
                        {
                            vector.X -= 1;
                        }
                        break;
                    case '>':
                        if (array[position.Y, position.X + 1] == '#')
                        {
                            vector.Y += 1;
							guard.guard = 'v';
						}
                        else
                        {
                            vector.X += 1;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
				guard.position = new Point(-1, -1);
				return guard;
			}
			

            guard.position = vector;

            return guard;
		}

        //char GetChar(char[,] array, Point position)
        //{
        //    return array[position.Y, position.X];
        //}

        char[,] Create2dArray(string[] rows, int height, int width)
        {
            // Create the 2D array
            char[,] array = new char[height, width];

            // Fill the 2D array with the characters from the rows
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }

        Point GetInitialGuardPosition(char[,] array, int height, int width)
        {
            Point position = new Point(-1,-1);
            char[] guardChars = ['^','<','>','v'];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char c = array[i,j];
                    if (guardChars.Contains(c))
                    {
                        position.X = j;
                        position.Y = i;
                        break;
                    }
                }
            }

            return position;
        }

    }
}
