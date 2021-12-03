using System;

namespace AoC2021.Submarine.Navigation;

public class SimpleNavigation : INavigationSystem
{
    public int Aim { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Position Position { get; set; } = new(0, 0);

    public void Navigate(Command command)
    {
        (int dx, int dy) = command.Name switch
        {
            Command.Forward => (command.Value, 0),
            Command.Down => (0, command.Value),
            Command.Up => (0, -command.Value),
            _ => throw new System.Exception()
        };

        Position.Horizontal += dx;
        Position.Vertical += dy;
    }
}
