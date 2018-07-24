using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int count = 0;

        foreach (T item in input)
        {
            count++;
        }
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        List<T> outList = new List<T>();

        for (int i = Length(input) - 1; i >= 0; i--)
        {
            outList.Add(input[i]);
        }

        return outList;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        List<TOut> list = new List<TOut>();

        foreach (TIn item in input)
        {
            TOut newItem = map(item);
            list.Add(newItem);
        }

        return list;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        List<T> list = new List<T>();
        foreach (T item in input)
        {
            if (predicate(item)) list.Add(item);
        }

        return list;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var accumulator = start;

        foreach (TIn item in input)
        {
            accumulator = func(accumulator, item);
        }

        return accumulator;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {

        List<TIn> reversedList = Reverse(input);

        var accumulator = start;

        foreach (TIn item in reversedList)
        {
            accumulator = func(item, accumulator);
        }

        return accumulator;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        List<T> list = new List<T>();
        return Foldl(input, list, (x, y) => Append(x, y));
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        foreach (T item in right)
        {
            left.Add(item);
        }

        return left;
    }
}