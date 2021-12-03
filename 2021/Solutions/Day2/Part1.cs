﻿using System.Linq;
using AoC2021.Common;
using AoC2021.Common.Navigation;

namespace AoC2021.Solutions.Day2;

[Solution(day: 2, part: 1)]
public class Part1 : ISolutionPart
{
    public string Name => "Submarine navigation";

    public string Description => "Multiply your final horizontal position by your final depth";

    public string Execute()
    {
        var commands = Util.GetInput(2, "1.txt").Select(Command.Parse);

        var submarine = new Submarine(new SimpleNavigation());

        foreach (var command in commands)
        {
            submarine.Move(command);
        }

        return (submarine.Position.Horizontal * submarine.Position.Vertical).ToString();
    }
}
