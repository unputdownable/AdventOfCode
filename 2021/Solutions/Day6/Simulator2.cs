using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Solutions.Day6;

class Simulator2
{
    long[] state = new long[9];

    public Simulator2(IEnumerable<int> ages)
    {
        foreach (var age in ages)
        {
            state[age]++;
        }
    }

    public long Count => state.Sum();

    public void Step()
    {
        var spawnAmount = state[0];

        state[0] = state[1];
        state[1] = state[2];
        state[2] = state[3];
        state[3] = state[4];
        state[4] = state[5];
        state[5] = state[6];
        state[6] = state[7] + spawnAmount;
        state[7] = state[8];
        state[8] = spawnAmount;
    }
}
