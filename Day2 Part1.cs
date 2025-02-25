// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Versioning;
namespace Puzzle1Part1
{
    class Day2Part1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var A = new List<int>();
            var B = new List<int>();
            string filePath = "input.txt";
            int ans = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                var space = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (Accepted(space))
                {
                    ans++;
                }

            }
            Console.WriteLine(ans);
            bool Accepted(List<int> Line)
            {
                if (Line.Count() < 2)
                    return true;
                int direction = Line[1] - Line[0];
                if (direction == 0 || Math.Abs(direction) > 3)
                    return false;
                int sign = direction / Math.Abs(direction);
                for (int i = 1; i < Line.Count() - 1; i++)
                {
                    int diff = Line[i + 1] - Line[i];
                    if (diff == 0 || Math.Abs(diff) > 3 || diff / Math.Abs(diff) != sign)
                        return false;
                }
                return true;
            }
        }
    }
}
