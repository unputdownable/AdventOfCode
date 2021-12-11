using System.Linq;

namespace AoC2021.Solutions.Day5;

public class Part2 : ISolutionPart
{
    public string Name => "Hydrothermal vents";

    public string Description => "At how many points do at least two lines (with diagonals)";

    public int Day => 5;

    public int Part => 2;

    public string Execute()
    {
        var input = Util.GetInput(5, "1.txt");
        var segments = input.Select(Segment.Parse).ToList();

        var maxX = segments.Max(s => s.Max.X);
        var maxY = segments.Max(s => s.Max.Y);
        var plot = new Plot(maxX + 1, maxY + 1);

        foreach (var segment in segments)
        {
            plot.Add(segment);
        }

        //Console.WriteLine(plot);

        return plot.Intersections.ToString();
    }
}
