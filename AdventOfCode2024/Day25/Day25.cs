using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AdventOfCode2024.Days
{
    public class Day25
    {
        public void Main()
        {
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day25\Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day25.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 25");

            Part1(input);
            //Part2(input);
        }

        void Part1(string[] input)
        {
            Console.WriteLine("Part 1");

            var locks = new List<int[]> { new int[5] };
            var keys = new List<int[]> { new int[5] };

            int index = 0;
            int keyholeIndex = 0;

            while (index < input.Length)
            {
                if (input[index] == "")
                {
                    keyholeIndex++;
                    locks.Add(new int[5]);
                    keys.Add(new int[5]);
                    index++;
                    continue;
                }

                for (int i = 0; i < input[index].Length; i++) {
                    var blocked = IsBlocked(input[index][i]);

                    if (blocked) {
                        locks[keyholeIndex][i] += 1;
                    } else {
                        keys[keyholeIndex][i] += 1;
                    }
                    //locks[lockIndex][i] = blocked == true ? 1 : ;
                }

                Console.WriteLine(input[index]);
                index++;
            }

            Console.WriteLine("Result: ");
        }

        bool IsBlocked(char c)
        {
            if (c == '#')
                return true;

            return false;
        }

    }
}
