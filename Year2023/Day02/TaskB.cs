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
        int powerOfColours = 0;
        int sumOfColours = 0;

        foreach (var line in input)
        {
            List<List<int>> matrixOfColours = new List<List<int>>();
            var game = line.Split(":");
            var rounds = game[1].Split(";");
            int blueCount = 0, greenCount = 0, redCount = 0;
            
            foreach (var round in rounds)
            {
                var cubes = round.Trim().Replace(",", "").Split(" ");
                for (int i = 0; i < cubes.Length; i += 2)
                {
                    int count = int.Parse(cubes[i]);
                    string colour = cubes[i + 1];
                    if (colour == "blue")
                    {
                        if (blueCount < count)
                        {
                            blueCount = count;
                        }
                    }

                    if (colour == "green")
                    {
                        if (greenCount < count)
                        {
                            greenCount = count;
                        }
                    }

                    if (colour == "red")
                    {
                        if (redCount < count)
                        {
                            redCount = count;
                        }
                    }
                }
            }

            sumOfColours += blueCount * greenCount * redCount;
        }

        return sumOfColours;
    }

    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day02\input.txt");
}