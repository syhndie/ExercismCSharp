using System;
using System.Linq;

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
        string[] orderedPotentials = potentialMatches
            .Select(s => AlphabetizeString(s))
            .ToArray();
        
        return Enumerable.Range(0, potentialMatches.Count())
            .Where(i => potentialMatches[i].ToLower() != lowercaseBaseWord)
            .Where(i => orderedPotentials[i] == orderedBaseWord)
            .Select(i => potentialMatches[i])
            .ToArray();
    }

    private string AlphabetizeString (string word)
    {
        return String.Concat(word.ToLower().OrderBy(c => c));
    }
}