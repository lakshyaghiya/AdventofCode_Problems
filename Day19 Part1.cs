using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input_day19.txt");
        HashSet<string> towelPatterns = new HashSet<string>(lines[0].Split(", "));
        List<string> designs = new List<string>();
        for (int i = 2; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                designs.Add(lines[i]);
            }
        }
        int validDesigns = 0;
        foreach (string design in designs)
        {
            if (BFS(design,towelPatterns))
            {
                validDesigns++;
            }
        }
        Console.WriteLine(validDesigns);
    }

    static bool BFS(string design,HashSet<string> towels)
    {
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(design);
        visited.Add(design);

        while (queue.Count>0)
        {
            string current = queue.Dequeue();
            if (current=="")
            {
                return true;
            }
            foreach (string towel in towels)
            {
                if (current.StartsWith(towel))
                {
                    string next=current.Substring(towel.Length);
                    if (!visited.Contains(next))
                    {
                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                }
            }
        }

        return false;
    }
}
