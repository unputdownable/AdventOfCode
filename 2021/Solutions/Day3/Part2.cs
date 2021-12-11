using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day3;

public class Part2 : ISolutionPart
{
    public string Name => "Binary Diagnostic";

    public string Description => "Life support";

    public int Day => 3;

    public int Part => 2;

    public string Execute()
    {
        var input = Util.GetInput(Day)
            .Select(value => new Binary(value))
            .ToList();

        var oxygen = CaclulateLifeSupportRating(input, LifeSupportRating.Oxygen);
        var co2 = CaclulateLifeSupportRating(input, LifeSupportRating.CO2);

        return (oxygen.ToInt * co2.ToInt).ToString();
    }

    private static Binary CaclulateLifeSupportRating(List<Binary> input, LifeSupportRating rating)
    {
        for (int i = 0; i < input.First().Length; i++)
        {
            var ones = input.Count(value => value[i] == '1');
            var zeroes = input.Count(value => value[i] == '0');

            char? mostCommon = null;
            char? leastCommon = null;
            if (ones > zeroes)
            {
                mostCommon = '1';
                leastCommon = '0';
            }
            else if (zeroes > ones)
            {
                mostCommon = '0';
                leastCommon = '1';
            }

            var toPick = rating switch
            {
                LifeSupportRating.Oxygen => mostCommon ?? '1',
                LifeSupportRating.CO2 => leastCommon ?? '0',
                _ => throw new Exception()
            };

            input = input.Where(value => value[i] == toPick).ToList();

            if (input.Count == 1)
                break;
        }

        return input.Single();
    }

    private enum LifeSupportRating
    {
        Oxygen,
        CO2
    }
}