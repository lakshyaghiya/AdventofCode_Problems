using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input25.txt");

        List<int[]> locks = new List<int[]>();
        List<int[]> keys = new List<int[]>();

        ProcessInput(lines,locks,keys);
        int validPairs = CountValidPairs(locks, keys);

        Console.WriteLine(validPairs);
    }

    static void ProcessInput(string[] lines, List<int[]> locks, List<int[]> keys)
    {
        int index = 0;
        while (index <lines.Length)
        {
            char[,] grid = new char[7, 5];
            for (int y =0;y<7; y++)
            {
                if (index >= lines.Length) break;
                string line = lines[index++];
                for (int x=0;x< 5; x++)
                {
                    grid[y,x] = line[x];
                }
            }
            
            
            bool isLock = grid[0, 0] == '#';
            int[] itemHeights = new int[5];
            for (int x = 0; x < 5; x++)
            {
                int count = 0;
                for (int y=0;y<7;y++)
                {
                    if (grid[y, x] == '#')
                    {
                        count++;
                    }
                }
                itemHeights[x] =count;
            }

            if (isLock)
                locks.Add(itemHeights);
            else
                keys.Add(itemHeights);

            if (index < lines.Length && string.IsNullOrWhiteSpace(lines[index]))
                index++;
        }
    }
    
    static int CountValidPairs(List<int[]> locks, List<int[]> keys)
    {
        int pairCount = 0;

        foreach (var lockItem in locks)
        {
            foreach (var keyItem in keys)
            {
                bool isValid = true;
                for(int i =0; i <5; i++)
                {
                    if (lockItem[i] + keyItem[i] > 7)
                    {
                        isValid = false;
                        break;
                    }
                }
                if(isValid)
                    pairCount++;
            }
        }
        return pairCount;
    }
}
