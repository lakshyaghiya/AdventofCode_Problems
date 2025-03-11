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
        var stones = numbers.ToList();
        for (int i=0;i<25;i++)
        {
            List<string> anslist = new List<string>();
            foreach (string s in stones)
            {
                if (s == "0")
                {
                    anslist.Add("1");
                }
                else if (s.Length % 2 == 0)
                {
                    string s1 = s.Substring(0, s.Length / 2);
                    string s2 = s.Substring(s.Length / 2);
                    s2 = s2.TrimStart('0');


                    if (string.IsNullOrEmpty(s2))
                    {
                        s2 = "0";
                    }
                    if (string.IsNullOrEmpty(s1))
                    {
                        s1 = "0";
                    }

                    anslist.Add(s1);
                    anslist.Add(s2);
                }
                else
                {
                    var bigNumber = BigInteger.Parse(s);
                    var num= bigNumber * 2024;
                    anslist.Add(num.ToString());
                }
            }
            stones = anslist;
        }
        Console.WriteLine(stones.Count);
    }
}
