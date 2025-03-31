using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        var input = File.ReadAllLines("input22.txt");
        long ans = 0;
        foreach (var line in input)
        {
            long secretNumber = long.Parse(line);

            for (int i = 0; i < 2000; i++)
            {
                secretNumber = Calculate(secretNumber);
            }
            ans = ans + secretNumber;
        }

        Console.WriteLine(ans);
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
