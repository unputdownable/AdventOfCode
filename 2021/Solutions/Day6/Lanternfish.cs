using System;

namespace AoC2021.Solutions.Day6;

class Lanternfish
{
    public Lanternfish(int age)
    {
        Timer = age;
    }

    public int Timer { get; private set; }
    public bool ReadyToSpawn => Timer < 0;

    public void Step()
    {
        Timer--;
    }

    public Lanternfish Spawn()
    {
        if (Timer >= 0)
            throw new Exception("Not ready to spawn");

        Timer = 6;
        return new(8);
    }

    public override string ToString()
    {
        return Timer.ToString();
    }
}
