using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var acronymArray = Regex.Replace(phrase.ToUpper(), @"[^A-Z]+", ",")
            .Split(',')
            .Select(s => s.Substring(0, 1))
            .ToArray();
        return String.Join("", acronymArray); 
    }
}