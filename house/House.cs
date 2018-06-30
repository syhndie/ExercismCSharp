using System;
using System.Collections.Generic;
using System.Linq;

public static class House
{
    private static readonly string[] allParts = new string[]
    {
        "This is the",
        "house that Jack built.",
        "malt that lay in the",
        "rat that ate the",
        "cat that killed the",
        "dog that worried the",
        "cow with the crumpled horn that tossed the",
        "maiden all forlorn that milked the",
        "man all tattered and torn that kissed the",
        "priest all shaven and shorn that married the",
        "rooster that crowed in the morn that woke the",
        "farmer sowing his corn that kept the",
        "horse and the hound and the horn that belonged to the"
    };
    public static string Recite(int verseNumber)
    {
        return Recite(verseNumber, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var versesEnumerable = Enumerable.Range(startVerse, endVerse - (startVerse - 1)).Select(i => GetSingleVerse(i));
        return String.Join("\n", versesEnumerable);
    }

    private static string GetSingleVerse(int verseNumber)
    {
        var partsAsArray = Enumerable.Range(1, verseNumber)
            .Select(i => allParts[i]).Reverse();

        var partsAsString = String.Join(" ", partsAsArray);

        return $"{allParts[0]} {partsAsString}";
    }
}