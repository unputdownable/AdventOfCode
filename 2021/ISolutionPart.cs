namespace AoC2021;

public interface ISolutionPart
{
    string Name { get; }

    string Description { get; }

    string Execute();
}