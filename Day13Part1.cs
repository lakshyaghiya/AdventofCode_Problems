using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    public class Coordinates
    {
        public (int X, int Y) ButtonA { get; set; }
        public (int X, int Y) ButtonB { get; set; }
        public (int X, int Y) Prize { get; set; }
    }

    static void Main()
    {
        var input = File.ReadAllLines("input25.txt");
        List<Coordinates> coordinatesList = new List<Coordinates>();
        int count = 0;

        for (int i = 0; i < input.Length; i = i + 4)
        {
            if (i + 2 >= input.Length) break;

            var buttonAParts = input[i].Split(new[] { "X+", ", Y+" }, StringSplitOptions.None);
            var buttonBParts = input[i + 1].Split(new[] { "X+", ", Y+" }, StringSplitOptions.None);
            var prizeParts = input[i + 2].Split(new[] { "X=", ", Y=" }, StringSplitOptions.None);

            var coordinates = new Coordinates
            {
                ButtonA = (int.Parse(buttonAParts[1]), int.Parse(buttonAParts[2])),
                ButtonB = (int.Parse(buttonBParts[1]), int.Parse(buttonBParts[2])),
                Prize = (int.Parse(prizeParts[1]), int.Parse(prizeParts[2]))
            };

            coordinatesList.Add(coordinates);
        }

        foreach (var coord in coordinatesList)
        {
            Console.WriteLine($"Button A: X={coord.ButtonA.X}, Y={coord.ButtonA.Y}");
            Console.WriteLine($"Button B: X={coord.ButtonB.X}, Y={coord.ButtonB.Y}");
            Console.WriteLine($"Prize: X={coord.Prize.X}, Y={coord.Prize.Y}");
            Console.WriteLine();

            int numY = (coord.ButtonA.Y * coord.Prize.X) - (coord.ButtonA.X * coord.Prize.Y);
            int denY = (coord.ButtonB.X * coord.ButtonA.Y) - (coord.ButtonB.Y * coord.ButtonA.X);
            if (denY == 0 || numY % denY != 0)
                continue;

            int y = numY / denY;

            int numX = coord.Prize.X - (coord.ButtonB.X * y);
            if (numX % coord.ButtonA.X != 0)
                continue;

            int x = numX / coord.ButtonA.X;

            Console.WriteLine($"X={x}, Y={y}");
            if (x >= 0 && y >= 0)
            {
                count = count + (3 * x) + y;
            }
        }
        Console.WriteLine(count);
    }
}