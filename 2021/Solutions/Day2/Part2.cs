namespace AoC2021.Solutions.Day2;

using System.Linq;
using AoC2021.Submarine;
using AoC2021.Submarine.Navigation;

public class Part2 : ISolutionPart
{
    public string Name => "Part 2";

    public string Description => "Multiply your final horizontal position by your final depth (with aim)";

    public string Execute()
    {
        var commands = Util.GetInput(2, "1.txt").Select(Command.Parse);

        var submarine = new Submarine(new AimNavigation());

        foreach (var command in commands)
        {
            submarine.Move(command);
        }

        return (submarine.Position.Horizontal * submarine.Position.Vertical).ToString();
    }
}
