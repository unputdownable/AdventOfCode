using System.Linq;
using AoC2021.Common;
using AoC2021.Common.Navigation;

namespace AoC2021.Solutions.Day2;

public class Part2 : ISolutionPart
{
    public string Name => "Submarine navigation with aim";

    public string Description => "Multiply your final horizontal position by your final depth (with aim)";

    public int Day => 2;

    public int Part => 2;

    public string Execute()
    {
        var commands = Util.GetInput(Day).Select(Command.Parse);

        var submarine = new Submarine(new AimNavigation());

        foreach (var command in commands)
        {
            submarine.Move(command);
        }

        return (submarine.Position.Horizontal * submarine.Position.Vertical).ToString();
    }
}
