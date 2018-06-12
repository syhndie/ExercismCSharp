using System;

public static class House
{
    private static readonly Line[] _lines = new Line[] 
    {
        new Line("the house ", "", "that Jack built."),
        new Line("the malt ", "", "that lay in "),
        new Line("the rat ", "", "that ate "),
        new Line("the cat ", "", "that killed "),
        new Line("the dog ", "", "that worried "),
        new Line("the cow ", "with the crumpled horn ", "that tossed "),
        new Line("the maiden ", "all forlorn ", "that milked "),
        new Line("the man ", "all tattered and torn ", "that kissed "),
        new Line("the priest ", "all shaven and shorn ", "that married "),
        new Line("the rooster ", "that crowed in the morn ", "that woke "),
        new Line("the farmer ", "sowing his corn ", "that kept "),
        new Line("the horse ", "and the hound and the horn ", "that belonged to ")
    };

    public static string Recite(int verseNumber)
    {
        string verse = "This is ";
        for (int i = verseNumber - 1; i >=0; i--)
        {
            Line line = _lines[i];
            verse = verse + GetLineAsString(line);
        }

        return verse;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string verses = "";
        for (int i = startVerse; i <= endVerse; i++)
        {
            verses = $"{verses}{Recite(i)}\n";
        }
        return verses.TrimEnd('\n');
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
