using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static Dictionary<char, char> nucleotideLookup = new Dictionary<char, char>
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };

    public static string ToRna(string nucleotide)
    {
        var rna = nucleotide.ToCharArray().Select(c => nucleotideLookup[c]).ToArray();
        return new string(rna);
    }
}