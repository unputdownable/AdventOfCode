namespace AoC2021;

public interface ISolutionPart
{
    int Day { get; }

    int Part { get; }

    string Name { get; }

    string Description { get; }

    string Execute();
}