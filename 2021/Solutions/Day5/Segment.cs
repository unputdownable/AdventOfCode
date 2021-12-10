using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day5;

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
