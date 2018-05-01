using System;
using System.Linq;
using System.Collections.Generic;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();

        var firstArray = firstStrand.ToCharArray();
        var secondArray = secondStrand.ToCharArray();

        int hamming = 0;

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] != secondArray[i]) hamming++;
        }

        return hamming;
    }
}