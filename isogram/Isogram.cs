using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        //check for only letters, white space, and hyphens
        if (!Regex.IsMatch(word, @"^[a-zA-Z-\s]+$") && word != "") throw new ArgumentOutOfRangeException();

        string onlyLowerCaseLetters = Regex.Replace(word.ToLower(), @"[^a-z]", "");
        if (onlyLowerCaseLetters.Distinct().Count() == onlyLowerCaseLetters.Count()) return true;
        return false;
    }
}
