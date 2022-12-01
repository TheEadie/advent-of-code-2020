namespace AdventOfCode2022;

public class Day01
{
    [TestCase("data/01 - Sample.txt", 24000, TestName = "Sample")]
    [TestCase("data/01 - Puzzle Input.txt", 69795, TestName = "Puzzle Input")]
    public void Part1(string inputFile, int expected)
    {
        var elves = ParseInput(File.ReadAllText(inputFile));

        var answer = elves.Max(x => x.Calories.Sum());
        
        Console.WriteLine(answer);
        answer.ShouldBe(expected);
    }
    
    [TestCase("data/01 - Sample.txt", 45000, TestName = "Sample")]
    [TestCase("data/01 - Puzzle Input.txt", 208437, TestName = "Puzzle Input")]
    public void Part2(string inputFile, int expected)
    {
        var elves = ParseInput(File.ReadAllText(inputFile));

        var answer = elves.OrderByDescending(x => x.Calories.Sum())
            .Take(3)
            .SelectMany(x => x.Calories)
            .Sum();
        
        Console.WriteLine(answer);
        answer.ShouldBe(expected);
    }

    private static IEnumerable<Elf> ParseInput(string input)
    {
        return input
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(x => 
                new Elf(x.Split(Environment.NewLine)
                    .Select(int.Parse)
                    .ToList()));
    }

    private record Elf(IReadOnlyCollection<int> Calories);
}