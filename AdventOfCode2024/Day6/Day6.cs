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
        public void Main()
        {
            var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day6/Example.txt");
            // var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day6", "Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day6.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 6");

            Part1(input);
            //Part2(input);
        }


        void Part1(string[] rows)
        {
            int height = rows.Length;
            int width = rows[0].Length;

            // Create 2D array
            char[,] array = Create2dArray(rows, height, width);

            Point position = GetInitialGuardPosition(array, height, width);
            var guard = array[position.Y, position.X];

        }

        Point MoveGuard(char[,] array, Point position, Point movement)
        {
            return new Point(-1,-1);
        }

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
