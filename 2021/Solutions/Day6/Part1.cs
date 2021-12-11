using System.Linq;

namespace AoC2021.Solutions.Day6;

public class Part1 : ISolutionPart
{
    public int Day => 6;

    public int Part => 1;

    public string Name => "Lanternfish";

    public string Description => "Find a way to simulate lanternfish. How many lanternfish would there be after 80 days";

    public string Execute()
    {
        var fish = Util.GetInput(Day, "1.txt").Single()
            .Split(',')
            .Select(x => int.Parse(x))
            .Select(a => new Lanternfish(a))
            .ToList();

        var simulator = new Simulator(fish);
        simulator.Step(80);

        return simulator.FishCount.ToString();
    }
}
