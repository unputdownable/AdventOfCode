using System;

namespace AoC2021;

public class DayAttribute : Attribute
{
    public int Day { get; }

    public DayAttribute(int day)
    {
        Day = day;
    }
}
