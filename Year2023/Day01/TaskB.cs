using System.Text;
using System.Text.RegularExpressions;

namespace Year2023.Day01;

public class TaskB
{
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    private static int Solve(string[] input)
    {
        var toNumber = new Dictionary<string, string>()
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };

        int sum = 0;
        foreach (var line in input)
        {
            StringBuilder sb = new(line);
            foreach (var number in toNumber)
            {
                sb.Replace(number.Key, number.Value);
            }

            var changedLine = sb.ToString();

            int a = 0, b = 0;
            foreach (var letter in changedLine.Where(letter => letter >= 48 && letter <= 57))
            {
                if (a == 0)
                {
                    a = letter - '0';
                    b = letter - '0';
                }
                else
                {
                    b = letter - '0';
                }
            }

            sum += (a * 10 + b);
        }

        return sum;
    }

    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day01\input.txt");
}