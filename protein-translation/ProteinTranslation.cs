using System;
using System.Collections.Generic;
using System.Linq;

public enum AminoAcid
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
    private static readonly Dictionary<string, AminoAcid> mapCodons = new Dictionary<string, AminoAcid>
    {
        ["AUG"] = AminoAcid.Methionine,
        ["UUU"] = AminoAcid.Phenylalanine,
        ["UUC"] = AminoAcid.Phenylalanine,
        ["UUA"] = AminoAcid.Leucine,
        ["UUG"] = AminoAcid.Leucine,
        ["UCU"] = AminoAcid.Serine,
        ["UCC"] = AminoAcid.Serine,
        ["UCA"] = AminoAcid.Serine,
        ["UCG"] = AminoAcid.Serine,
        ["UAU"] = AminoAcid.Tyrosine,
        ["UAC"] = AminoAcid.Tyrosine,
        ["UGU"] = AminoAcid.Cysteine,
        ["UGC"] = AminoAcid.Cysteine,
        ["UGG"] = AminoAcid.Tryptophan,
        ["UAA"] = AminoAcid.STOP,
        ["UAG"] = AminoAcid.STOP,
        ["UGA"] = AminoAcid.STOP
    };
 
    public static string[] Translate(string strand)
    {
        return Enumerable.Range(0, strand.Length / 3)
            .Select(i => strand.Substring(i * 3, 3))
            .Select(s => GetAminoAcidName(s))
            .TakeWhile(s => s != $"{AminoAcid.STOP}")
            .ToArray();
    }

    private static string GetAminoAcidName(string codon)
    {
        if (mapCodons.TryGetValue(codon, out AminoAcid aminoAcid))
        {
            return aminoAcid.ToString();
        }

        throw new Exception("Invalid codon");
    }
}