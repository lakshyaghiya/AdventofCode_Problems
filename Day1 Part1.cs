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
            foreach (var line in File.ReadLines(filePath))
            {
                var space = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (space.Length > 0 && int.TryParse(space[0], out var a))
                {
                    A.Add(a);
                }

                if (space.Length > 1 && int.TryParse(space[1], out var b))
                {
                    B.Add(b);
                }
            }
            A.Sort(); B.Sort();
            var difference = 0;
            for (int i = 0; i < A.Count(); i++)
            {
                difference = difference + Math.Abs(A[i] - B[i]);
            }
            Console.WriteLine(difference.ToString());


            Dictionary<int, int> map = A.ToDictionary(x => x, x => B.Count(num1 => num1 == x));
            int sum = 0;
            foreach (var item in map)
            {
                sum = sum + item.Key * item.Value;
            }

            Console.WriteLine(sum.ToString());
        }
    }
}
