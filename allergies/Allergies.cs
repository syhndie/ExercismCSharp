using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    eggs = 1,
    peanuts = 2,
    shellfish = 4,
    strawberries = 8,
    tomatoes = 16,
    chocolate = 32,
    pollen = 64,
    cats = 128
}

public class Allergies
{
    private int MaskTrimmed { get; set; }
    private Allergen MaskEnum { get; set; }

    public Allergies(int mask)
    {
        mask %= 256;
        MaskTrimmed = mask;
        MaskEnum = (Allergen)mask;
    }

    public bool IsAllergicTo(string allergy)
    {
        if (Enum.TryParse(allergy, out Allergen allergyEnum))
        {
            int allergyEnumValue = (int)allergyEnum;
            return (allergyEnumValue & MaskTrimmed) != 0;
        }
        else return false;
    }

    public IList<string> List()
    {
        if ((int)MaskEnum == 0) return new List<string>();
        return MaskEnum.ToString().Split(", ");
    }
}