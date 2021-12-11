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
        var ages = Util.GetInput(Day).Single()
            .Split(',')
            .Select(x => int.Parse(x));

        var simulator = new Simulator2(ages);

        for (int i = 0; i < 256; i++)
        {
            simulator.Step();
        }

        return simulator.Count.ToString();
    }
}
