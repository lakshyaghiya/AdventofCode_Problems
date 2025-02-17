using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode_Question_02_Part1
{
    public class AoC2024Day2Part1
    {
        public static async Task Main(string[] args)
        {
            var safeCount = 0;

            using (var inputReader = new StreamReader("input.txt"))
            {
                string line;
                while ((line = await inputReader.ReadLineAsync()) != null)
                {
                    var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    if (IsSafe(report))
                    {
                        safeCount++;
                    }
                }
            }

            Console.WriteLine(safeCount);
        }

        public static bool IsSafe(List<int> report)
        {
            if (report.Count < 2)
            {
                return true;
            }

            var firstDiff = report[1] - report[0];

            if (firstDiff == 0 || Math.Abs(firstDiff) > 3)
            {
                return false;
            }

            var expectedSgn = firstDiff / Math.Abs(firstDiff);

            for (int i = 1; i < report.Count - 1; i++)
            {
                var diff = report[i + 1] - report[i];
                if (diff == 0 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                var sgn = diff / Math.Abs(diff);
                if (sgn != expectedSgn)
                {
                    return false;
                }
            }

            return true;
        }
    }
}