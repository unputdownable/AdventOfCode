using System;
using System.Collections.Generic;

namespace AoC2021.Solutions.Day1;

public class Day1 : ISolution
{
    public int Day => 1;

    public List<ISolutionPart> Parts => new()
    {
        new Day1Part1(),
        new Day1Part1() { Name = "" }
    };
}
