using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var numberNoHyphens = number.Replace("-", "");

        if (!Regex.IsMatch(numberNoHyphens, @"^([\d]{9})[X\d]$")) return false;

        var intArray = numberNoHyphens
            .ToCharArray()
            .Select(c => c != 'X' ? (int)c - 48 : 10)
            .ToArray();

        var sumOfProducts = Enumerable.Range(1, 10)
            .Reverse()
            .Select(i => i * intArray[i - 1])
            .Sum();

        return sumOfProducts % 11 == 0;
    }
}

//(x1 * 10  +  x2 * 9  +  x3 * 8  +  x4 * 7  +  x5 * 6  +  x6 * 5  +  x7 * 4  +  x8 * 3  +  x9 * 2  +  x10 * 1)  mod 11  ==  0
