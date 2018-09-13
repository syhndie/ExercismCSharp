using System;
using System.Linq;
using System.Collections.Generic;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        Stack<char> openBracketStack = new Stack<char>();

        foreach (char c in input)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    openBracketStack.Push(c);
                    break;

                case ')':
                case '}':
                case ']':
                    if (openBracketStack.Count() == 0) return false;
                    if (openBracketStack.Peek() == bracketPairs[c]) openBracketStack.Pop();
                    else return false;
                    break;

                default:
                    break;
            }
        }

        return openBracketStack.Count() == 0;
    }
}
