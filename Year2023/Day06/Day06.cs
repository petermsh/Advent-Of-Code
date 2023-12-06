using System.ComponentModel.Design;

namespace Year2023.Day06;

public static class Day06
{
    public static void Run()
    {
        var input = ReadFile();
        
        Console.WriteLine($"TaskA result: {TaskA(input)}");
        Console.WriteLine($"TaskB result: {TaskB(input)}");
    }
    
    
    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day06\inputA.txt");

    private static int TaskA(string[] input)
    {
        var time = input.First()
            .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToList();
        var distance = input.Last()
            .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToList();
        
        var multiplyOfWays = 1;
        for (int i = 0; i < time.Count; i++)
        {
            var numberOfWays = 0;
            for (int j = 0; j < time[i]; j++)
            {
                if (j * (time[i] - j) > distance[i])
                    numberOfWays++;
            }
            multiplyOfWays *= numberOfWays;
        }
        
        return multiplyOfWays;
    }

    private static int TaskB(string[] input)
    {
        var time = long.Parse(string.Join("",
                input.First()
                    .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                ));

        var distance = long.Parse(string.Join("",
                input.Last()
                    .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                ));

        var x1 = (int) Math.Floor(time + Math.Sqrt(Math.Pow(time, 2) - 4 * distance) / 2);
        var x2 = (int) Math.Ceiling(time - Math.Sqrt(Math.Pow(time, 2) - 4 * distance) / 2);

        return x1 - x2 + 1;
    }

}