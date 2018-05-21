using System;
using System.Collections.Generic;
using System.Linq;

public static class BeerSong
{
    private const string Base = "x bottles of beer on the wall, x bottles of beer.\n" +
                                "Take one down and pass it around, y bottles of beer on the wall.\n" +
                                "";
    public static string Verse(int number)
    {
        string startNumber = number.ToString();
        string startPlurality = "s";
        string startNumberSecondTime = number.ToString();
        string secondLineBeginning = "Take one down and pass it around";
        string endNumber = (number - 1).ToString();
        string endPlurality = "s";

        switch(number)
        {
            case 0:
                startNumber = "No more";
                startNumberSecondTime = "no more";
                secondLineBeginning = "Go to the store and buy some more";
                endNumber = "99";
                break;

            case 1:
                startPlurality = "";
                secondLineBeginning = "Take it down and pass it around";
                endNumber = "no more";
                break;

            case 2:
                endPlurality = "";
                break;
        }

        return $"{startNumber} bottle{startPlurality} of beer on the wall, {startNumberSecondTime} bottle{startPlurality} of beer.\n" +
            $"{secondLineBeginning}, {endNumber} bottle{endPlurality} of beer on the wall.\n";
    }

    public static string Verses(int begin, int end)
    {
        string song = "";
        for (int i = begin; i >= end; --i)
        {
            if (i == end) song = song + Verse(i);
            else song = song + Verse(i) + "\n";
        }
        return song;
    }
}