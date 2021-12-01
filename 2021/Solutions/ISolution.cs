using System.Collections.Generic;

namespace AoC2021.Solutions;

public interface ISolution
{
    int Day { get; }

    List<ISolutionPart> Parts { get; }
}
