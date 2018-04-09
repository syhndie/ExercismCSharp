using System;
using System.Collections.Generic;

public class NucleotideCount
{ 
    public NucleotideCount(string sequence)
    { 
        sequence.ToCharArray();
        int aCount = 0;
        int gCount = 0;
        int tCount = 0;
        int cCount = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == 'A') aCount++;
            else if (sequence[i] == 'G') gCount++;
            else if (sequence[i] == 'T') tCount++;
            else if (sequence[i] == 'C') cCount++;
        }

        if (aCount + gCount + tCount + cCount != sequence.Length)
        {
            throw new InvalidNucleotideException();
        }
        NucleotideCounts = new Dictionary<char, int>
        {
            ['A'] = aCount,
            ['G'] = gCount,
            ['T'] = tCount,
            ['C'] = cCount
        };

    }

    public IDictionary<char, int> NucleotideCounts { get; set; }
}

public class InvalidNucleotideException : Exception { }
