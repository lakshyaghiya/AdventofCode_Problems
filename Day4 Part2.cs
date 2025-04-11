using System;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        int ans = CountXMAS(lines);
        Console.WriteLine(ans);
    }

    static int CountXMAS(string[] lines)
    {
        int length = lines.Length;
        int width = lines[0].Length;
        char[,] map = new char[length, width];
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                map[i, j] = lines[i][j];
            }
        }

        int count = 0;
        int[] xdirection = { -1, 1 }; int[] ydirection = { -1, 1 };
        var word = "MAS";
        for (int i = 1; i < length - 1; i++)
        {
            for (int j = 1; j < width - 1; j++)
            {
                int diagonalCount = 0;

                for (int k = 0; k < 2; k++)
                {
                    int newx = i + xdirection[k];
                    int newy = j + ydirection[k];
                    int b;
                    for (b = 0; b < 3; b++)
                    {
                        int nx = newx + b * xdirection[k];
                        int ny = newy + b * ydirection[k];

                        if (nx < 0 || nx >= length || ny < 0 || ny >= width || map[nx, ny] != word[b])
                            break;
                    }


                    if (b == 3)
                    {
                        diagonalCount++;
                    }
                }
                if (diagonalCount == 2)
                {
                    count++;
                }

            }

        }
        return count;
    }
}
