using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();

        var aliqot = Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum();

        if (aliqot < number) return Classification.Deficient;
        if (aliqot > number) return Classification.Abundant;
        return Classification.Perfect;
    }
}
