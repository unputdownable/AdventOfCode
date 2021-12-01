using AoC2021.Solutions;
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

    public static ISolution GetSolution(int day)
    {
        var solution = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => typeof(ISolution).IsAssignableFrom(t))
            .SingleOrDefault(t => t.GetCustomAttribute<DayAttribute>()?.Day == day);

        if (solution == null)
            return null;

        return (ISolution)Activator.CreateInstance(solution);
    }
}
