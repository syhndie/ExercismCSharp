using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

[Flags]
public enum Settings
{
    IncludeFileName = 1,
    OnlyFileName = 2,
    LineNumber = 4,
    CaseInsensitive = 8,
    EntireLine = 16,
    NonMatches = 32

}
public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        Settings settings = GetSettings(flags, files);

        List<Line> allLines = GetListOfAllLines(files, settings);

        List<Line> matchingLines = GetLinesWithMatch(allLines, pattern, settings);

        List<string> matchingLinesAsStrings = GetStrings(matchingLines, settings);
                
        return String.Join("\n", matchingLinesAsStrings);
    }
 
    private static Settings GetSettings(string flags, string[] files)
    {
        Settings settings = new Settings();
        if (files.Length > 1) settings = Settings.IncludeFileName;
        if (flags.Contains("-l")) settings = settings | Settings.OnlyFileName;
        if (flags.Contains("-n")) settings = settings | Settings.LineNumber;
        if (flags.Contains("-i")) settings = settings | Settings.CaseInsensitive;
        if (flags.Contains("-x")) settings = settings | Settings.EntireLine;
        if (flags.Contains("-v")) settings = settings | Settings.NonMatches;
        return settings;
    }

    private static List<Line> GetListOfAllLines(string[] files, Settings settings)
    {
        var filesWithText = files
            .Select(s => File.ReadAllLines(s))
            .ToArray();

        List<Line> allLines = new List<Line>();

        for (int file = 0; file < filesWithText.Length; file++)
        {
            for (int i = 0; i < filesWithText[file].Length; i++)
            {
                allLines
                    .Add(new Line(filesWithText[file][i], files[file], i + 1, settings));
            }
        }

        return allLines;
    }

    private static List<Line> GetLinesWithMatch(List<Line> lines, string pattern, Settings settings)
    {
        pattern = 
            settings.HasFlag(Settings.EntireLine) 
            ? $"^{pattern}$" 
            : pattern;

        RegexOptions options = 
            settings.HasFlag(Settings.CaseInsensitive) 
            ? RegexOptions.IgnoreCase 
            : RegexOptions.None;

        Regex regex =  new Regex(pattern, options);

        if (settings.HasFlag(Settings.NonMatches))
        {
            return lines.Where(l => !regex.IsMatch(l.LineText))
                .ToList();
        }


        return lines.Where(l => regex.IsMatch(l.LineText))
            .ToList();
    }

    private static List<string> GetStrings(List<Line> matchingLines, Settings settings)
    {
        if (matchingLines.Count() == 0) return new List<string>();

        if (settings.HasFlag(Settings.OnlyFileName))
        {
            return matchingLines
                .Select(l => l.FileName)
                .GroupBy(s => s)
                .Select(g => g.Key)
                .ToList();
        }
    
        return matchingLines
            .Select(l => $"{l.PrintableFileName}{l.PrintableLineNumber}{l.LineText}")
            .ToList();
    }
}
public class Line
{
    public Line(string lineText, string filename, int lineNumber, Settings settings)
    {
        LineText = lineText;
        FileName = filename;
        LineNumber = lineNumber;

        PrintableFileName = 
            settings.HasFlag(Settings.IncludeFileName) 
            ? $"{FileName}:" 
            : "";

        PrintableLineNumber = 
            settings.HasFlag(Settings.LineNumber) 
            ? $"{LineNumber.ToString()}:" 
            : "";
    }

    public string LineText { get; set; }
    public string FileName { get; set; }
    public int LineNumber { get; set; }
    public string PrintableFileName { get; set; }
    public string PrintableLineNumber { get; set; }
}