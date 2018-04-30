using System;
using System.Linq;

//Find the difference between the square of the sum and the sum of the squares of the first N natural numbers.


public static class DifferenceOfSquares
{
    public static int[] CreateSeries(int max)
    {
        int[] series = new int[max];
        for (int i = 0; i < max; i++)
        {
            series[i] = i + 1;
        }
        return series;
    }
    public static int CalculateSquareOfSum(int max)
    {
        int[] series = CreateSeries(max);
        return series.Sum() * series.Sum();
    }

    public static int CalculateSumOfSquares(int max)
    {
        int[] series = CreateSeries(max);
        for (int i = 0; i < max; i++)
        {
            series[i] = series[i] * series[i];
        }
        return series.Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}