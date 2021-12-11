using System.Collections.Generic;

namespace AoC2021.Solutions.Day6;

class Simulator
{
    private readonly List<Lanternfish> fish;

    public Simulator(List<Lanternfish> fish)
    {
        this.fish = fish;
    }

    public int FishCount => fish.Count;

    public void Step(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            if (i % 10 == 0) System.Console.WriteLine("Step " + i);
            Step();
        }
    }

    public void Step()
    {
        var arr = fish.ToArray();
        foreach (var f in arr)
        {
            f.Step();

            if (f.ReadyToSpawn)
                fish.Add(f.Spawn());
        }
    }
}
