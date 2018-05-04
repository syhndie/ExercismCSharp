using System;
using System.Numerics;

public static class Grains
{
    //this method is for the specific case of the chessboard problem
    //it calculates the nth term of the geometric series (1,2,4,8,16, . . . )
    //this series can be written as (1 * 2^0, 1 * 2^1, 1 * 2^2, 1 * 2^3, . . . )
    //so, in the general case equation, a=1, r=2
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64) throw new ArgumentOutOfRangeException();

        return (ulong)GetNthTerm(1, 2, n);
    }

    //this method is for the specific case of the chessboard problem
    //it calculates the sum of the first 64 terms of the geometric series (1, 2, 4, 8, 16, ...)
    //this series can be written as (1 * 2^0, 1 * 2^1, 1 * 2^2, 1 * 2^3, . . . )
    //so, in the general case equation, a=1, r=2

    public static ulong Total()
    {
        return (ulong)GetSumOfFirstNTerms(1, 2, 64);
    }

    //this is a general method to return the nth term of any geometic series, given a, r, and n
    //nth term = a * r^(n-1)
    private static BigInteger GetNthTerm (int a, int r, int n )
    {
        return a * BigInteger.Pow(r, n - 1);
    }

    //this is a general method to return the sum of the first n terms of any geometric series, given a, r, and n
    //the sum of the first n terms of the series = a(1-r^n)/(1-r)
    private static BigInteger GetSumOfFirstNTerms (int a, int r, int n)
    {
        return a * (1 - BigInteger.Pow(r, n)) / (1 - r);
    }
}