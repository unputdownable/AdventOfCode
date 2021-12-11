using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day3;

public class Part1 : ISolutionPart
{
    public string Name => "Binary Diagnostic";

    public string Description => "";

    public int Day => 3;

    public int Part => 1;

    public string Execute()
    {
        var input = Util.GetInput(Day)
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

    private enum RateType
    {
        Gamma,
        Epsilon
    }
}
