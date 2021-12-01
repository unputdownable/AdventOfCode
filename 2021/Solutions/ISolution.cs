using System.Collections.Generic;

namespace AoC2021.Solutions;

public interface ISolution
{
    List<ISolutionPart> Parts { get; }
}
