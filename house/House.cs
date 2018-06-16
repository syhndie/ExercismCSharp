using System;
using System.Collections.Generic;
using System.Linq;

public static class House
{
    private static readonly Dictionary<int, Line> IntToLine = new Dictionary<int, Line>
    {
        {1, new Line("the house ", "", "that Jack built.") },
        {2, new Line("the malt ", "", "that lay in ") },
        {3, new Line("the rat ", "", "that ate ") },
        {4, new Line("the cat ", "", "that killed ") },
        {5, new Line("the dog ", "", "that worried ") },
        {6, new Line("the cow ", "with the crumpled horn ", "that tossed ") },
        {7, new Line("the maiden ", "all forlorn ", "that milked ") },
        {8, new Line("the man ", "all tattered and torn ", "that kissed ") },
        {9, new Line("the priest ", "all shaven and shorn ", "that married ") },
        {10, new Line("the rooster ", "that crowed in the morn ", "that woke ") },
        {11, new Line("the farmer ", "sowing his corn ", "that kept ") },
        {12, new Line("the horse ", "and the hound and the horn ", "that belonged to ") }
    };

    public static string Recite(int verseNumber)
    {
        string intro = "This is ";

        var lines = Enumerable.Range(1, verseNumber)
            .Reverse()
            .Select(i => IntToLine[i])
            .Select(l => GetLineAsString(l))
            .Aggregate((s1, s2) => s1 + s2);

        return $"{intro}{lines}";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return Enumerable.Range(startVerse, endVerse - startVerse + 1)
            .Select(i => Recite(i))
            .Aggregate((v1, v2) => v1 + '\n' + v2)
            .TrimEnd('\n');
    }

    private static string GetLineAsString(Line line)
    {
        return $"{line.Subject}{line.Description}{line.Linkage}";
    }
}

public class Line
{
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Linkage { get; set; }

    public Line (string subject, string description, string linkage)
    {
        Subject = subject;
        Description = description;
        Linkage = linkage;
    }
}