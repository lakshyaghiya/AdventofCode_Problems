using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input_7.txt");
        long totalCalibrationResult = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            long targetValue = long.Parse(parts[0].Trim());
            long[] numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);

            if (CanAchieveTarget(numbers, targetValue))
            {
                totalCalibrationResult += targetValue;
            }
        }

        Console.WriteLine(totalCalibrationResult);
    }

    static bool CanAchieveTarget(long[] numbers, long target)
    {
        return EvaluateAllCombinations(numbers, 1, numbers[0], target);
    }

    static bool EvaluateAllCombinations(long[] numbers, int index, long currentValue, long target)
    {
        if (index == numbers.Length)
        {
            return currentValue == target;
        }

        long nextNumber = numbers[index];

        // Try addition
        if (EvaluateAllCombinations(numbers, index + 1, currentValue + nextNumber, target))
        {
            return true;
        }

        // Try multiplication
        if (EvaluateAllCombinations(numbers, index + 1, currentValue * nextNumber, target))
        {
            return true;
        }

        return false;
    }
}
