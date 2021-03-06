namespace AoC2021.Solutions.Day1;

public class Part1 : ISolutionPart
{
    public string Name => "Part 1";

    public string Description => "The number of times a depth measurement increases";

    public int Day => 1;

    public int Part => 1;

    public string Execute()
    {
        var input = Util.GetInput(Day);

        int? prev = null;
        var count = 0;

        foreach (var value in input)
        {
            var depth = int.Parse(value);

            if (depth > prev)
                count++;

            prev = depth;
        }

        return count.ToString();
    }
}
