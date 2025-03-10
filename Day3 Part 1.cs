using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string[] values = File.ReadAllLines("input.txt");
        string concat = "";
        for (int i = 0; i < values.Length; i++)
        {
            concat += values[i] + "\n";
        }

        Regex regex = new Regex("mul\\(\\d{1,3},\\d{1,3}\\)");
        int total = 0;

        MatchCollection matches = regex.Matches(concat);

        foreach (Match match in matches)
        {
            string matchValue = match.Value;
            string cleaned = matchValue.Replace("mul(", "").Replace(")", "");
            string[] parts = cleaned.Split(',');

            int num1 = int.Parse(parts[0]);
            int num2 = int.Parse(parts[1]);

            int result = num1 * num2;
            total = total + result;
        }

        Console.WriteLine("Total: " + total);
    }
}
