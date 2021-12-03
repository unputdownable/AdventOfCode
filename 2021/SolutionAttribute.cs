using System;

namespace AoC2021;

public class SolutionAttribute : Attribute
{
    public SolutionAttribute(int day, int part)
    {
        Day = day;
        Part = part;
    }

    public int Day { get; }

    public int Part { get; }
}
