using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        bool isSilent = String.IsNullOrWhiteSpace(statement);
        if (isSilent) return "Fine. Be that way!";

        bool isYelling = IsYelling(statement);
        bool isQuestion = statement.Trim().Last() == '?';
        
        if (isYelling && isQuestion) return "Calm down, I know what I'm doing!"; 
        if (isYelling) return "Whoa, chill out!"; 
        if (isQuestion) return "Sure.";  

        return "Whatever.";
    }

    public static bool IsYelling(string stmnt)
    {
        bool hasLetters = stmnt.ToCharArray().Any(c => Char.IsLetter(c));
        bool isAllUpper = stmnt.ToUpper() == stmnt;

        return hasLetters && isAllUpper;
    }
}