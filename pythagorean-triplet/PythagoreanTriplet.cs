using System;
using System.Collections.Generic;

public class Triplet
{
    public int a;
    public int b;
    public int c;
    
    public Triplet(int _a, int _b, int _c)
    {
        a = _a;
        b = _b;
        c = _c;
    }

    public int Sum()
    {
        return a + b + c;
    }

    public int Product()
    {
        return a * b * c;
    }

    public bool IsPythagorean()
    { 
        return ((a * a)  + (b * b) == (c * c));
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {      
        for (int _a = minFactor; _a < maxFactor - 1; _a++)
        {
            for (int _b = _a + 1; _b < maxFactor; _b++)
            {
                for (int _c = _b + 1; _c <= maxFactor; _c++)
                {
                    Triplet newTriplet = new Triplet(_a, _b, _c);

                    if (!newTriplet.IsPythagorean()) continue;

                    if (sum != 0 && newTriplet.Sum() != sum) continue;

                    yield return newTriplet;
                }
            }
        }
    } 
}