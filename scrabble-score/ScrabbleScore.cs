using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    public static Dictionary<char, int> letterValues = new Dictionary<char, int>
        {
            ['a'] = 1,
            ['b'] = 3,
            ['c'] = 3,
            ['d'] = 2,
            ['e'] = 1,
            ['f'] = 4,
            ['g'] = 2,
            ['h'] = 4,
            ['i'] = 1,
            ['j'] = 8,
            ['k'] = 5,
            ['l'] = 1,
            ['m'] = 3,
            ['n'] = 1,
            ['o'] = 1,
            ['p'] = 3,
            ['q'] = 10,
            ['r'] = 1,
            ['s'] = 1,
            ['t'] = 1,
            ['u'] = 1,
            ['v'] = 4,
            ['w'] = 4,
            ['x'] = 8,
            ['y'] = 4,
            ['z'] = 10
        };

    public enum Bonus
    {
        None = 1,
        Double = 2,
        Triple = 3
    }

    public static int Score(string input)
    {
        return BaseScore(input);
    }

    public static int Score(string input, Bonus wordBonus, char[] doubleLetters, char[] tripleLetters)
    {
        var doubleLetterBonus = doubleLetters.Sum(c => letterValues[c]);
        var tripleLetterBonus = 2 * (tripleLetters.Sum(c => letterValues[c]));
        return (int)wordBonus * (BaseScore(input) + doubleLetterBonus + tripleLetterBonus);
    }

    public static int BaseScore(string input)
    {
        return input.ToLower().ToCharArray().Sum(c => letterValues[c]);
    }
}
