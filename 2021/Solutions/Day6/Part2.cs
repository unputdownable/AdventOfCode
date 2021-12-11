using System.Linq;

namespace AoC2021.Solutions.Day6;

public class Part2 : ISolutionPart
{
    public int Day => 6;

    public int Part => 2;

    public string Name => "Lanternfish";

    public string Description => "Find a way to simulate lanternfish. How many lanternfish would there be after 256 days";

    public string Execute()
    {
        var lanternfish = Util.GetInput(Day, "sample.txt").Single()
            .Split(',')
            .Select(x => int.Parse(x))
            .ToList();

        for (int day = 0; day < 256; day++)
        {
            var count = lanternfish.Count;
            for (int i = 0; i < count; i++)
            {
                lanternfish[i]--;
                if (lanternfish[i] < 0)
                {
                    lanternfish.Add(8);
                    lanternfish[i] = 6;
                }
            }
        }

        return lanternfish.Count.ToString();
    }
}
