using System;
namespace Puzzle1Part1
{
    class Day2Part2
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
                var tempspace = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var space = tempspace.Select(int.Parse);
                var space1 = space.ToList();
                if (Accepted(space1))
                {
                    ans++;
                }
                else
                {

                    for (int i = 0; i < space1.Count(); i++)
                    {
                        List<int> new_space = space1.ToList();
                        new_space.RemoveAt(i);
                        if (Accepted(new_space))
                        {
                            ans++;
                            break;
                        }
                    }

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
