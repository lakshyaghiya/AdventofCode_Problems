using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

class Program
{
    static (int, int)[] directions = { (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1) };

    public static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int x = lines.Length;
        int y = lines[0].Length;
        int[,] matrix = new int[x, y];
        List<(int, int)> zeroes = new List<(int, int)>();

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = lines[i][j] - '0';
                if (matrix[i, j] == 0)
                {
                    zeroes.Add((i, j));
                }
            }
        }

        int ans = 0;
        foreach (var zero in zeroes)
        {
            ans = ans + GetPath(matrix, x, y, zero.Item1, zero.Item2);
        }

        Console.WriteLine(ans);

    }

    static int GetPath(int[,] grid, int rows, int cols, int startRow, int startCol)
    {
        Queue<(int, int, int)> queue = new();
        HashSet<(int, int)> visited = new();
        queue.Enqueue((startRow, startCol, 0));
        int count = 0;

        while (queue.Count > 0)
        {
            var (row, col, height) = queue.Dequeue();
            if (grid[row, col] == 9)
            {
                count++;
                continue;
            }

            foreach (var (dx, dy) in directions)
            {
                int newRow = row + dx, newCol = col + dy;
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited.Contains((newRow, newCol)))
                {
                    if (grid[newRow, newCol] == height + 1)
                    {
                        queue.Enqueue((newRow, newCol, grid[newRow, newCol]));
                    }

                }
            }
        }
        return count;
    }
}