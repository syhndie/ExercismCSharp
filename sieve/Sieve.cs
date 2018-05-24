using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();

        var numbers = Enumerable.Range(2, limit - 1).ToHashSet();

        for (int i = 2; i < limit; i++)
        {
            if (!numbers.Contains(i)) continue; 

            for (int j = 2; i * j <= limit; j++)
            {
                if (!numbers.Contains(i * j)) continue;
                numbers.Remove(i * j);
            }
        }

        return numbers.ToArray();
    }
}