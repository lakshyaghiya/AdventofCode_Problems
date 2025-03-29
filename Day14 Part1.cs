using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    public class Coordinates
    {
        public (int X, int Y) Starting { get; set; }
        public (int X, int Y) Speed { get; set; }
    }
    static void Main()
    {
        var input = File.ReadAllLines("input14.txt");
        List<Coordinates> coordinatesList = new List<Coordinates>();

        foreach (var line in input)
        {
            var div = line.Split(' ');
            var start = div[0].Substring(2).Split(',');
            var speed = div[1].Substring(2).Split(',');
            var c = new Coordinates
            {
                Starting = (int.Parse(start[0]), int.Parse(start[1])),
                Speed = (int.Parse(speed[0]), int.Parse(speed[1]))
            };
            coordinatesList.Add(c);
        }
        var quad1 = 0; var quad2 = 0; var quad3 = 0; var quad4 = 0;

        foreach (var c in coordinatesList)
        {
            Console.WriteLine($"Starting: {c.Starting.X} ,{c.Starting.Y}, Speed: {c.Speed.X}, {c.Speed.Y}");
            Console.WriteLine();
            var newX = (c.Starting.X + c.Speed.X * 100) % 101;
            var newY = (c.Starting.Y + c.Speed.Y * 100) % 103;
            if (newX < 0)
                newX = newX + 101;
            if (newY < 0)
                newY = newY + 103;
            if (newX < 50 && newY < 51)
            {
                quad1++;
            }
            else if (newX > 50 && newY < 51)
            {
                quad2++;
            }
            else if (newX > 50 && newY > 51)
            {
                quad3++;
            }
            else if (newX < 50 && newY > 51)
            {
                quad4++;
            }

        }
        Console.WriteLine(quad1 * quad2 * quad3 * quad4);
    }
}
