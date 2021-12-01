using AoC2021;
using System;

int day;
do
{
    Console.Write("Enter day: ");
}
while (!int.TryParse(Console.ReadLine(), out day));

var solution = Util.GetSolution(day);
if (solution is null)
{
    Console.WriteLine($"No solution for day {day} :(");
    return;
}

foreach (var part in solution.Parts)
{
    var result = part.Execute();
    Console.WriteLine("-----------");
    Console.WriteLine($" {part.Name}");
    Console.WriteLine($" {part.Description}");
    Console.WriteLine("-----------");
    Console.WriteLine();
    Console.WriteLine("Result: " + result);
    Console.WriteLine();
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey();
