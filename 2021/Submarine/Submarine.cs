namespace AoC2021.Submarine;

using AoC2021.Submarine.Navigation;

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
