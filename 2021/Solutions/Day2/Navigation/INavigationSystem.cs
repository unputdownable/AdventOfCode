namespace AoC2021.Solutions.Day2.Navigation;

public interface INavigationSystem
{
    int Aim { get; set; }

    Position Position { get; set; }

    void Navigate(Command command);
}
