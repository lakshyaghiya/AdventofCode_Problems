using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode_Question_03_Part1
{
    public class AoC2024Day3Part1
    {
        public static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("inputDay3.txt");

            var matches = MulRegex().Matches(input);

            var total = 0;
            foreach (Match match in matches)
            {
                var x = int.Parse(match.Groups[1].Value);
                var y = int.Parse(match.Groups[2].Value);
                total =total + (x * y);
            }

            Console.WriteLine(total);
        }
        public static Regex MulRegex()
        {
            return new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        }
    }
}