using AoC2021.Solutions.Day2.Navigation;

namespace AoC2021.Solutions.Day2;

public class Submarine
{
    private readonly INavigationSystem navigationSystem;

    public Submarine(INavigationSystem navigationSystem)
    {
        this.navigationSystem = navigationSystem;
    }

    public Position Position => navigationSystem.Position;

    public void Move(Command command)
    {
        navigationSystem.Navigate(command);
    }
}
