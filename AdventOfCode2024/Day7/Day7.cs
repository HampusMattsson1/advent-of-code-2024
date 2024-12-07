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

namespace AdventOfCode2024.Day7
{
    public class Day7
    {
        public void Main()
        {
            // var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day7/Example.txt");
            //var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/PuzzleInputs/Day7.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day7", "Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day7.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 7");

            //Part1(input);
            Part2(input);
        }


		void Part2(string[] rows)
		{
			long result = 0;

			for (int i = 0; i < rows.Length; i++)
			{
				var line = rows[i];

				long expectedResult = Int64.Parse(line.Split(": ")[0]);

				int[] numbers = line.Split(": ")[1].Split(" ").Select(s => Int32.Parse(s)).ToArray();

				result += ResultPossible(numbers, expectedResult, 3);
			}

			Console.WriteLine("Part 2 result sum: " + result);
		}

		void Part1(string[] rows)
        {
            long result = 0;

            for(int i = 0; i < rows.Length; i++)
            {
                var line = rows[i];

                long expectedResult = Int64.Parse(line.Split(": ")[0]);

                int[] numbers = line.Split(": ")[1].Split(" ").Select(s => Int32.Parse(s)).ToArray();

                result += ResultPossible(numbers, expectedResult);
            }

			Console.WriteLine("Part 1 result sum: " + result);
        }

        long ResultPossible(int[] numbers, long expectedResult, int operators = 2)
        {
            int gapsForOperators = numbers.Length - 1;

            int possibleCombinations = (int)Math.Pow(operators, gapsForOperators);

            for (int i = 0; i < possibleCombinations; i++)
            {
                //string binaryString = Convert.ToString(i, 2).PadLeft(gapsForOperators, '0');
                string binaryString;
                if (operators > 2)
                {
					binaryString = ConvertToTernary(i).PadLeft(gapsForOperators, '0');
				}
                else
                {
					binaryString = Convert.ToString(i, 2).PadLeft(gapsForOperators, '0');
				}

				// Create the string to calculate
				long result = numbers[0];
                for (int j = 1; j < numbers.Length; j++)
                {
                    int prev = j - 1;
                    result = Calculate(result, numbers[j], binaryString[prev]);
                }

                if (result == expectedResult)
                {
                    return result;
                }
            }

            return 0;
        }

		string ConvertToTernary(int number)
		{
			if (number == 0) return "0";
			string result = "";
			while (number > 0)
			{
				result = (number % 3).ToString() + result;
				number /= 3;
			}
			return result;
		}

		long Calculate(long num1, int num2, char op)
        {
            // char[] operators = {'+', '*'};

            switch (op)
            {
                case '0':
					return num1 + num2;
                case '1':
					return num1 * num2;
                case '2':
                    return Int64.Parse(num1.ToString() + num2.ToString());
			}

            return 0;
        }
    }
}
