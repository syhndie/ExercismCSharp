using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        Dictionary<int, string> romanLookUp = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 2000, "MM" },
            { 3000, "MMM" },
            { 100, "C"},
            { 200, "CC" },
            { 300, "CCC" },
            { 400, "CD" },
            { 500, "D" },
            { 600, "DC" },
            { 700, "DCC" },
            { 800, "DCCC" },
            { 900, "CM" },
            { 10, "X" },
            { 20, "XX" },
            { 30, "XXX" },
            { 40, "XL" },
            { 50, "L" },
            { 60, "LX" },
            { 70, "LXX" },
            { 80, "LXXX" },
            { 90, "XC" },
            { 1, "I" },
            { 2, "II" },
            { 3, "III" },
            { 4, "IV" },
            { 5, "V" },
            { 6, "VI" },
            { 7, "VII" },
            { 8, "VIII" },
            { 9, "IX" },
            { 0, "" } 
        };

        if (value > 3000) throw new ArgumentException("Integer cannot be greater than 3,000.");
        if (value < 0) throw new ArgumentException("Integer must be positive.");

        int[] digits = value
            .ToString()
            .ToCharArray()
            .Reverse()
            .Select(c => int.Parse(c.ToString()))
            .ToArray();

        var digitValues = Enumerable.Range(0, digits.Count())
            .Select(i => digits[i] *= (int)Math.Pow(10, i))
            .Reverse()
            .Select(i => romanLookUp[i]);

        return String.Concat(digitValues);
    }
}