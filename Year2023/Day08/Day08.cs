namespace Year2023.Day08;

public class Day08
{
    public static void Run()
    {
        var input = ReadFile();
        
        Console.WriteLine($"TaskA result: {TaskA(input)}");
        Console.WriteLine($"TaskB result: {TaskB(input)}");
    }

    static long TaskA(string[] input)
    {
        var counter = 0;
        var instructions = input.First().ToList();
        var steps = input.Skip(2)
            .Select(x=>x.Split(new char[] {'=', ','}, StringSplitOptions.TrimEntries))
            .Select(x=>new Step(x[0], x[1].TrimStart('('), x[2].TrimEnd(')')))
            .ToList();

        var currentStep = steps.Find(x=>x.Name == "AAA");
        var lastStep = steps.Find(x => x.Name == "ZZZ");
        
        while (currentStep != lastStep)
        {
            currentStep = MakeSteps(currentStep, instructions, steps, ref counter);
        }
        
        return counter;
    }

    static long TaskB(string[] input)
    {
        var counter = 0;
        var stepsCounterList = new List<long>();
        var instructions = input.First().ToList();
        var steps = input.Skip(2)
            .Select(x => x.Split(new char[] { '=', ',' }, StringSplitOptions.TrimEntries))
            .Select(x=>new Step(x[0], x[1].TrimStart('('), x[2].TrimEnd(')')))
            .ToList();

        var currentSteps = steps.Where(x => x.Name.EndsWith('A')).ToList();

        for (int i = 0; i < currentSteps.Count; i++)
        {
            while (!currentSteps[i].Name.EndsWith('Z'))
            {
                currentSteps[i] = MakeSteps(currentSteps[i], instructions, steps, ref counter);
            }
            stepsCounterList.Add(counter);
            counter = 0;
        }

        return LcmList(stepsCounterList);
    }

    static Step MakeSteps(Step currentStep, List<char> instructions, List<Step> steps, ref int counter)
    {
        foreach (var instruction in instructions)
        {
            currentStep = instruction == 'L'
                ? steps.Find(x => x.Name == currentStep.NextLeftStep)
                : steps.Find(x => x.Name == currentStep.NextRightStep);
            counter++;
        }
        
        return currentStep;
    }
    
    class Step
    {
        public string Name { get; set; }
        public string NextLeftStep { get; set; }
        public string NextRightStep { get; set; }

        public Step(string name, string nextLeftStep, string nextRightStep)
        {
            Name = name;
            NextLeftStep = nextLeftStep;
            NextRightStep = nextRightStep;
        }
    }
    
    static long LcmList(List<long> numbers)
    {
        return numbers.Aggregate(Lcm);
    }
    static long Lcm(long a, long b)
    {
        return Math.Abs(a * b) / GCD(a, b);
    }
    static long GCD(long a, long b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
    
    private static string[] ReadFile()
        => File.ReadAllLines(@"D:\Advent-of-Code\Year2023\Day08\input.txt");
}