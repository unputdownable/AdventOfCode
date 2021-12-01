using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day1;

public class SliderWindow
{
    private readonly List<int> values;

    public SliderWindow(List<int> values)
    {
        this.values = values;
    }

    public int Size => values.Count;

    public int Sum => values.Sum();
}
