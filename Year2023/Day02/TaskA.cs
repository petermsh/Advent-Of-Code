namespace Year2023.Day02;

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
        int redCubes = 12, greenCubes = 13, blueCubes = 14;
        bool correctGame = true;
        int sumGamesIds = 0;
        
        foreach (var line in input)
        {
            var game = line.Split(":");
            var rounds = game[1].Split(";");
            correctGame = true;
            
            foreach (var round in rounds)
            {
                var cubes = round.Trim().Replace(",", "").Split(" ");
                for (int i = 0; i < cubes.Length; i += 2)
                {
                    int count = int.Parse(cubes[i]);
                    string colour = cubes[i + 1];
                    if (colour == "blue")
                    {
                        if (count > blueCubes)
                        {
                            correctGame = false;
                            break;
                        }
                    }

                    if (colour == "green")
                    {
                        if (count > greenCubes)
                        {
                            correctGame = false;
                            break;
                        }
                    }

                    if (colour == "red")
                    {
                        if (count > redCubes)
                        {
                            correctGame = false;
                            break;
                        }
                    }
                }
            }
            if (correctGame)
            {
                sumGamesIds += int.Parse(game[0].Split(" ")[1]);
            }
        }

        return sumGamesIds;
    }
    
    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day02\inputA.txt");

}