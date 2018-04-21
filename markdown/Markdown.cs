using System;
using System.Text.RegularExpressions;

//replaced "=>" with return statements
//replaced concatintation of strings using "+" with complete strings and embedded variables, using {}

public static class Markdown
{
    private static string Wrap(string text, string tag)
    {
        return $"<{tag}>{text}</{tag}>";
    }        

    private static bool IsTag(string text, string tag)
    {
        return text.StartsWith($"<{tag}>");
    }

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));

        if (list)
        {
            return parsedText;
        }
        else
        {
            return Wrap(parsedText, "p");
        }
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count += 1;
            }
            else
            {
                break;
            }
        }

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        var headerTag = "h" + count;
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        if (list)
        {
            inListAfter = false;
            return "</ul>" + headerHtml;
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
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            if (list)
            {
                inListAfter = true;
                return innerHtml;
            }
            else
            {
                inListAfter = true;
                return "<ul>" + innerHtml;
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
            return "</ul>" + ParseText(markdown, list);
        }
    }

    private static string ParseLine(string markdown, bool isList, out bool inListAfter)
    {
        var result = ParseHeader(markdown, isList, out inListAfter);

        if (result == null)
        {
            result = ParseLineItem(markdown, isList, out inListAfter);
        }

        if (result == null)
        {
            result = ParseParagraph(markdown, isList, out inListAfter);
        }

        if (result == null)
        {
            throw new ArgumentException("Invalid markdown");
        }

        return result;
    }

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

        if (isList)
        {
            return $"{result}</ul>";
        }
        else
        {
            return result;
        }
    }
}