using System;
using System.Linq;

namespace AoC2021.Solutions.Day4;

[Solution(day: 4, part: 1)]
public class Part1 : ISolutionPart
{
    public string Name => "Submarine Bingo";

    public string Description => "Find and score the first winning bingo board";

    public string Execute()
    {
        var input = Util.GetInput(4, "1.txt");
        var bingo = Bingo.Parse(input);

        while (bingo.HasNumbers)
        {
            bingo.CallNext();
            if (bingo.Winners.Any())
            {
                var winner = bingo.Winners.Single();

                Console.WriteLine("Winner!");
                Console.WriteLine();
                Console.WriteLine(winner.Board);

                return winner.Score.ToString();
            }
        }

        throw new Exception("No winner");
    }
}
