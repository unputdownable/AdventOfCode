using System;

namespace AoC2021;

public class Program
{
    public static void Main(string[] args)
    {
        var day = Util.GetDay(args, Console.Write, Console.ReadLine);

        var solutionParts = Util.GetSolutionParts(day);
        if (solutionParts.Count == 0)
        {
            Console.WriteLine($"No solution for day {day} :(");
            return;
        }

        foreach (var part in solutionParts)
        {
            Console.WriteLine("-----------");
            Console.WriteLine($" Day {day}");
            Console.WriteLine($" {part.Name}");
            Console.WriteLine($" {part.Description}");
            Console.WriteLine("-----------");
            Console.WriteLine();

            Console.WriteLine("Result: " + part.Execute());
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
