using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string[] values = File.ReadAllLines("input.txt");
        int rows = values.Length;
        int cols = values[0].Length;
        Dictionary<char, List<(int, int)>> antennas = new();
        HashSet<(int, int)> antinodes = new();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                char c = values[i][j];
                if (char.IsLetterOrDigit(c))
                {
                    if (!antennas.ContainsKey(c))
                        antennas[c] = new List<(int, int)>();
                    antennas[c].Add((i, j));
                }
            }
        }
        foreach (var antenna in antennas)
        {
            var positions = antenna.Value;
            int count = positions.Count;
            for (int a = 0; a < count; a++)
            {
                for (int b = a + 1; b < count; b++)
                {
                    int x1 = positions[a].Item1;
                    int y1 = positions[a].Item2;
                    int x2 = positions[b].Item1;
                    int y2 = positions[b].Item2;

                    int dx = x2 - x1;
                    int dy = y2 - y1;

                    int x3 = x1 - dx;
                    int y3 = y1 - dy;
                    int x4 = x2 + dx;
                    int y4 = y2 + dy;
                    int k = 0;
                    while (true)
                    {
                        int xForward = x1 + k * dx;
                        int yForward = y1 + k * dy;
                        int xBackward = x1 - k * dx;
                        int yBackward = y1 - k * dy;

                        bool validForward = IsValid(xForward, yForward, rows, cols);
                        bool validBackward = IsValid(xBackward, yBackward, rows, cols);

                        if (!validForward && !validBackward) break;

                        if (validForward) antinodes.Add((xForward, yForward));
                        if (validBackward) antinodes.Add((xBackward, yBackward));

                        k++;
                    }
                }
            }
        }
        Console.WriteLine(antinodes.Count);
        static bool IsValid(int x, int y, int rows, int cols)
        {
            return x >= 0 && x < rows && y >= 0 && y < cols;
        }
    }
}
