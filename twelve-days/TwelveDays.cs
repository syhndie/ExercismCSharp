using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDays
{
    enum DaysOfChristmas
    {
        first = 1, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelfth
    }
    private static Dictionary<DaysOfChristmas, string> giftForEachDay = new Dictionary<DaysOfChristmas, string>
    {
        {DaysOfChristmas.first, "a Partridge in a Pear Tree" },
        {DaysOfChristmas.second, "two Turtle Doves" },
        {DaysOfChristmas.third, "three French Hens" },
        {DaysOfChristmas.fourth, "four Calling Birds" },
        {DaysOfChristmas.fifth, "five Gold Rings" },
        {DaysOfChristmas.sixth, "six Geese-a-Laying" },
        {DaysOfChristmas.seventh, "seven Swans-a-Swimming" },
        {DaysOfChristmas.eighth, "eight Maids-a-Milking" },
        {DaysOfChristmas.ninth, "nine Ladies Dancing" },
        {DaysOfChristmas.tenth, "ten Lords-a-Leaping" },
        {DaysOfChristmas.eleventh, "eleven Pipers Piping" },
        {DaysOfChristmas.twelfth, "twelve Drummers Drumming" }
    };

    public static string Recite(int verseNumber)
    {
        return Recite(verseNumber, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return String.Join("\n", Enumerable
            .Range(startVerse, endVerse - (startVerse - 1))
            .Select(i => GetOneVerse(i)));
    }

    private static string GetOneVerse(int verseNumber)
    {
        DaysOfChristmas ordinal = (DaysOfChristmas)verseNumber;

        string pluralGifts = String.Join(", ", giftForEachDay
                .Where(p => (int)p.Key <= verseNumber && (int)p.Key > 1)
                .Select(p => p.Value)
                .Reverse());

        string gifts = verseNumber == 1
            ? giftForEachDay[DaysOfChristmas.first]
            : $"{pluralGifts}, and {giftForEachDay[DaysOfChristmas.first]}";

        return $"On the {ordinal} day of Christmas my true love gave to me, {gifts}.";
    }
}