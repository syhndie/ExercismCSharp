using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (!input.ToLower().ToCharArray().Contains(alphabet[i])) return false;
        }
        return true;
    }
}
