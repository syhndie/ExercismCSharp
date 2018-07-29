using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

public class SimpleCipher
{
    string _key;

    public SimpleCipher()
    {
        _key = GetRandomKey();
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
        int[] expandedNumericKey = SetLengthOfNumericKey(plaintext, NumericKey);

        int[] numericMessage = GetIntsFromString(plaintext);

        int[] numericEncoded = Enumerable.Range(0, plaintext.Length)
            .Select(i => numericMessage[i] + expandedNumericKey[i])
            .ToArray();

        return GetStringFromInts(numericEncoded);
    }

    public string Decode(string ciphertext)
    {
        int[] expandedNumericKey = SetLengthOfNumericKey(ciphertext, NumericKey);

        int[] numericEncoded = GetIntsFromString(ciphertext);

        int[] numericMessage = Enumerable.Range(0, ciphertext.Length)
            .Select(i => numericEncoded[i] - expandedNumericKey[i])
            .ToArray();

        return GetStringFromInts(numericMessage);
    }

    private string GetRandomKey()
    {
        char[] potentialChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        byte[] randomBytes = new byte[100];

        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetNonZeroBytes(randomBytes);
        }

        StringBuilder randomString = new StringBuilder(100);

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
            .Select(i => i < 123 ? i : i - 26)
            .Select(i => i > 96 ? i : i + 26)
            .Select(i => (char)i);

        return String.Concat(characters);
    }

} 