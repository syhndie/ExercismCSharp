using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        List<char> hypenOrWhite = new List<char> { '-', ' ' };

        var charList = word.ToLower().ToList();
        charList.RemoveAll(c => hypenOrWhite.Contains(c));

        List<char> allowable = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        if (charList.Any(c => !allowable.Contains(c))) throw new ArgumentOutOfRangeException();

        if (charList.Count() == charList.Distinct().Count()) return true;        
        return false;
    }
}
