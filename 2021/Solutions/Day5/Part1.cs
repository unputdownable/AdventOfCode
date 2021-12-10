using System;
using System.Collections.Generic;
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

class Plot
{
    int[,] values;

    public Plot(int width, int height)
    {
        values = new int[width, height];
    }

    public int Intersections => (from int v in values where v > 1 select v).Count();

    public void Add(Segment segment)
    {
        foreach (var p in segment.Points)
        {
            values[p.X, p.Y] += 1;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y <= values.GetUpperBound(1); y++)
        {
            var line = new StringBuilder();
            for (var x = 0; x <= values.GetUpperBound(0); x++)
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
    List<Point> points;

    private Segment(Point p1, Point p2)
    {
        P1 = p1;
        P2 = p2;
        points = ExtrapolatePoints();
    }

    public Point P1 { get; }
    public Point P2 { get; }
    public List<Point> Points => points;
    public bool IsHorizontal => P1.Y == P2.Y;
    public bool IsVertical => P1.X == P2.X;
    public Point Max => new Point(Math.Max(P1.X, P2.X), Math.Max(P1.Y, P2.Y));

    public static Segment Parse(string input)
    {
        var pointParts = input.Split(" -> ");
        var p1Parts = pointParts[0].Split(",");
        var p2Parts = pointParts[1].Split(",");
        var p1 = new Point(int.Parse(p1Parts[0]), int.Parse(p1Parts[1]));
        var p2 = new Point(int.Parse(p2Parts[0]), int.Parse(p2Parts[1]));
        return new Segment(p1, p2);
    }

    List<Point> ExtrapolatePoints()
    {
        if (IsHorizontal)
        {
            return Range(P1.X, P2.X).Select(x => new Point(x, P1.Y)).ToList();
        }
        if (IsVertical)
        {
            return Range(P1.Y, P2.Y).Select(y => new Point(P1.X, y)).ToList();
        }

        // diagonal

        return null;
    }

    IEnumerable<int> Range(int x1, int x2) => Enumerable.Range(Math.Min(x1, x2), Math.Abs(x1 - x2) + 1);

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