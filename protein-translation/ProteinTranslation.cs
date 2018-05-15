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
    private static readonly Dictionary<string, Proteins> mapCodonProtein = new Dictionary<string, Proteins>
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
        return Enumerable.Range(0, codon.Length / 3)
            .Select(i => codon.Substring(i * 3, 3))
            .Select(s => GetProteinName(s))
            .TakeWhile(s => s != $"{Proteins.STOP}")
            .ToArray();
    }

    private static string GetProteinName(string codon)
    {
        if (mapCodonProtein.TryGetValue(codon, out Proteins protein))
        {
            return protein.ToString();
        }

        throw new Exception("Invalid codon");
    }
}