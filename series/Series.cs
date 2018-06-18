using System;
using System.Linq;

public class Series
{
    private string numberString;

    public Series(string numbers)
    {
        numberString = numbers;
    }

    public int[][] Slices(int sliceLength)
    {
        if (numberString.Length < sliceLength) throw new ArgumentException();

        return Enumerable
            .Range(0, numberString.Length - sliceLength + 1)
            .Select(i => numberString.Substring(i, sliceLength))
            .Select(s => GetIntArray(s))
            .ToArray();
    }

    private int[] GetIntArray(string subString)
    {
        return subString
            .Select(c => (int)Char.GetNumericValue(c))
            .ToArray();
    }
}