using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        var input = File.ReadAllLines("input22.txt");
        var sequenceSums = new Dictionary<string, int>();

        foreach (var line in input)
        {
            var currentSums = new Dictionary<string, int>();
            var lastDiffs = new List<int>(4);
            long secretNumber = long.Parse(line);
            int previousLastDigit = GetLastDigit(secretNumber);

            for (int i = 0; i < 2000; i++)
            {
                secretNumber = Calculate(secretNumber);
                int newLastDigit = GetLastDigit(secretNumber);
                int diff = newLastDigit - previousLastDigit;
                if (lastDiffs.Count == 4)
                {
                    lastDiffs.RemoveAt(0);
                }

                lastDiffs.Add(diff);


                if (lastDiffs.Count == 4)
                {
                    string diffString = string.Join(",", lastDiffs);
                    if (!currentSums.ContainsKey(diffString))
                    {
                        currentSums[diffString] = newLastDigit;
                    }
                }

                previousLastDigit = newLastDigit;
            }

            foreach (var (key, value) in currentSums)
            {
                if (!sequenceSums.ContainsKey(key))
                    sequenceSums[key] = value;
                else
                    sequenceSums[key] += value;
            }
        }

        Console.WriteLine(sequenceSums.Values.Max());
    }
    static int GetLastDigit(long number)
    {
        return (int)(number % 10);
    }

    static long Calculate(long secret)
    {
        var multiple = secret * 64;
        secret = Mix(secret, multiple);
        secret = Prune(secret);

        var divide = secret / 32;
        secret = Mix(secret, divide);
        secret = Prune(secret);

        multiple = secret * 2048;
        secret = Mix(secret, multiple);
        secret = Prune(secret);

        return secret;
    }

    static long Mix(long a, long b)
    {
        return a ^ b;
    }
    static long Prune(long a)
    {
        return a % 16777216;
    }
}
