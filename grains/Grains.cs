using System;

//the nth term = ar^(n-1) = 1*2^(n-1) = 2^(n-1)
//the sum of the first n terms of the series = a(1-r^n)/(1-r) = 1*(1-2^64)/(1-2) = 2^64 = ulong.maxvalue


public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64) throw new ArgumentOutOfRangeException();
        return (ulong)Math.Pow(2, n-1);
    }

    public static ulong Total()
    {
        return ulong.MaxValue;
    }
}