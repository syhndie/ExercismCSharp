using System;
using System.Collections.Generic;
using System.Linq;

public enum Proteins
{
    Methionine,
    Phenylalanine,
    Leucine,
    Serine,
    Tyrosine,
    Cysteine,
    Tryptophan,
    STOP
}

public static class ProteinTranslation
{
    private static readonly Dictionary<string, Proteins> codonProteinLookup = new Dictionary<string, Proteins>
    {
        ["AUG"] = Proteins.Methionine,
        ["UUU"] = Proteins.Phenylalanine,
        ["UUC"] = Proteins.Phenylalanine,
        ["UUA"] = Proteins.Leucine,
        ["UUG"] = Proteins.Leucine,
        ["UCU"] = Proteins.Serine,
        ["UCC"] = Proteins.Serine,
        ["UCA"] = Proteins.Serine,
        ["UCG"] = Proteins.Serine,
        ["UAU"] = Proteins.Tyrosine,
        ["UAC"] = Proteins.Tyrosine,
        ["UGU"] = Proteins.Cysteine,
        ["UGC"] = Proteins.Cysteine,
        ["UGG"] = Proteins.Tryptophan,
        ["UAA"] = Proteins.STOP,
        ["UAG"] = Proteins.STOP,
        ["UGA"] = Proteins.STOP
    };
 
    public static string[] Translate(string codon)
    {
        string[] codons = new string[] { };
        for (int i = 0; i < codon.Length; i+=3)
        {
            codons = codons.Append(codon.Substring(i, 3)).ToArray();
        }

        string[] proteins = new string[] { };        
        foreach (string snippet in codons)
        {
            if (codonProteinLookup.Keys.Contains(snippet))
            {
                var newProtein = codonProteinLookup[snippet];
                if (newProtein == Proteins.STOP) return proteins;
                proteins = proteins.Append(newProtein.ToString()).ToArray();
            }
            else throw new Exception("Invalid codon present");
        }

        return proteins;
    }
}