using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        Dictionary<char, char> nucleotideLookup = new Dictionary<char, char>
        {
            ['G'] = 'C',
            ['C'] = 'G',
            ['T'] = 'A',
            ['A'] = 'U'
        };

        char[] DNAArray = nucleotide.ToCharArray();
        List<char> RNAList = new List<char>();

        foreach (char letter in DNAArray) RNAList.Add(nucleotideLookup[letter]);
        
        return new string(RNAList.ToArray());
    }
}