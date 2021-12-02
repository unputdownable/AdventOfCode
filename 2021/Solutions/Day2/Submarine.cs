namespace AoC2021.Solutions.Day2;

public class Submarine
{
    public Submarine()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }

    public void Move(Command command)
    {
        (int x, int y) = command.Name switch
        {
            Command.Forward => (command.Value, 0),
            Command.Down => (0, command.Value),
            Command.Up => (0, -command.Value),
            _ => throw new System.Exception()
        };

        Position.Horizontal += x;
        Position.Vertical += y;
    }
}
