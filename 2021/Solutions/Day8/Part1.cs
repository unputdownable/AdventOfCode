using System.Linq;

namespace AoC2021.Solutions.Day8;

public class Part1 : ISolutionPart
{
    public int Day => 8;

    public int Part => 1;

    public string Name => "Sevent segment display";

    public string Description => "Decode";

    public string Execute()
    {
        var entries = Util.GetInput(Day)
            .Select(i => new Entry(i))
            .ToList();

        var count_1478 = entries.Select(e => e.OutputValues.Where(p => p.Match != null).Count()).Sum();

        return count_1478.ToString();
    }
}

class Entry
{
    public Entry(string input)
    {
        var parts = input.Split(" | ");
        SignalPatterns = parts[0].Split(' ').Select(p => new SignalPattern(p)).ToArray();
        OutputValues = parts[1].Split(' ').Select(p => new SignalPattern(p)).ToArray();
    }

    public SignalPattern[] SignalPatterns { get; init; }
    public SignalPattern[] OutputValues { get; init; }

}

class SignalPattern
{
    readonly string pattern;
    readonly string match;

    public SignalPattern(string input)
    {
        pattern = input;

        if (pattern.Length == Number.One.Length)
            match = Number.One;
        else if (pattern.Length == Number.Four.Length)
            match = Number.Four;
        else if (pattern.Length == Number.Seven.Length)
            match = Number.Seven;
        else if (pattern.Length == Number.Eight.Length)
            match = Number.Eight;
    }

    public string Match => match;

    public override string ToString()
    {
        return pattern;
    }
}

static class Number
{
    public static string One => "cf";
    public static string Four => "bcdf";
    public static string Seven => "acf";
    public static string Eight => "abcdefg";

}
