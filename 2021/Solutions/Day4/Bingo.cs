using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Solutions.Day4;

public class Bingo
{
    BingoBoard[] boards;
    Queue<int> numbers;
    int? currentNumber;
    Dictionary<BingoBoard, Winner> winners;

    private Bingo(BingoBoard[] boards, int[] numbers)
    {
        this.boards = boards;
        this.numbers = new(numbers);
        winners = new();
    }

    public static Bingo Parse(IEnumerable<string> input)
    {
        var inputNumbers = input.First();
        var inputBoards = input.Where(i => !string.IsNullOrWhiteSpace(i)).Skip(1);

        var boards = inputBoards.Chunk(5).Select(c => new BingoBoard(c)).ToArray();
        var numbers = inputNumbers.Split(',').Select(i => int.Parse(i)).ToArray();

        return new Bingo(boards, numbers);
    }

    public bool HasNumbers => numbers.Any();

    public List<Winner> Winners => winners.Values.ToList();

    public void CallNext()
    {
        var number = numbers.Dequeue();
        currentNumber = number;

        foreach (var b in boards)
        {
            b.Call(number);
        }

        UpdateWinners();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var b in boards)
        {
            sb.Append(b.ToString());
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private void UpdateWinners()
    {
        foreach (var b in boards)
        {
            if (b.HasWon())
            {
                if (!winners.ContainsKey(b))
                {
                    winners.Add(b, new Winner(b, b.Score(currentNumber.Value), winners.Count));
                }

            }
        }
    }

    public record Winner(BingoBoard Board, int Score, int Place);
}
