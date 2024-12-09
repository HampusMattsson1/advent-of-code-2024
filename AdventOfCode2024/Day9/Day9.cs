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

namespace AdventOfCode2024.Day9
{
    public class Day9
    {
        public void Main()
        {
			//var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/Day8/Example.txt");
			// var DayPath = Path.Combine("/home/hjm/Dokument/advent-of-code-2024/AdventOfCode2024/PuzzleInputs/Day7.txt");
			//var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day9", "Example.txt");
			var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day9.txt");

			var input = File.ReadAllText(DayPath);

            Console.WriteLine("DAY 9");

            // Part 1
            Part1(input);
        }


		void Part1(string input)
        {
            int id = 0;

			var indexIdDict = new Dictionary<int, int>();
            var output = new StringBuilder("");

            for (int i = 0; i < input.Length; i++)
            {
                var number = Int32.Parse(input[i].ToString());

                // File blocks
                if (i % 2 == 0)
                {
					//output.Append(String.Concat(Enumerable.Repeat(id.ToString(), number)));
					output.Append(String.Concat(Enumerable.Repeat('X', number)));

					for (int j = output.Length - number; j < output.Length; j++)
					{
						indexIdDict[j] = id;
					}
					
					id++;
				}
				// Empty blocks
				else
                {
                    output.Append(new string('.', number));
                }
			}

            Console.WriteLine("Ouput 1 complete");
			//Console.WriteLine("Output1: " + output.ToString());

			// Remove gaps
			string outputString;
			int lastNonPeriodIndex = -1;

			for (int i = 0; i < output.Length; i++)
            {
				if (output[i] == '.')
				{
					outputString = output.ToString();

					if (outputString.Substring(i, output.Length - i).All(o => o == '.'))
						break;

					for (int j = outputString.Length - 1; j >= 0; j--)
					{
						if (outputString[j] != '.')
						{
							lastNonPeriodIndex = j;
							break;
						}
					}

					output[i] = output[lastNonPeriodIndex];
                    output[lastNonPeriodIndex] = '.';

					indexIdDict[i] = indexIdDict[lastNonPeriodIndex];
				}
			}

			Console.WriteLine("Ouput 2 complete");
			//Console.WriteLine("Output2: " + output.ToString());
			//File.WriteAllText(@"C:\Temp\Day9Result.txt", output.ToString());


			long result = 0;

			// Calculate result
			for (int i = 0; i < output.Length; i++)
			{
				if (output[i] == '.')
					break;

				//result += Int32.Parse(output[i].ToString()) * i;
				result += indexIdDict[i] * i;
			}

			Console.WriteLine("Result: " + result);
		}

	}
}
