using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day1;

public class Slider
{
    private readonly List<int> values;
    private readonly int windowSize;
    int currentIdx = 0;

    public Slider(List<int> values, int windowSize)
    {
        this.values = values;
        this.windowSize = windowSize;
    }

    public void Slide(int offset)
    {
        var newIdx = currentIdx + offset;
        
        if (newIdx < 0 || newIdx >= values.Count)
            throw new System.Exception("Out of bounds");
        
        currentIdx = newIdx;
    }

    public SliderWindow Window => new(values.Skip(currentIdx).Take(windowSize).ToList());
}
