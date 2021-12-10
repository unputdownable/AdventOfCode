using System.Linq;
using System.Text;

namespace AoC2021.Solutions.Day5;

class Plot
{
    int[,] values;

    public Plot(int width, int height)
    {
        values = new int[width, height];
    }

    public int Intersections => (from int v in values where v > 1 select v).Count();

    public void Add(Segment segment)
    {
        foreach (var p in segment.Points)
        {
            values[p.X, p.Y] += 1;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y <= values.GetUpperBound(1); y++)
        {
            var line = new StringBuilder();
            for (var x = 0; x <= values.GetUpperBound(0); x++)
            {
                var v = values[x, y] == 0 ? "." : values[x, y].ToString();
                line.Append($"{v} ");
            }
            sb.AppendLine(line.ToString());
        }

        return sb.ToString();
    }
}
