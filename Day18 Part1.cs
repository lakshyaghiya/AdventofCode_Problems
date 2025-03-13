using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        char[,] grid = new char[71, 71];
        for (int i = 0; i < 1024; i++)
        {
            var parts = lines[i].Split(",");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            grid[x, y] = '#';
        }

        var (pExists, distance) = BFS(grid, 0, 0, 70, 70);
        if (pExists)
        {
            Console.WriteLine("passed" + distance);
        }
        else
        {
            Console.WriteLine("failed");
        }
    }

    static (bool, int) BFS(char[,] grid, int startX, int startY, int endX, int endY)
    {
        bool[,] visited = new bool[71, 71];
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x, int y, int z)> queue = new Queue<(int, int, int)>();

        queue.Enqueue((startX, startY, 0));

        visited[0, 0] = true;

        while (queue.Count > 0)
        {

            var current = queue.Dequeue();
            if (current.x == endX && current.y == endY)
                return (true, current.z);


            for (int i = 0; i < 4; i++)
            {
                int newX = current.x + dx[i];
                int newY = current.y + dy[i];


                if (newX >= 0 && newX < 71 && newY >= 0 && newY < 71 && !visited[newX, newY] && grid[newX, newY] != '#')
                {
                    queue.Enqueue((newX, newY, current.z + 1));
                    visited[newX, newY] = true;
                }
            }
        }


        return (false, -1);
    }
}
