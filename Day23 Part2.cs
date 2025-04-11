using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    private static Dictionary<string, HashSet<string>> map = new();
    private static HashSet<string> vertices = new();

    static void Main()
    {
        var input = File.ReadAllLines("input22.txt");

        foreach (var line in input)
        {
            var nodes = line.Split("-");
            foreach (var node in nodes)
            {
                if (!map.ContainsKey(node))
                {
                    map[node] = new HashSet<string>();
                }
                vertices.Add(node);
            }

            map[nodes[0]].Add(nodes[1]);
            map[nodes[1]].Add(nodes[0]);
        }
        var triangles = Calculate();
        var largestSet = FindLargestSet(triangles);
        Console.WriteLine(largestSet);
    }

    private static HashSet<string> Calculate()
    {
        var results = new HashSet<string>();
        foreach (var v1 in vertices)
        {
            foreach (var v2 in vertices)
            {
                if (v1 == v2 || !map[v1].Contains(v2)) continue;

                foreach (var v3 in vertices)
                {
                    if (v3 == v1 || v3 == v2) continue;

                    if (map[v1].Contains(v3) && map[v2].Contains(v3))
                    {
                        var triangleArray = new[] { v1, v2, v3 };
                        Array.Sort(triangleArray);
                        var triangle = string.Join(",", triangleArray);
                        results.Add(triangle);
                    }
                }
            }
        }

        return results;
    }

    private static string FindLargestSet(HashSet<string> triangles)
    {
        var sortedVertices = vertices.ToList();
        sortedVertices.Sort();
        var currentSets = triangles;
        var newSets = new HashSet<string>();

        do
        {
            if (newSets.Count > 0)
            {
                currentSets = newSets;
            }
            foreach (var set in currentSets)
            {
                var members = set.Split(",");
                foreach (var vertex in sortedVertices)
                {
                    if (members.Contains(vertex))
                        continue;

                    bool allContain = true;
                    foreach (var v in members)
                    {
                        if (!map[v].Contains(vertex))
                        {
                            allContain = false;
                            break;
                        }
                    }
                    if (allContain)
                    {
                        var membersList = new List<string>(members);
                        membersList.Add(vertex);
                        membersList.Sort();
                        var newSet = string.Join(",", membersList);
                        newSets.Add(newSet);
                    }
                }
            }
        } while (newSets.Count > 0);

        return currentSets.First();
    }
}
