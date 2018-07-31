using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

public class SimpleCipher
{
    private enum TranlateDirection
    {
        Encode,
        Decode
    };

    const int alphabetLength = 26;
    string _key;

    public SimpleCipher()
    {
        _key = GetRandomKey(100);
    }

    public SimpleCipher(string key)
    {
        var regex = new Regex("^[a-z]+$");
        if (!regex.IsMatch(key)) throw new ArgumentException("Key can only be lowercase letters.");

        _key = key;
    }
    
    public string Key 
    {
        get
        {
            return _key;
        }
    }

    private int[] NumericKey
    {
        get
        {
            return GetIntsFromString(Key, 0);
        }
    }

    public string Encode(string plaintext)
    {
        return Translate(plaintext, TranlateDirection.Encode);
    }

    public string Decode(string ciphertext)
    {
        return Translate(ciphertext, TranlateDirection.Decode);
    }

    private string GetRandomKey(int keyLength)
    {
        char[] potentialChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        byte[] randomBytes = new byte[keyLength];

        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetNonZeroBytes(randomBytes);
        }

        StringBuilder randomString = new StringBuilder(keyLength);

        foreach (byte b in randomBytes)
        {
            randomString.Append(potentialChars[b % potentialChars.Length]);
        }

        return randomString.ToString();
    }

    private int[] GetIntsFromString (string letters, int intValueOfA)
    {
        return letters.Select(c => (int)c - (int)'a' + intValueOfA).ToArray();
    }

    private int[] GetIntsFromString(string letters)
    {
        return GetIntsFromString(letters, (int)'a');
    }

    private string Translate(string inputString, TranlateDirection translateDirection)
    {
        int[] explandedNumericKey = SetLengthOfNumericKey(inputString, NumericKey);

        int[] inputNumeric = GetIntsFromString(inputString);

        int[] translatedNumeric = ApplyKey(inputNumeric, explandedNumericKey, translateDirection);

        return GetStringFromInts(translatedNumeric);
    }

    private int[] SetLengthOfNumericKey(string text, int[] numericKey)
    {
        int[] expandedNumericKey = new int[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            int keyElement = 
            i < numericKey.Count()
                ? numericKey[i]
                : numericKey[i % numericKey.Count()];

            expandedNumericKey[i] = keyElement;
        }

        return expandedNumericKey;
    }

    private string GetStringFromInts(int[] numbers)
    {
        var characters = numbers
            .Select(i => i <= (int)'z' ? i : i - alphabetLength)
            .Select(i => i >= (int)'a' ? i : i + alphabetLength)
            .Select(i => (char)i);

        return String.Concat(characters);
    }

    private int[] ApplyKey(int[] message, int[] key, TranlateDirection translateDirection)
    {
        int multiplier = 
            translateDirection == TranlateDirection.Encode
            ? 1 
            : -1;

        return Enumerable.Range(0, message.Length)
            .Select(i => message[i] + (multiplier * key[i]))
            .ToArray();
    }

} 