namespace AoC2021.Solutions.Day2;

public class SubmarineWithAim
{
    private int aim = 0;

    public SubmarineWithAim()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }

    public void Move(Command command)
    {
        switch (command.Name)
        {
            case Command.Down:
                aim += command.Value;
                break;

            case Command.Up:
                aim -= command.Value;
                break;

            case Command.Forward:
                Position.Horizontal += command.Value;
                Position.Vertical += aim * command.Value;
                break;
        }
    }
}
