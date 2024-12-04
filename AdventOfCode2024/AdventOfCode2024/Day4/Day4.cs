using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day4
{
    public class Day4
    {
        public void Main()
        {
            //var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Day4", "Example.txt");
            var DayPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "PuzzleInputs", "Day4.txt");

            var input = File.ReadAllLines(DayPath);

            Console.WriteLine("DAY 4");

            //Part1(input);
            Part2(input);
        }


        internal int Part1(string[] rader)
        {
            int xmasFound = 0;
            int h = 0;
            int v = 0;
            int d1 = 0;
            int d2 = 0;

            int height = rader.Length;
            int width = rader[0].Length;

            for (int i = 0; i < rader.Length; i++)
            {
                //char[] rad = rader[i].ToCharArray();
                string rad = rader[i];

                //Console.WriteLine("Rad: " + rader[i]);
                for (int j = 0; j < rad.Length; j++)
                {
                    //char bokstav = rad[j];

                    // Horizontal
                    string horizontal = rad.Substring(j);
                    if (CheckString(horizontal))
                    {
                        xmasFound++;
                        h++;
                    }

                    // Vertical
                    string vertical = "";
                    int y = j;
                    while (y < height)
                    {
                        vertical += rader[y][i];
                        y++;
                    }
                    if (CheckString(vertical))
                    {
                        xmasFound++;
                        v++;
                    }

                    // Diagonal upwards
                    string diagonal1 = "";
                    y = i;
                    int x = j;
                    while (y >= 0 && x < width)
                    {
                        diagonal1 += rader[y][x];
                        y--;
                        x++;
                    }
                    if (CheckString(diagonal1))
                    {
                        xmasFound++;
                        d1++;
                    }

                    // Diagonal downwards
                    string diagonal2 = "";
                    y = i;
                    x = j;
                    while (y < height && x < width)
                    {
                        diagonal2 += rader[y][x];
                        y++;
                        x++;
                    }
                    if (CheckString(diagonal2))
                    {
                        xmasFound++;
                        d2++;
                    }
                }
            }
            Console.WriteLine("horizontal: " + h);
            Console.WriteLine("vertical: " + v);
            Console.WriteLine("diagonal up: " + d1);
            Console.WriteLine("diagonal down: " + d2);
            Console.WriteLine("DAY 4 Part 1 Result: " + xmasFound);

            return 0;
        }

        bool CheckString(string str)
        {
            if (str.Length < 4)
                return false;

            char first = str[0];
            string rest = str.Substring(1);

            if (first == 'X')
            {
                if (rest.StartsWith("MAS"))
                {
                    return true;
                }
            }

            if (first == 'S')
            {
                if (rest.StartsWith("AMX"))
                {
                    return true;
                }
            }

            return false;
        }

        internal void Part2(string[] rader)
        {
            int xmasFound = 0;

            int height = rader.Length;
            int width = rader[0].Length;

            for (int i = 0; i < rader.Length; i++)
            {
                string rad = rader[i];

                for (int j = 0; j < rad.Length; j++)
                {
                    char character = rad[j];

                    if (character == 'A')
                    {
                        string str = "";

                        int x;
                        int y;

                        // Top left
                        y = i - 1;
                        x = j - 1;
                        if (ValidCords(x, y, height, width) == false)
                            continue;
                        str += rader[y][x];

                        // Top right
                        y = i - 1;
                        x = j + 1;
                        if (ValidCords(x, y, height, width) == false)
                            continue;
                        str += rader[y][x];

                        // Bottom left
                        y = i + 1;
                        x = j - 1;
                        if (ValidCords(x, y, height, width) == false)
                            continue;
                        str += rader[y][x];

                        // Bottom right
                        y = i + 1;
                        x = j + 1;
                        if (ValidCords(x, y, height, width) == false)
                            continue;
                        str += rader[y][x];

                        if (str == "MSMS" || str == "SMSM" || str == "MMSS" || str == "SSMM")
                            xmasFound++;
                    }
                }
            }

            Console.WriteLine("DAY 4 Part 2 Result: " + xmasFound);
        }

        bool ValidCords(int x, int y, int height, int width)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return true;
            }

            return false;
        }
    }
}
