namespace Year2023.Day09;

public class Day09
{
    public static void Run()
    {
        var input = ReadFile();
        
        //Console.WriteLine($"TaskA result: {TaskA(input)}");
        Console.WriteLine($"TaskB result: {TaskB(input)}");
    }

    static int TaskA(string[] input)
    {
        var listsNumbers = input.Select(x => x.Split(" ")
            .Select(int.Parse).ToList())
            .ToList();
    
        return CalculateSumOfNextNumbers(listsNumbers);
    }

    static int TaskB(string[] input)
    {
        var sum = 0;
        var listsNumbers = input.Select(x => x.Split(" ")
            .Select(int.Parse).Reverse().ToList())
            .ToList();

        return CalculateSumOfNextNumbers(listsNumbers);
    }

    static int CalculateSumOfNextNumbers(List<List<int>> listsNumbers)
    {
        var sum = 0;
        foreach (var list in listsNumbers)
        {
            var temps = new List<List<int>> { list };
            var temp = new List<int>();
            var j = 0;
            do
            {
                temp.Clear();
                for (int i = 0; i < temps[j].Count - 1; i++)
                {
                    temp.Add(temps[j][i + 1] - temps[j][i]);
                }
                temps.Add(new List<int>(temp));
                j++;
            } while (temp.Any(x => x != 0));

            var toAdd = 0;
            temps.Last().Add(0);
            for (int i = temps.Count - 2; i >= 0; i--)
            {
                toAdd = temps[i].Last() + temps[i + 1].Last();
                temps[i].Add(toAdd);
            }

            sum += toAdd;
        }

        return sum;
    }
    
    static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day09\input.txt");
}