using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        Dictionary<string, int> newDictionary = new Dictionary<string, int>();

        foreach (int score in old.Keys)
        {
            foreach (string letter in old[score])
            {
                newDictionary.Add(letter.ToLower(), score);
            }
        }
        return newDictionary;
    }
}