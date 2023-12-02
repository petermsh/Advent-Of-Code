namespace Year2023.Day01;

public static class TaskA
{
    public static void Run()
    {
        var input = ReadFile();
        var result = Solve(input);
        Console.WriteLine(result);
    }

    private static int Solve(string[] input)
    {
        int sum = 0;
        foreach (var line in input)
        {
            int a = 0, b = 0;
            foreach (var letter in line.Where(letter => letter >= 1 && letter <= 9))
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
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day01\inputA.txt");

}