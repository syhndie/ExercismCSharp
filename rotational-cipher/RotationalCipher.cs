using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (!Char.IsLetter(text[i]))
            {
                result.Append(text[i]);
                continue;
            }

            int intValueOfOrigChar = Convert.ToInt32(text[i]);
            int intValueShifted = intValueOfOrigChar + shiftKey;

            if (intValueOfOrigChar <= 90)
            {
                if (intValueShifted > 90) intValueShifted = intValueShifted - 26;
                else if (intValueShifted < 65) intValueShifted = intValueShifted + 26;
            }
            else
            {
                if (intValueShifted > 122) intValueShifted = intValueShifted - 26;
                else if (intValueShifted < 97) intValueShifted = intValueShifted + 26;
            }

            char charShifted = Convert.ToChar(intValueShifted);
            result.Append(charShifted);            
        }

        return result.ToString();
    }
}