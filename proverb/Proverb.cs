using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] proverb = new string[] { };

        for (int i = 0; i < subjects.Length; i++)
        {
            if (i == subjects.Length - 1)
            {
                proverb = proverb
                    .Append($"And all for the want of a {subjects[0]}.")
                    .ToArray();
            }
            else
            {
                proverb = proverb
                    .Append($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.")
                    .ToArray();
            }                
        }

        return proverb;
    }
}