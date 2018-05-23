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

        foreach (int number in range)
        {
           for (int i = 2; number * i <= limit; i++)
            {
                multiples.Add(number * i);                
            }
        }

        return range.Except(multiples).ToArray();
    }
}