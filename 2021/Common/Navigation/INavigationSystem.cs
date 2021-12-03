namespace AoC2021.Common.Navigation;

public interface INavigationSystem
{
    int Aim { get; set; }

    Position Position { get; set; }

    void Navigate(Command command);
}
