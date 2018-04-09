using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    public static string Convert(int number)
    {
        List<string> outputList = new List<string>();

        if (number % 3 == 0) outputList.Add("Pling");
        if (number % 5 == 0) outputList.Add("Plang");
        if (number % 7 == 0) outputList.Add("Plong");

        if (!outputList.Any()) return number.ToString();
        else return String.Join("", outputList);
    }
}