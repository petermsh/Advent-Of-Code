using Microsoft.VisualBasic.FileIO;

namespace Year2023.Day04;

public static class Day04
{
    public static void Run()
    {
        var input = ReadFile();
        var splitNumbers = input.Select(x => x.Split("|")).ToList();
        var winningNumbers = splitNumbers.Select(x => x.First().Split(":").Last().Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(x=>x.Select(int.Parse).ToList())
            .ToList();
        var myNumbers = splitNumbers.Select(x => x.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(x=>x.Select(int.Parse).ToList())
            .ToList();
        
        Console.WriteLine($"TaskA result: {TaskA(winningNumbers, myNumbers)}");
        Console.WriteLine($"TaskB result: {TaskB(winningNumbers, myNumbers)}");
    }
    
    
    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day04\inputA.txt");

    private static int TaskA(List<List<int>> winningNumbers, List<List<int>> myNumbers) 
        => myNumbers.Select((t, i) => 1 * (int)Math.Pow(2, t.Intersect(winningNumbers[i]).Count() - 1)).Sum();

    private static int TaskB(List<List<int>> winningNumbers, List<List<int>> myNumbers)
    {
        List<int> score = Enumerable.Repeat(1, myNumbers.Count).ToList();
        for (int i = 0; i < myNumbers.Count; i++)
        {
            var matches = myNumbers[i].Intersect(winningNumbers[i]).Count();
            for (int j = i + 1; j <=  i + matches; j++)
            {
                score[j] +=  score[i];
            }
        }

        return score.Sum();
    }

}