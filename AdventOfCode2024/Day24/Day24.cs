using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AdventOfCode2024.Day24
{
    public class Day24
    {
        public void Main()
        {
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day24\Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day24.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 24");

            Part1(input);
            //Part2(input);
        }


        internal void Part1(string[] input)
        {
            Dictionary<string, bool> gateMap = new();

            // Map up gatemap with values we know
            foreach (var line in input)
            {
                if (line == "")
                    break;

                Console.WriteLine(line);
                string name = line.Split(": ")[0];
                bool value = Convert.ToBoolean(Convert.ToInt16(line.Split(": ")[1]));

                gateMap[name] = value;
            }

            var a = 2;
        }

        bool PerformOperation(string input)
        {
            return true;
        }

    }
}
