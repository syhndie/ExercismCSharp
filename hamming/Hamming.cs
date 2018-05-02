using System;
using System.Linq;
using System.Collections.Generic;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();

        return firstStrand.Zip(secondStrand, (c1, c2) => c1 != c2).Count(b => b);
    }
}