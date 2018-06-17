using System;
using System.Collections.Generic;
using System.Linq;

public class Triplet
{
    private readonly int _a;
    private readonly int _b;
    private readonly int _c;

    private int A
    {
        get
        {
            return _a;
        }
    }

    private int B
    {
        get
        {
            return _b;
        }
    }

    private int C
    {
        get
        {
            return _c;
        }
    }
    public Triplet(int a, int b, int c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public int Sum()
    {
        return A + B + C;
    }

    public int Product()
    {
        return A * B * C;
    }

    public bool IsPythagorean()
    { 
        return (Math.Pow(A, 2) + Math.Pow(B, 2) == Math.Pow(C, 2));
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        List<Triplet> triplets = new List<Triplet>();

        for (int a = minFactor; a <= maxFactor; a++)
        {
            for (int b = a + 1; b <= maxFactor; b++)
            {
                for (int c = b + 1; c <= maxFactor; c++)
                {
                    Triplet newTriplet = new Triplet(a, b, c);

                    if (!newTriplet.IsPythagorean()) continue;

                    if (sum != 0 && newTriplet.Sum() != sum) continue;

                    triplets.Add(newTriplet);
                }
            }
        }

        return triplets;
    } 
}