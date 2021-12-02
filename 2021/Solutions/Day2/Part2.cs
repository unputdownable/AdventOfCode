using System.Linq;

namespace AoC2021.Solutions.Day2;

public class Part2 : ISolutionPart
{
    public string Name => "Part 2";

    public string Description => "Multiply your final horizontal position by your final depth (with aim)";

    public string Execute()
    {
        var commands = Util.GetInput(2, "1.txt").Select(Command.Parse);

        var submarine = new SubmarineWithAim();

        foreach (var command in commands)
        {
            submarine.Move(command);
        }

        return (submarine.Position.Horizontal * submarine.Position.Vertical).ToString();
    }
}
