using AoC2021.Solutions;
using System;
using System.Linq;
using System.Reflection;

var solutions = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract)
    .Where(t => typeof(ISolution).IsAssignableFrom(t))
    .Select(t => (ISolution)Activator.CreateInstance(t));

int day;
do
{
    Console.Write("Enter day: ");
}
while (!int.TryParse(Console.ReadLine(), out day));

var solution = solutions.SingleOrDefault(s => s.Day == day);
if (solution is null)
{
    Console.WriteLine($"No solution for day {day} :(");
}

foreach (var part in solution.Parts)
{
    var result = part.Execute();
    Console.WriteLine("-----------");
    Console.WriteLine($" {part.Name}");
    Console.WriteLine($" {part.Description}");
    Console.WriteLine("-----------");
    Console.WriteLine();
    Console.Write("Result: " + result);
    Console.WriteLine();
}

// run solution for day
// open folder/file with result or print result
