using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        var test = plaintext.ToLower()
            .Where(c => Char.IsLetterOrDigit(c))
            .ToArray();

        return new string(test);
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        int charCount = plaintext.Length;

        double sqrtOfCharCount = Math.Sqrt(charCount);

        int colCount = sqrtOfCharCount % 1 > 0
            ? (int)sqrtOfCharCount + 1
            : (int)sqrtOfCharCount;
        
        List<string> listOfSegments = new List<string>();

        for (int i = 0; i < charCount; i += colCount)
        {
            if ((i + colCount) < charCount)
                listOfSegments.Add(plaintext.Substring(i, colCount));
            else
                listOfSegments.Add(plaintext.Substring(i));
        }

        return listOfSegments;
    }

    public static string Encoded(string plaintext)
    {
        string normalized = CryptoSquare.NormalizedPlaintext(plaintext);
        IEnumerable<string> segments = CryptoSquare.PlaintextSegments(normalized);

        StringBuilder encodedtext = new StringBuilder();

        for (int i = 0; i < segments.First().Length; i++)
        {
            foreach (string segment in segments)
            {
                if (i < segment.Length) encodedtext.Append(segment[i]);
                else encodedtext.Append(' ');
            }

            if (i < segments.First().Length - 1) encodedtext.Append(' ');
        }

        return encodedtext.ToString();
    }

    public static string Ciphertext(string plaintext)
    {
        return plaintext == "" 
            ? ""
            : Encoded(plaintext);
    }
}