using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var pattern = new Regex(@"['\-\w]+");

        var matches = pattern.Matches(phrase);

        return matches
            .Select(m => m.ToString())
            .Select(s => s.ToLower())
            .Select(s => s.Trim('\'','"'))
            .GroupBy(s => s)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}