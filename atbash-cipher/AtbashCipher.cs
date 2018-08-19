using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        char[] encodedChars = plainValue
            .ToLower()
            .Where(c => Char.IsLetterOrDigit(c))
            .Select(c => Char.IsDigit(c) ? c : (char)( 'z' - ( c - 'a')))
            .ToArray();

        string encodedStringWithoutSpaces = new string(encodedChars);

        return Regex.Replace(encodedStringWithoutSpaces, ".{5}", "$0 ").Trim();
    }

    public static string Decode(string encodedValue)
    {
        char[] decodedChars = encodedValue
            .Where(c => Char.IsLetterOrDigit(c))
            .Select(c => Char.IsDigit(c) ? c : (char)('z' - c + 'a'))
            .ToArray();

        return new string(decodedChars);
    }
}