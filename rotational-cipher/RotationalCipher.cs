using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string result = string.Empty;
        int? shifted = null;

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]))
            {
                shifted = text[i] + shiftKey;

                if (Char.IsUpper(text[i]) && shifted > 'Z') shifted -= 26;

                else if (Char.IsLower(text[i]) && shifted > 'z') shifted -= 26;
            }

            else shifted = text[i];

            result += (char)shifted;       
        }

        return result;
    }
}