namespace AoC2021.Submarine.Navigation;

public interface INavigationSystem
{
    int Aim { get; set; }

    Position Position { get; set; }

    void Navigate(Command command);
}
