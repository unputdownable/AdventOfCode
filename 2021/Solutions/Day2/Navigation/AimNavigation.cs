namespace AoC2021.Solutions.Day2.Navigation;

public class AimNavigation : INavigationSystem
{
    public int Aim { get; set; } = 0;

    public Position Position { get; set; } = new(0, 0);

    public void Navigate(Command command)
    {
        switch (command.Name)
        {
            case Command.Down:
                Aim += command.Value;
                break;

            case Command.Up:
                Aim -= command.Value;
                break;

            case Command.Forward:
                Position.Horizontal += command.Value;
                Position.Vertical += Aim * command.Value;
                break;
        }
    }
}
