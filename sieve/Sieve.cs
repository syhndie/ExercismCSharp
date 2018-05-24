using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();

        var primes = Enumerable.Range(2, limit - 1).ToHashSet();

        for (int i = 2; i < limit; i++)
        {
            if (!primes.Contains(i)) continue; 

            for (int j = 2; i * j <= limit; j++)
            {
                if (!primes.Contains(i * j)) continue;
                primes.Remove(i * j);
            }
        }

        return primes.ToArray();
    }
}