namespace AoC2021.Solutions;

public interface ISolutionPart
{
    string Name { get; }

    string Description { get; }

    string Execute();
}