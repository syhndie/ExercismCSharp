using System;
using System.Linq;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2) throw new ArgumentException("Input base cannot be less than 2.");
        if (outputBase < 2) throw new ArgumentException("Output base cannot be less than 2.");
        if (inputDigits.Any(i => i >= inputBase)) throw new ArgumentException("No digit can be greater than the number's base.");
        if (inputDigits.Any(i => i < 0)) throw new ArgumentException("No digit can be less than 0.");
        if (inputBase == outputBase) return inputDigits;

        int[] reversedDigits = inputDigits.Reverse().ToArray();

        int baseTen = (int)
            Enumerable.Range(0, reversedDigits.Length)
            .Select(i => reversedDigits[i] * Math.Pow(inputBase, i))
            .Sum();

        List<int> outputDigits = new List<int>();

        //http://en.wikipedia.org/wiki/Positional_notation#Base_conversion
        int quotient;
        do
        {
            outputDigits.Add(baseTen % outputBase);
            quotient = baseTen / outputBase;
            baseTen /= outputBase;
        }
        while (quotient > 0);

        outputDigits.Reverse();
        return outputDigits.ToArray();
    }
}