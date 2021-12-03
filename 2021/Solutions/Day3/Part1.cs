using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day3;

[Solution(day: 3, part: 1)]
public class Part1 : ISolutionPart
{
    public string Name => "Binary Diagnostic";

    public string Description => "";

    public string Execute()
    {
        var input = Util.GetInput(3, "1.txt")
            .Select(value => new Binary(value))
            .ToList();

        var gamma = CalculateRate(input, RateType.Gamma);
        var epsilon = CalculateRate(input, RateType.Epsilon);

        return (gamma.ToInt * epsilon.ToInt).ToString();
    }

    private static Binary CalculateRate(List<Binary> input, RateType rateType)
    {
        var gammastr = string.Empty;
        for (int i = 0; i < input.First().Length; i++)
        {
            var bits = input.Select(b => b[i]);
            var zeroes = bits.Count(b => b == '0');
            var ones = bits.Count(b => b == '1');
            gammastr += rateType switch
            {
                RateType.Gamma => zeroes > ones ? "0" : "1",
                RateType.Epsilon => zeroes > ones ? "1" : "0",
                _ => new Exception("Unhandled")
            };
        }

        return new Binary(gammastr);
    }
}

public enum RateType
{
    Gamma,
    Epsilon
}

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
}