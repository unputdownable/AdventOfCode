using System;
using System.Linq;
using System.Text;

namespace AoC2021.Solutions.Day5;

[Solution(day: 5, part: 1)]
public class Part1 : ISolutionPart
{
    public string Name => "Hydrothermal vents";

    public string Description => "At how many points do at least two lines overlap";

    public string Execute()
    {
        var input = Util.GetInput(5, "1.txt");
        var segments = input.Select(Segment.Parse)
            .Where(s => s.IsVertical || s.IsHorizontal)
            .ToList();

        var maxX = Math.Max(segments.Max(s => s.P1.X), segments.Max(s => s.P2.X));
        var maxY = Math.Max(segments.Max(s => s.P1.Y), segments.Max(s => s.P2.Y));
        var plot = new Plot(maxX + 1, maxY + 1);

        foreach (var segment in segments)
        {
            plot.Add(segment);
        }

        //Console.WriteLine(plot);

        return plot.IntersectionCount().ToString();
    }
}

class Plot
{
    int[,] values;

    public Plot(int width, int height)
    {
        values = new int[width, height];
    }

    public void Add(Segment segment)
    {
        for (var y = 0; y <= values.GetUpperBound(0); y++)
        {
            for (var x = 0; x <= values.GetUpperBound(1); x++)
            {
                if (segment.Intersects(new Point(x, y)))
                    values[x, y] += 1;
            }
        }
    }

    public int IntersectionCount()
    {
        var sum = 0;
        foreach (var v in values)
        {
            if (v > 1)
                sum += 1;
        }

        return sum;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y <= values.GetUpperBound(0); y++)
        {
            var line = new StringBuilder();
            for (var x = 0; x <= values.GetUpperBound(1); x++)
            {
                var v = values[x, y] == 0 ? "." : values[x, y].ToString();
                line.Append($"{v} ");
            }
            sb.AppendLine(line.ToString());
        }

        return sb.ToString();
    }
}

class Segment
{
    private Segment(Point p1, Point p2)
    {
        P1 = p1;
        P2 = p2;
    }

    public Point P1 { get; }
    public Point P2 { get; }

    public static Segment Parse(string input)
    {
        var pointParts = input.Split(" -> ");
        var p1Parts = pointParts[0].Split(",");
        var p2Parts = pointParts[1].Split(",");
        var p1 = new Point(int.Parse(p1Parts[0]), int.Parse(p1Parts[1]));
        var p2 = new Point(int.Parse(p2Parts[0]), int.Parse(p2Parts[1]));
        return new Segment(p1, p2);
    }

    public bool IsHorizontal => P1.Y == P2.Y;
    public bool IsVertical => P1.X == P2.X;

    public bool Intersects(Point p)
    {
        if (p.Y == P1.Y && p.Y == P2.Y)
        {
            return (p.X >= P1.X && p.X <= P2.X) || (p.X <= P1.X && p.X >= P2.X);
        }
        if (p.X == P1.X && p.X == P2.X)
        {
            return (p.Y >= P1.Y && p.Y <= P2.Y) || (p.Y <= P1.Y && p.Y >= P2.Y);
        }

        return false;
    }

    public override string ToString()
    {
        return $"{P1} -> {P2}";
    }
}

class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}