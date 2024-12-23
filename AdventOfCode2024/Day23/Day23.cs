using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2024.Day23
{
    public class Day23
    {
        public void Main()
        {
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day23\Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day23.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 23");

            Part1(input);
            //Part2(input);
        }


        internal void Part1(string[] input)
        {
            List<string> result = new();

            List<KeyValuePair<string, string>> nodeList = new();

            foreach (var line in input)
            {
                Console.WriteLine(line);

                string[] nodes = line.Split('-');

                nodeList.Add(new KeyValuePair<string, string>(nodes[0], nodes[1]));
                nodeList.Add(new KeyValuePair<string, string>(nodes[1], nodes[0]));
            }

            foreach (var nodePair in nodeList)
            {
                var primaryNode = nodePair.Key;
                var secondaryNode = nodePair.Value;

                // Loopa alla andra noder som är kopplade till secondaryNode
                foreach (var node in nodeList.Where(n => n.Key == secondaryNode))
                {
                    if (nodeList.Where(n => n.Key == node.Value).Any(n => n.Value == primaryNode))
                    {
                        string[] sortArray = { primaryNode, secondaryNode, node.Value };

                        Array.Sort(sortArray);
                        string resultString = $"{sortArray[0]}-{sortArray[1]}-{sortArray[2]}";

                        if (!result.Contains(resultString)) {

                            if (sortArray[0][0] == 't' || sortArray[1][0] == 't' || sortArray[2][0] == 't')
                                result.Add(resultString);
                        }

                        //result.Add($"{primaryNode}-{secondaryNode}-{node.Value}");
                        //result.Add($"{sortArray[0]}-{sortArray[1]}-{sortArray[2]}");
                    }
                }
            }

			Console.WriteLine("Result: " + result.Count);
        }
    }
}
