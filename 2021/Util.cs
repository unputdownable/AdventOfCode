using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021;

public static class Util
{
    public static List<string> GetInput(int day, string name)
    {
        return File.ReadAllLines(Path.Combine("Inputs", day.ToString(), name)).ToList();
    }
}
