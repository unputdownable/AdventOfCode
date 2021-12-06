using System;
using System.Linq;
using System.Text;

namespace AoC2021.Solutions.Day4;

public class BingoBoard
{
    BoardValue[][] values;

    public BingoBoard(string[] rows)
    {
        if (rows.Length != 5) throw new ArgumentException();

        values = new BoardValue[rows.Length][];

        for (int y = 0; y < rows.Length; y++)
        {
            values[y] = rows[y].Split(' ')
                .Where(p => !string.IsNullOrEmpty(p))
                .Select(p => new BoardValue(int.Parse(p.Trim())))
                .ToArray();
        }
    }

    public void Call(int number)
    {
        foreach (var row in values)
        {
            foreach (var value in row)
            {
                if (value.Value == number)
                {
                    value.Marked = true;
                }
            }
        }
    }

    public bool HasWon()
    {
        for (int y = 0; y < values.Length; y++)
        {
            var rowMarked = values[y].All(y => y.Marked);

            var col = values.Select(v => v[y]);
            var colMarked = col.All(col => col.Marked);

            if (rowMarked || colMarked)
            {
                return true;
            }
        }

        return false;
    }

    public int Score(int number)
    {
        var sumOfUnmarked = values.SelectMany(v => v).Where(v => !v.Marked).Sum(v => v.Value);
        return sumOfUnmarked * number;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var row in values)
        {
            var line = string.Format("{0, 4} {1, 4} {2, 4} {3, 4} {4, 4}", row);
            sb.AppendLine(line);
        }

        return sb.ToString();
    }

    public class BoardValue
    {
        public BoardValue(int value, bool marked = false)
        {
            Value = value;
            Marked = marked;
        }

        public int Value { get; set; }
        public bool Marked { get; set; }

        public override string ToString()
        {
            if (Marked)
                return $"[{Value}]";

            return $" {Value} ";
        }
    }
}
