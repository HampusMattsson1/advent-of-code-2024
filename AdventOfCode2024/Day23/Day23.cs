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
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Day23\Example.txt");
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PuzzleInputs\Day23.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 23");

            Part1(input);
            //Part2(input);
        }


        internal void Part1(string[] input)
        {
            List<string> result = new();

            //List<KeyValuePair<string, string>> nodeList = new();
            Dictionary<string, List<string>> nodeList = new();

            foreach (var line in input)
            {
                //Console.WriteLine(line);

                string[] nodes = line.Split('-');

                if (nodeList.ContainsKey(nodes[0]))
                {
                    nodeList[nodes[0]].Add(nodes[1]);
                } else
                {
                    nodeList[nodes[0]] = new List<string> { nodes[1] };
                }

                if (nodeList.ContainsKey(nodes[1]))
                {
                    nodeList[nodes[1]].Add(nodes[0]);
                }
                else
                {
                    nodeList[nodes[1]] = new List<string> { nodes[0] };
                }
            }


            foreach (var nodePair in nodeList)
            {
                var primaryNode = nodePair.Key;
                var secondaryNode = nodePair.Value[0];

                List<string> connectedNodes = [nodePair.Key];

                // Loopa alla andra noder som är kopplade till secondaryNode
                foreach (var node in nodePair.Value)
                {
                    if (IsValidConnection(node, connectedNodes, nodeList))
                    {
                        connectedNodes.Add(node);
                    }

                    if (connectedNodes.Count == 3)
                        break;
                }

                //if (connectedNodes.Count > 2 && (connectedNodes[0][0] == 't' || connectedNodes[1][0] == 't' || connectedNodes[2][0] == 't'))
                if (connectedNodes.Count > 2)
                {
                    string[] nodeArray = connectedNodes.ToArray();

                    Array.Sort(nodeArray);

                    string resultString = string.Join("-", nodeArray);

                    if (result.Contains(resultString) == false)
                        result.Add(resultString);
                }
            }

            var sortedArray = result.ToArray();

            Array.Sort(sortedArray);

            Console.WriteLine("Result: " + sortedArray.Length);
        }

        bool IsValidConnection(string node, List<string> connectionsToCheck, Dictionary<string, List<string>> nodeList)
        {
            foreach (var connection in connectionsToCheck)
            {
                if (nodeList[connection] == null || nodeList[connection].Contains(node) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
