using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        string input = File.ReadAllText("input.txt");
        var numbers = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, BigInteger> dict = new Dictionary<string, BigInteger>();

        foreach (var number in numbers)
        {
            if (dict.ContainsKey(number))
                dict[number]++;
            else
                dict[number] = 1;
        }
        for (int i = 0; i < 75; i++)
        {
            var newCount = new Dictionary<string, BigInteger>();
            foreach (var d in dict)
            {
                string s = d.Key;
                BigInteger count = d.Value;

                if (s == "0")
                {
                    AddToDictionary(newCount, "1", count);
                }
                else if (s.Length % 2 == 0)
                {
                    string s1 = s.Substring(0, s.Length / 2);
                    string s2 = s.Substring(s.Length / 2).TrimStart('0');
                    if (string.IsNullOrEmpty(s2))
                        s2 = "0";

                    AddToDictionary(newCount, s1, count);
                    AddToDictionary(newCount, s2, count);
                }
                else
                {
                    var bigNumber = BigInteger.Parse(s);
                    var multiple = bigNumber * 2024;
                    AddToDictionary(newCount, multiple.ToString(), count);
                }
            }

            dict = newCount;
        }

        BigInteger totalStones = 0;
        foreach (var value in dict.Values)
        {
            totalStones = totalStones + value;
        }

        Console.WriteLine(totalStones);

    }
    static void AddToDictionary(Dictionary<string, BigInteger> dict, string key, BigInteger count)
    {
        if (dict.ContainsKey(key))
            dict[key] = dict[key] + count;
        else
            dict[key] = count;
    }
}
