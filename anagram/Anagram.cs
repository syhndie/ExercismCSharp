using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private readonly string lowercaseBaseWord;
    private readonly string orderedBaseWord;

    public Anagram(string baseWord)
    {
        lowercaseBaseWord = baseWord.ToLower();
        orderedBaseWord = AlphabetizeString(baseWord);
    }

    public string[] Anagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>(); 
   
        for (int i = 0; i < potentialMatches.Count(); i++)
        {
            string orderedPotential = AlphabetizeString(potentialMatches[i]);

            if (potentialMatches[i].ToLower() == lowercaseBaseWord) continue;
            if (orderedPotential == orderedBaseWord) anagrams.Add(potentialMatches[i]);
        }

        return anagrams.ToArray();

        //string[] orderedPotentials = potentialMatches
        //    .Select(s => AlphabetizeString(s))
        //    .ToArray();

        //return Enumerable.Range(0, potentialMatches.Count())
        //    .Where(i => potentialMatches[i].ToLower() != lowercaseBaseWord)
        //    .Where(i => orderedPotentials[i] == orderedBaseWord)
        //    .Select(i => potentialMatches[i])
        //    .ToArray();


    }

    private string AlphabetizeString (string word)
    {
        return String.Concat(word.ToLower().OrderBy(c => c));
    }
}