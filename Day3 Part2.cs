using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string input = File.ReadAllText("input.txt");
        Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        Regex doRegex = new Regex(@"do\(\)");
        Regex dontRegex = new Regex(@"don't\(\)");
        int total = 0;
        bool isTrue = true;
        int current = 0;

        while (current < input.Length)
        {
            Match doMatch = doRegex.Match(input, current);
            Match dontMatch = dontRegex.Match(input, current);
            Match mulMatch = regex.Match(input, current);

            if (!doMatch.Success && !dontMatch.Success && !mulMatch.Success)
            {
                break;
            }

            if (doMatch.Success &&
                (!dontMatch.Success || doMatch.Index < dontMatch.Index) &&
                (!mulMatch.Success || doMatch.Index < mulMatch.Index))
            {
                isTrue = true;
                current = doMatch.Index + doMatch.Length;
            }
            else if (dontMatch.Success &&
                     (!mulMatch.Success || dontMatch.Index < mulMatch.Index))
            {
                isTrue = false;
                current = dontMatch.Index + dontMatch.Length;
            }
            else if (mulMatch.Success)
            {
                if (isTrue)
                {
                    int num1 = int.Parse(mulMatch.Groups[1].Value);
                    int num2 = int.Parse(mulMatch.Groups[2].Value);
                    total = total + (num1 * num2);
                }
                current = mulMatch.Index + mulMatch.Length;
            }
        }

        Console.WriteLine("Total: " + total);
    }
}
