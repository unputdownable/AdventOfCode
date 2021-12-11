using System;
using System.Linq;

namespace AoC2021.Solutions.Day4;

public class Part2 : ISolutionPart
{
    public string Name => "Submarine Bingo";

    public string Description => "Find and score the last winning bingo board";

    public int Day => 4;

    public int Part => 2;

    public string Execute()
    {
        var input = Util.GetInput(Day);
        var bingo = Bingo.Parse(input);

        while (bingo.HasNumbers)
        {
            bingo.CallNext();
        }

        if (!bingo.Winners.Any())
            throw new Exception("No winner");

        var lastWinner = bingo.Winners.OrderBy(w => w.Place).Last();
        Console.WriteLine("Winner!");
        Console.WriteLine();
        Console.WriteLine(lastWinner.Board);

        return lastWinner.Score.ToString();
    }
}
