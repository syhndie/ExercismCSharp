using System;
using System.Collections.Generic;
using System.Linq;


public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> products = new HashSet<int>();
        foreach (int mult in multiples)
        {
            for (int i = 1; mult * i < max; i++)
            {
                products.Add(mult * i);
            }
        }
        return products.Sum();
    }
}