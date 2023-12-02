using System.Text;
using System.Text.RegularExpressions;

namespace Year2023.Day02;

public static class TaskB
{
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    private static int Solve(string[] input)
    {
        var powerOfColours = 0;
        var sumOfColours = 0;

        foreach (var line in input)
        {
            var game = line.Split(":");
            var rounds = game[1].Split(";");
            int blueCount = 0, greenCount = 0, redCount = 0;
            
            foreach (var round in rounds)
            {
                var cubes = round.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < cubes.Length; i += 2)
                {
                    var count = int.Parse(cubes[i]);
                    var colour = cubes[i + 1];
                    switch (colour)
                    {
                        case "blue":
                            blueCount = (blueCount < count) ? count : blueCount;
                            break;
                        case "green":
                            greenCount = (greenCount < count) ? count : greenCount;
                            break; 
                        case "red":
                            redCount = (redCount < count) ? count : redCount;
                            break;
                    }
                }
            }
            sumOfColours += blueCount * greenCount * redCount;
        }
        return sumOfColours;
    }

    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day02\inputB.txt");
}