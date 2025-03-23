using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        int ans = CountXMAS(lines, "XMAS");
        Console.WriteLine(ans);

    }
    static int CountXMAS(string[] lines, string word)
    {
        int count = 0;
        int length = lines.Length;
        int width = lines[0].Length;
        int wordlen = word.Length;
        int[] xdirection = { 0, 0, 1, -1, 1, 1, -1, -1 }; // up.down.right.left.botright.topright.downleft.topleft.
        int[] ydirection = { 1, -1, 0, 0, 1, -1, 1, -1 };
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    int newx = i;
                    int newy = j;
                    int b;
                    for (b = 0; b < wordlen; b++)
                    {
                        if (newx < 0 || newx >= length || newy < 0 || newy >= width || lines[newx][newy] != word[b])
                            break;
                        newx = newx + xdirection[k];
                        newy = newy + ydirection[k];
                    }
                    if (b == wordlen)
                        count++;
                }
            }
        }
        return count;
    }

}
