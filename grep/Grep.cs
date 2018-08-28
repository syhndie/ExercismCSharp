using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        Settings grepSettings = new Settings(files, flags);

        List<Line> allLines = GetListOfAllLines(files, grepSettings);

        List<Line> matchingLines = GetLinesWithMatch(allLines, pattern, grepSettings);

        List<string> matchingLinesAsStrings = GetStrings(matchingLines, grepSettings);
                
        return String.Join("\n", matchingLinesAsStrings);
    }
    
    private static List<Line> GetListOfAllLines(string[] files, Settings grepSettings)
    {
        var filesWithText = files
            .Select(s => File.ReadAllLines(s))
            .ToArray();

        List<Line> allLines = new List<Line>();

        for (int file = 0; file < filesWithText.Length; file++)
        {
            for (int i = 0; i < filesWithText[file].Length; i++)
            {
                allLines.Add(new Line(filesWithText[file][i], files[file], i + 1, grepSettings));
            }
        }

        return allLines;
    }

    private static List<Line> GetLinesWithMatch(List<Line> lines, string pattern, Settings grepSettings)
    {
        pattern = grepSettings.MatchEntireLine ? $"^{pattern}$" : pattern;

        RegexOptions options = grepSettings.MatchCaseInsensitive ? RegexOptions.IgnoreCase : RegexOptions.None;

        Regex regex = new Regex(pattern, options);

        if (grepSettings.ShowOnlyNonMatches) return lines.Where(l => !regex.IsMatch(l.LineText)).ToList();

        return lines.Where(l => regex.IsMatch(l.LineText)).ToList();
    }

    private static List<string> GetStrings(List<Line> matchingLines, Settings grepSettings)
    {
        if (matchingLines.Count() == 0) return new List<string>();

        if (grepSettings.ShowOnlyFilename)
        {
            return matchingLines
                .Select(l => l.FileName)
                .GroupBy(s => s)
                .Select(g => g.Key)
                .ToList();
        }
    
        return matchingLines.Select(l => $"{l.PrintableFileName}{l.PrintableLineNumber}{l.LineText}").ToList();
    }
}
public class Line
{
    public Line(string lineText, string filename, int lineNumber, Settings grepSettings)
    {
        LineText = lineText;
        FileName = filename;
        LineNumber = lineNumber;
        PrintableFileName = grepSettings.IncludeFilename ? $"{FileName}:" : "";
        PrintableLineNumber = grepSettings.IncludeLineNumber ? $"{LineNumber.ToString()}:" : "";
    }

    public string LineText { get; set; }
    public string FileName { get; set; }
    public int LineNumber { get; set; }
    public string PrintableFileName { get; set; }
    public string PrintableLineNumber { get; set; }
}

public class Settings
{
    private const string fileNameFlag = "-l";
    private const string lineNumberFlag = "-n";
    private const string caseInsensitiveFlag = "-i";
    private const string entireLineFlag = "-x";
    private const string onlyNonMatchesFlag = "-v";

    public Settings(string[] files, string flags)
    {
        IncludeFilename = files.Length > 1;
        ShowOnlyFilename = flags.Contains(fileNameFlag);
        IncludeLineNumber = flags.Contains(lineNumberFlag);
        MatchCaseInsensitive = flags.Contains(caseInsensitiveFlag);
        MatchEntireLine = flags.Contains(entireLineFlag);
        ShowOnlyNonMatches = flags.Contains(onlyNonMatchesFlag);
    }

    public bool IncludeFilename { get; set; }
    public bool ShowOnlyFilename { get; set; }
    public bool IncludeLineNumber { get; set; }
    public bool MatchCaseInsensitive { get; set; }
    public bool MatchEntireLine { get; set; }
    public bool ShowOnlyNonMatches { get; set; }
}