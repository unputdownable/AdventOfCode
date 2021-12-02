using System.Linq;
using AoC2021.Solutions.Day2.Navigation;

namespace AoC2021.Solutions.Day2;

public class Part1 : ISolutionPart
{
    public string Name => "Part 1";

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
