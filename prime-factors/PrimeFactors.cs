using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static IEnumerable<int> Factors(long number)
    {
        for(int i = 2; number > 1;)
        {
            while (number % i == 0)
            {
                yield return i;
                number /= i;
            }

            i++;
        }
    }
}