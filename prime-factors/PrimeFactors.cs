using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> primeFactors = new List<int>();

        for(int i = 2; number > 1; i++)
        {
            while (number % i == 0)
            {
                primeFactors.Add(i);
                number /= i;
            }
        }
        return primeFactors.ToArray();
    }
}