using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines("input_5.txt");

        List<string> rules = new List<string>();
        List<string> updates = new List<string>();
        bool isUpdateSection = false;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                isUpdateSection = true;
                continue;
            }

            if (isUpdateSection)
            {
                updates.Add(line);
            }
            else
            {
                rules.Add(line);
            }
        }

        var ruleDict = new Dictionary<int, List<int>>();
        foreach (var rule in rules)
        {
            var parts = rule.Split('|');
            int before = int.Parse(parts[0]);
            int after = int.Parse(parts[1]);

            if (!ruleDict.ContainsKey(before))
            {
                ruleDict[before] = new List<int>();
            }
            ruleDict[before].Add(after);
        }

        bool IsCorrectOrder(List<int> update)
        {
            for (int i = 0; i < update.Count; i++)
            {
                for (int j = i + 1; j < update.Count; j++)
                {
                    if (ruleDict.ContainsKey(update[i]) && ruleDict[update[i]].Contains(update[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        List<int> middlePages = new List<int>();
        foreach (var update in updates)
        {
            var pages = update.Split(',').Select(int.Parse).ToList();
            if (IsCorrectOrder(pages))
            {
                int middleIndex = pages.Count / 2;
                middlePages.Add(pages[middleIndex]);
            }
        }

        // Sum the middle page numbers
        int result = middlePages.Sum();
        Console.WriteLine($"Sum of middle page numbers: {result}");
    }
}
