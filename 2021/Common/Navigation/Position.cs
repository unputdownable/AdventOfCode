namespace AoC2021.Common.Navigation;

public class Position
{
    public Position(int horizontal, int vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    public int Horizontal { get; set; }

    public int Vertical { get; set; }
}