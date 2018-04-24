using System;
using System.Text.RegularExpressions;

//changed order of methods to reflect flow of the program
//took single-line actions after if statements out of brackets and onto same line with if statement
//replaced var with actual type
//replaced concatanation of strings using "foo" + var + "foo" with $"foo{var}foo"
//when if statement and else statement resulted in same action, moved that action out of the if/else block
//changed if (not something) to if (somtehing)
//renamed some methods and variables to be more clear
//removed unused method

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

    private static string ParseLine(string markdown, bool isList, out bool inListAfter)
    {
        string result = ParseHeader(markdown, isList, out inListAfter);

        if (result == null) result = ParseLineItem(markdown, isList, out inListAfter);
        if (result == null) result = ParseParagraph(markdown, isList, out inListAfter);
        if (result == null) throw new ArgumentException("Invalid markdown");

        return result;
    }

    private static string ParseHeader(string markdown, bool isList, out bool inListAfter)
    {
        int count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#') count += 1;
            else break;
        }

        if (count == 0)
        {
            inListAfter = isList;
            return null;
        }

        string headerTag = $"h{count}";
        string headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        inListAfter = false;
        if (isList) return $"</ul>{headerHtml}";
        else return headerHtml;
    }

    private static string ParseLineItem(string markdown, bool isList, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            string innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            inListAfter = true;
            if (isList) return innerHtml;
            else return $"<ul>{innerHtml}";
        }

        inListAfter = isList;
        return null;
    }

    private static string ParseParagraph(string markdown, bool isList, out bool inListAfter)
    {
        inListAfter = false;
        if (isList) return $"</ul>{ParseText(markdown, isList)}";
        else return ParseText(markdown, isList); 
    }

    private static string ParseText(string markdown, bool isList)
    {
        string withStrongAndItalicTags = Parse_AsItalic(Parse__AsStrong((markdown)));

        if (isList) return withStrongAndItalicTags;
        else return Wrap(withStrongAndItalicTags, "p");
    }

    private static string Parse__AsStrong(string markdown) => ReplaceDelimitersWithTags(markdown, "__", "strong");

    private static string Parse_AsItalic(string markdown) => ReplaceDelimitersWithTags(markdown, "_", "em");

    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string ReplaceDelimitersWithTags(string markdown, string delimiter, string tag)
    {
        string pattern = $"{delimiter}(.+){delimiter}";
        string replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(markdown, pattern, replacement);
    }
}