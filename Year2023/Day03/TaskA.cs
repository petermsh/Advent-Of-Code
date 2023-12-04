using Microsoft.VisualBasic.FileIO;

namespace Year2023.Day03;

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
        var i = 0;
        var listOfIndexes = new List<int>();
        var listOfNumbers = new List<int>();
        var firstLine = input[0].ToList();
        var secondLine = input[1].ToList();
        var lastLine = input.Last().ToList();
        var prevLastLine = input[input.Length - 2].ToList();
        var sum = 0;

        foreach (var x in firstLine)
        {
            if (char.IsDigit(x))
            {
                listOfIndexes.Add(i);
                listOfNumbers.Add(x - '0');
            }
            
            else if (!char.IsDigit(x) && listOfIndexes.Count > 0)
            {
                if (CheckNeighboursInTheSameLine(firstLine, listOfIndexes) ||
                    CheckNeighboursInOtherLine(secondLine, listOfIndexes))
                {
                    sum += CreateNumberFromList(listOfNumbers);
                }
                listOfIndexes.Clear();
                listOfNumbers.Clear();
            }

            i++;
        }

        for (int j = 0; j < input.Length - 2; j++)
        {
            listOfIndexes.Clear();
            listOfNumbers.Clear();
            i = 0;
            var first = input[j].ToList();
            var second = input[j + 1].ToList();
            var third = input[j + 2].ToList();
            
            foreach (var x in second)
            {
                if (char.IsDigit(x))
                {
                    listOfIndexes.Add(i);
                    listOfNumbers.Add(x - '0');
                }
            
                else if (!char.IsDigit(x) && listOfIndexes.Count > 0)
                {
                    if (CheckNeighboursInTheSameLine(second, listOfIndexes) ||
                        CheckNeighboursInOtherLine(first, listOfIndexes) ||
                        CheckNeighboursInOtherLine(third, listOfIndexes))
                    {
                        sum += CreateNumberFromList(listOfNumbers);
                    }
                    listOfIndexes.Clear();
                    listOfNumbers.Clear();
                }

                if (listOfIndexes.Count > 0 && second.Count - 1 == i)
                {
                    if (CheckNeighboursInTheSameLine(second, listOfIndexes) ||
                        CheckNeighboursInOtherLine(first, listOfIndexes) ||
                        CheckNeighboursInOtherLine(third, listOfIndexes))
                    {
                        sum += CreateNumberFromList(listOfNumbers);
                        listOfIndexes.Clear();
                        listOfNumbers.Clear();
                    }
                }
                i++;
            }
        }

        i = 0;
        foreach (var x in lastLine)
        {
            if (char.IsDigit(x))
            {
                listOfIndexes.Add(i);
                listOfNumbers.Add(x - '0');
            }
            
            else if (!char.IsDigit(x) && listOfIndexes.Count > 0)
            {
                if (CheckNeighboursInTheSameLine(lastLine, listOfIndexes) ||
                    CheckNeighboursInOtherLine(prevLastLine, listOfIndexes))
                {
                    sum += CreateNumberFromList(listOfNumbers);
                }
                listOfIndexes.Clear();
                listOfNumbers.Clear();
            }

            i++;
        }
        
        return sum;
    }
    
    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day03\inputA.txt");


    private static bool CheckNeighboursInOtherLine(List<char> line, List<int> listOfIndexes)
    {
        var firstIndex = listOfIndexes.First() is 0 ? listOfIndexes.First() : listOfIndexes.First() - 1;
        var lastIndex = listOfIndexes.Last() == line.Count - 1 ? listOfIndexes.Last() : listOfIndexes.Last() + 1;

        for (int i = firstIndex; i <= lastIndex; i++)
        {
            if (!char.IsDigit(line[i]) && line[i] != '.')
                return true;
        }

        return false;
    }

    private static bool CheckNeighboursInTheSameLine(List<char> line, List<int> listOfIndexes)
    {
        var firstIndex = listOfIndexes.First();
        var lastIndex = listOfIndexes.Last();
        var isSymbol = false;

        if (firstIndex is not 0)
        {
            isSymbol = !char.IsDigit(line[firstIndex - 1]) && line[firstIndex - 1] != '.';
        }
        
        if (lastIndex < line.Count - 1 && !isSymbol)
        {
            isSymbol = !char.IsDigit(line[lastIndex + 1]) && line[lastIndex + 1] != '.';
        }

        return isSymbol;
    }

    private static int CreateNumberFromList(List<int> digits)
    {
        var number = 0;
        var i = 1;
        
        foreach (var digit in digits)
        {
            number += digit * (int) Math.Pow(10, digits.Count - i);
            i++;
        }

        return number;
    }
}