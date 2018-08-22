using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FoodChain
{
    private static readonly VerseAnimal[] verseAnimals = new VerseAnimal[]
    {
        new VerseAnimal("fly", "I don't know why she swallowed the fly. Perhaps she'll die."),
        new VerseAnimal("spider", "It wriggled and jiggled and tickled inside her."),
        new VerseAnimal("bird", "How absurd to swallow a bird!"),
        new VerseAnimal("cat", "Imagine that, to swallow a cat!"),
        new VerseAnimal("dog", "What a hog, to swallow a dog!"),
        new VerseAnimal("goat", "Just opened her throat and swallowed a goat!"),
        new VerseAnimal("cow", "I don't know how she swallowed a cow!"),
        new VerseAnimal("horse", "She's dead, of course!"),

    };

    public static string Recite(int verseNumber)
    {
        return Recite(verseNumber, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        List<string> listOfLines = new List<string>();

        for (int currentVerse = startVerse; currentVerse <= endVerse; currentVerse++)
        {
            if (currentVerse < 1 || currentVerse > 8) throw new ArgumentException("Invalid verse number");

            VerseAnimal verseAnimal = verseAnimals[currentVerse - 1];

            listOfLines.Add($"I know an old lady who swallowed a {verseAnimal.Name}.");
            listOfLines.Add($"{verseAnimal.Commentary}");

            //the last verse is different, and only has two lines
            if (verseAnimal.IsLast) return String.Join('\n', listOfLines);

            for (int i = currentVerse - 1; i > 0; i--)
            {
                string predator = verseAnimals[i].Name;

                //if the prey is the spider, we add the line about wriggling and jiggling, but slightly modified
                string prey =
                    verseAnimals[i -1].Name == "spider"
                    ? $"{verseAnimals[i - 1].Name} {verseAnimals[1].Commentary.Replace("It", "that")}"
                    : $"{verseAnimals[i - 1].Name}.";

                listOfLines.Add($"She swallowed the {predator} to catch the {prey}");
            }

            //finish the verse with the commentary on the fly, but don't do it a second time if it is the 1st verse
            if (currentVerse != 1) listOfLines.Add(verseAnimals[0].Commentary);

            //between each verse (but not after the last verse) add a blank line
            if (currentVerse != endVerse) listOfLines.Add("");
        }

        return String.Join('\n', listOfLines);
    }
}

public class VerseAnimal
{
    public string Name { get; }
    public string Commentary { get;  }
    public bool IsLast
    {
        get
        {
            return Name == "horse";
        }
    }

    public VerseAnimal(string _name, string _commentary)
    {
        Name = _name;
        Commentary = _commentary;
    }
}
