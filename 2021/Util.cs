using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC2021;

public static class Util
{
    public static List<string> GetInput(int day, string name)
    {
        return File.ReadAllLines(Path.Combine("Inputs", day.ToString(), name)).ToList();
    }

    public static List<ISolutionPart> GetSolutionParts(int day)
    {
        var parts = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => typeof(ISolutionPart).IsAssignableFrom(t))
            .Select(t => (ISolutionPart)Activator.CreateInstance(t))
            .Where(i => i.Day == day)
            .OrderBy(i => i.Part)
            .ToList();

        return parts;
    }

    public static int GetDay(string[] args, Action<string> write, Func<string> read)
    {
        string input = null;
        if (args.Length == 2)
        {
            if (args[0] == "-day")
                input = args[1];
        }

        if (!int.TryParse(input, out int day))
        {
            do
            {
                write("Enter day: ");
            }
            while (!int.TryParse(read(), out day));
        }

        return day;
    }
}
