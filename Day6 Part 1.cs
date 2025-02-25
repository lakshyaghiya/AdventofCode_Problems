using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = new List<string>();
        using (StreamReader sr = new StreamReader("input_6.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        char[][] grid = new char[lines.Count][];
        for (int i = 0; i < lines.Count; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }
        int rows = grid.Length, cols = grid[0].Length;

        (int, int)[] directions = { (-1, 0), (0, 1), (1, 0), (0, -1) }; // U,R,D,L
        int dir = 0;
        int startX = 0, startY = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '^' || grid[r][c] == '>' || grid[r][c] == 'v' || grid[r][c] == '<')
                {
                    startX = r;
                    startY = c;
                    if (grid[r][c] == '^')
                    {
                        dir = 0;
                    }
                    else if (grid[r][c] == '>')
                    {
                        dir = 1;
                    }
                    else if (grid[r][c] == 'v')
                    {
                        dir = 2;
                    }
                    else if (grid[r][c] == '<')
                    {
                        dir = 3;
                    }
                    grid[r][c] = '.';
                    break;
                }
            }
        }


        HashSet<(int, int, int)> visited = new HashSet<(int, int, int)>();
        int x = startX, y = startY;

        while (true)
        {
            if (!visited.Add((x, y, dir)))
                break;

            int newX = x + directions[dir].Item1;
            int newY = y + directions[dir].Item2;

            if (newX < 0 || newX >= rows || newY < 0 || newY >= cols)
                break;

            if (grid[newX][newY] == '#')
            {
                dir = (dir + 1) % 4;
            }
            else
            {
                x = newX;
                y = newY;
            }
        }

        int loopCount = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '.' && (r != startX || c != startY))
                {
                    char[][] newGrid = grid.Select(row => row.ToArray()).ToArray(); // Deep copy grid
                    newGrid[r][c] = '#';

                    if (SimulateAndCheckLoop(newGrid, startX, startY, dir, directions))
                        loopCount++;
                }
            }
        }

        Console.WriteLine(loopCount);
    }

    static bool SimulateAndCheckLoop(char[][] grid, int startX, int startY, int dir, (int, int)[] directions)
    {
        HashSet<(int, int, int)> visited = new HashSet<(int, int, int)>();
        int x = startX, y = startY;

        while (true)
        {
            if (!visited.Add((x, y, dir)))
                return true; // Guard is stuck in a loop

            int newX = x + directions[dir].Item1;
            int newY = y + directions[dir].Item2;

            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                return false; // Guard exits the map

            if (grid[newX][newY] == '#')
            {
                dir = (dir + 1) % 4;
            }
            else
            {
                x = newX;
                y = newY;
            }
        }
    }
}
