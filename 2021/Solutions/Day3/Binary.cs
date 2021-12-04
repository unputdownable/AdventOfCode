using System;

namespace AoC2021.Solutions.Day3;

public class Binary
{
    private readonly string value;

    public Binary(string value)
    {
        this.value = value;
    }

    public char this[int idx] => value[idx];

    public int Length => value.Length;

    public int ToInt => Convert.ToInt32(value, 2);

    public override string ToString()
    {
        return value;
    }
}