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
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day24\Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day24\Example2.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day24.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 24");

            Part1(input);
            //Part2(input);
        }


        internal void Part1(string[] input)
        {
            Dictionary<string, bool> gateMap = new();

            // Map up gatemap with values we know
            int index = 0;
            while (input[index] != "")
            {
                string line = input[index];
                Console.WriteLine(line);
                string name = line.Split(": ")[0];
                bool value = Convert.ToBoolean(Convert.ToInt16(line.Split(": ")[1]));

                gateMap[name] = value;
                index++;
            }

            index++;

            int operationStartIndex = index;

            int operationsToPerform = input.Length - index;

            int operationsPerformed = 0;

            while (operationsPerformed < operationsToPerform)
            {
                string[] lineSplit = input[index].Split(' ');

                string leftOperand = lineSplit[0];
                string rightOperand = lineSplit[2];
                string resultName = lineSplit[4];

                if (gateMap.ContainsKey(leftOperand) && gateMap.ContainsKey(rightOperand) && gateMap.ContainsKey(resultName) == false)
                {
                    gateMap[resultName] = PerformOperation(gateMap[leftOperand], gateMap[rightOperand], lineSplit[1]);
                    operationsPerformed++;
                }

                index++;

                if (index == input.Length)
                    index = operationStartIndex;
            }

            gateMap = gateMap.OrderByDescending(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);

            string result = "";

            foreach (KeyValuePair<string, bool> gate in gateMap.Where(g => g.Key.StartsWith("z")))
            {
                result += gate.Value == true ? '1' : '0';
            }

            Console.WriteLine("Result: " + result);
            Console.WriteLine("Result as decimal: " + Convert.ToInt64(result, 2));
        }

        bool PerformOperation(bool leftOperand, bool rightOperand, string operation)
        {
            switch (operation)
            {
                case "AND":
                    return leftOperand && rightOperand;
                case "OR":
                    return leftOperand || rightOperand;
                case "XOR":
                    return leftOperand ^ rightOperand;
            }

            return false;
        }

    }
}
