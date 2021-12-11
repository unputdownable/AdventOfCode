using System.Linq;

namespace AoC2021.Solutions.Day1;

public class Part2 : ISolutionPart
{
    public string Name => "Part 2";

    public string Description => "The number of times the sum of measurements in this sliding window increases";

    public int Day => 1;

    public int Part => 2;

    public string Execute()
    {
        var input = Util.GetInput(1, "1.txt").Select(int.Parse).ToList();
        var slider = new Slider(input, 3);

        int? prevSum = null;
        var count = 0;
        while (true)
        {
            if (slider.Window.Size != 3)
                break;

            if (slider.Window.Sum > prevSum)
                count++;

            prevSum = slider.Window.Sum;
            slider.Slide(1);
        }

        return count.ToString();
    }
}
