using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        char[] charArray = number.ToString().ToCharArray();
        int total = 0;

        foreach (char charDigit in charArray)
        {
            var digit = Char.GetNumericValue(charDigit);
            total += (int)Math.Pow(digit, charArray.Length);
        }

        return total == number;
    }
}