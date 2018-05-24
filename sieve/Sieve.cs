using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();

        List<int> multiples = new List<int>();

        var range = Enumerable.Range(2, limit - 1);

        for (int i = 2; i < limit; i++)
        {
            if (multiples.Contains(i)) continue;

            for (int j = 2; i * j <= limit; j++)
            {
                if (multiples.Contains(i * j)) continue;
                multiples.Add(i * j);
            }
        }

        return range.Except(multiples).ToArray();
    }
}