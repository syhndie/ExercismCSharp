using System;
using System.Linq;
using System.Collections.Generic;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || digits.Length < span) throw new ArgumentException();
        if (digits.Any(c => !Char.IsDigit(c))) throw new ArgumentException();

        return Enumerable
            .Range(0, digits.Length - span + 1)
            .Select(i => digits.Substring(i, span))
            .Select(s => GetProductFromSegment(s))
            .Max();
    }

    private static int GetProductFromSegment (string segment)
    {
        return (int)segment
            .Select(c => Char.GetNumericValue(c))
            .Aggregate(1d, (acc, digit) => acc * digit);
    }
}