using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day7;

public class Part1 : ISolutionPart
{
    public int Day => 7;

    public int Part => 1;

    public string Name => "Crabs in submarines";

    public string Description => "Determine the horizontal position that the crabs can align to using the least fuel possible. How much fuel must they spend to align to that position?";

    public string Execute()
    {
        var positions = Util.GetInput(Day)
            .Single()
            .Split(',')
            .Select(x => int.Parse(x))
            .ToList();

        var min = positions.Min();
        var max = positions.Max();

        var fuelCosts = new Dictionary<int, int>();

        for (int i = min; i <= max; i++)
        {
            fuelCosts[i] = 0;
            foreach (var pos in positions)
            {
                var delta = Math.Abs(pos - i);
                fuelCosts[i] += delta;
            }
        }

        return fuelCosts.Min(x => x.Value).ToString();
    }
}
