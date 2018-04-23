﻿using System;
using System.Text.RegularExpressions;

//changed order of methods to reflect flow of the program
//took single-line actions after if statements out of brackets and onto same line with if statement
//replaced var with actual type

public static class Markdown
{
    public static string Parse(string markdown)
    {
        string[] linesArray = markdown.Split('\n');
        string result = "";
        bool isList = false;

        for (int i = 0; i < linesArray.Length; i++)
        {
            string lineResult = ParseLine(linesArray[i], isList, out isList);
            result += lineResult;
        }

        if (isList) return $"{result}</ul>";
        else return result;
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        string result = ParseHeader(markdown, list, out inListAfter);

        if (result == null) result = ParseLineItem(markdown, list, out inListAfter);
        if (result == null) result = ParseParagraph(markdown, list, out inListAfter);
        if (result == null) throw new ArgumentException("Invalid markdown");

        return result;
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        int count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#') count += 1;
            else break;
        }

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        string headerTag = $"h{count}";
        string headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        if (list)
        {
            inListAfter = false;
            return $"</ul>{headerHtml}";
        }
        else
        {
            inListAfter = false;
            return headerHtml;
        }
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            string innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            if (list)
            {
                inListAfter = true;
                return innerHtml;
            }
            else
            {
                inListAfter = true;
                return $"<ul>{innerHtml}";
            }
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        if (!list)
        {
            inListAfter = false;
            return ParseText(markdown, list);
        }
        else
        {
            inListAfter = false;
            return $"</ul>{ParseText(markdown, list)}";
        }
    }

    private static string ParseText(string markdown, bool list)
    {
        string parsedText = Parse_(Parse__((markdown)));

        if (list)
        {
            return parsedText;
        }
        else
        {
            return Wrap(parsedText, "p");
        }
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag)
    {
        string pattern = $"{delimiter}(.+){delimiter}";
        string replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(markdown, pattern, replacement);
    }
    private static bool IsTag(string text, string tag) => text.StartsWith($"<{tag}>");
}